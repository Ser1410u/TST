using Newtonsoft.Json.Linq;
using RestSRV.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using WFApp.Classes;
using WFApp.Properties;

namespace WFApp.Forms
{
    public partial class FormLots : Form
    {
        private DataTable dt = new DataTable(), dtCmbStore = new DataTable(), dtCmbPharm = new DataTable(), dtCmbGood = new DataTable();
        private DataView dv, dvCmbStore;
        public FormLots()
        {
            Program.DataChanged += DataChangedHandler;
            InitializeComponent();
        }
        private void DataChangedHandler(object? sender, DataChangedEventArgs e)
        {
            if (sender != this)
            {
                if (e.name == "pharms" || e.name == "goods" || e.name == "lots" || e.name == "stores")
                {
                    S();
                }
            }
        }
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                //if (!Settings.Default.canEditRows)
                //    e.Cancel = !dataGridView1.CurrentRow.IsNewRow;
            }
            catch
            {
            }
        }
        private async void S()
        {
            SuspendLayout();
            object? sv = comboBox1.SelectedValue;
            Result _;
            _ = await Connector.S((MdiParent as FormContainer)._logger, dt, "S_Lots", Array.Empty<System.Data.SqlClient.SqlParameter>());
            if (_.Success)
            {
                string rf = (dv != null ? dv.RowFilter:"");
                dv = _.Table.AsDataView();
                dataGridView1.DataSource = dv;
                dv.RowFilter = rf;
            }
            _ = await Connector.S((MdiParent as FormContainer)._logger, dtCmbStore, "S_Stores", Array.Empty<System.Data.SqlClient.SqlParameter>());
            if (_.Success)
            {
                string rf = dvCmbStore!=null? dvCmbStore.RowFilter:"";
                dvCmbStore = _.Table.AsDataView();
                (dataGridView1.Columns[2] as DataGridViewComboBoxColumn).DataSource = dvCmbStore;
                dvCmbStore.RowFilter = rf;
            }
            _ = await Connector.S((MdiParent as FormContainer)._logger, dtCmbGood, "S_Goods", Array.Empty<System.Data.SqlClient.SqlParameter>());
            if (_.Success)
            {
                (dataGridView1.Columns[3] as DataGridViewComboBoxColumn).DataSource = _.Table;
            }
            _ = await Connector.S((MdiParent as FormContainer)._logger, dtCmbPharm, "S_Pharms", Array.Empty<System.Data.SqlClient.SqlParameter>());
            if (_.Success)
            {
                comboBox1.DataSource = _.Table;
            }
            comboBox1.Refresh(); dataGridView1.Refresh();
            if (sv != null)
            {
                comboBox1.SelectedValue = sv;
                setStoreFilter(comboBox1.SelectedValue);
            }
            ResumeLayout();
        }
        private async void IU(DataRow dr)
        {
            Result _ = await Connector.IU((MdiParent as FormContainer)._logger, "IU_Lots", new SqlParameter[]
                    { (new System.Data.SqlClient.SqlParameter("id", dr.RowState == DataRowState.Added? DBNull.Value:Convert.ToInt32(dr["id"])))
                    , new System.Data.SqlClient.SqlParameter("pharmid", Convert.ToInt32(dr["pharmid"]))
                    , new System.Data.SqlClient.SqlParameter("storeid", Convert.ToInt32(dr["storeid"]))
                    , new System.Data.SqlClient.SqlParameter("goodid", Convert.ToInt32(dr["goodid"]))
                    , new System.Data.SqlClient.SqlParameter("q", Convert.ToInt32(dr["q"]))
                    });
            if (_.Success)
            {
                if (dr.RowState == DataRowState.Added) dr["id"] = _.Table.Rows[0]["id"];
                dr.AcceptChanges();
                Program.fireDataChanged(this, new DataChangedEventArgs() { name = "lots", dt = _.Table });
            }
            else
            {
                //S();
                dr.RejectChanges();
            }
        }
        private async void D(DataRow dr)
        {
            Result _ = await Connector.D((MdiParent as FormContainer)._logger, "D_Lots", new SqlParameter[1] { new System.Data.SqlClient.SqlParameter("id", Convert.ToInt32(dr["id", DataRowVersion.Original])) });
            if (_.Success)
            {
                Program.fireDataChanged(this, new DataChangedEventArgs() { name = "lots", dt = dr.Table.GetChanges() });
                dr.AcceptChanges();
            }
            else
            {
                S();
                dr.RejectChanges();
            }
        }

        private void FormGoods_Load(object sender, EventArgs e)
        {
            S();
        }

        private void FormGoods_FormClosed(object sender, FormClosedEventArgs e)
        {
            dt.Dispose();
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((sender as DataGridView).Rows != null && (sender as DataGridView).Rows.Count > 0 && (sender as DataGridView).Rows[e.RowIndex] != null && (sender as DataGridView).Rows[e.RowIndex].DataBoundItem != null)
                {
                    DataRow dr = ((sender as DataGridView).Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                    switch (dr.RowState)
                    {
                        case DataRowState.Added:
                            IU(dr);
                            break;
                        case DataRowState.Modified:
                            IU(dr);
                            break;
                        case DataRowState.Deleted:
                            D(dr);
                            break;
                        case DataRowState.Unchanged:
                        default:
                            break;
                    }
                }
            }
            catch { }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column4_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 4) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column4_KeyPress);
                }
            }
        }

        private void Column4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private void setStoreFilter(object? value)
        {
            if (value is null)
            {
                return;
            }
            try
            {
                dv.RowFilter = $"PharmId = {value}";
                dvCmbStore.RowFilter = $"PharmId = {value}";
            }
            catch { }
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            SuspendLayout();
            if (comboBox1.SelectedValue != null)
                setStoreFilter(comboBox1.SelectedValue);
                comboBox1.Refresh(); dataGridView1.Refresh();
            ResumeLayout();
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["PharmId"].Value = comboBox1.SelectedValue;
        }

        private void dataGridView1_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }
        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            var dtt = dt.Select("", "", DataViewRowState.Deleted);
            foreach (DataRow w in dtt)
                D(w);
        }

    }
}
