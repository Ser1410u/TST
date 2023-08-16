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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WFApp.Forms
{
    public partial class FormStores : Form
    {
        private DataTable dt = new DataTable(), dtCmb = new DataTable();

        public FormStores()
        {
            Program.DataChanged += DataChangedHandler;
            InitializeComponent();
        }
        private void DataChangedHandler(object? sender, DataChangedEventArgs e)
        {
            if (sender != this)
            {
                if (e.name == "pharms" || e.name == "stores")
                {
                    S();
                }
            }
        }
        private void bindingSource1_AddingNew(object sender, AddingNewEventArgs e)
        {

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (!Settings.Default.canEditRows)
                    e.Cancel = ((sender as DataGridView).DataSource as DataTable).Rows.Count > e.RowIndex;
            }
            catch
            {
            }
        }
        private async void S()
        {
            Result _ = await Connector.S((MdiParent as FormContainer)._logger, dt, "S_Stores", Array.Empty<System.Data.SqlClient.SqlParameter>());

            if (_.Success)
            {
                dataGridView1.DataSource = _.Table;
            }
            _ = await Connector.S((MdiParent as FormContainer)._logger, dtCmb, "S_Pharms", Array.Empty<System.Data.SqlClient.SqlParameter>());

            if (_.Success)
            {
                (dataGridView1.Columns[2] as DataGridViewComboBoxColumn).DataSource = _.Table;
            }
            dataGridView1.Refresh();

        }
        private async void IU(DataRow dr)
        {


            Result _ = await Connector.IU((MdiParent as FormContainer)._logger, "IU_Stores", new SqlParameter[]
                    { (new System.Data.SqlClient.SqlParameter("id", dr.RowState == DataRowState.Added? DBNull.Value:Convert.ToInt32(dr["id"])))
                    , new System.Data.SqlClient.SqlParameter("pharmid", Convert.ToInt32(dr["pharmid"]))
                    , new System.Data.SqlClient.SqlParameter("name", dr["name"].ToString())
                    });
            if (_.Success)
            {
                if (dr.RowState == DataRowState.Added) dr["id"] = _.Table.Rows[0]["id"];
                dr.AcceptChanges();
                Program.fireDataChanged(this, new DataChangedEventArgs() { name = "stores", dt = _.Table });
            }
            else
            {
                //S();
                dr.RejectChanges();
            }
        }
        private async void D(DataRow dr)
        {
            Result _ = await Connector.D((MdiParent as FormContainer)._logger, "D_Stores", new SqlParameter[1] { new System.Data.SqlClient.SqlParameter("id", Convert.ToInt32(dr["id", DataRowVersion.Original])) });
            if (_.Success)
            {
                Program.fireDataChanged(this, new DataChangedEventArgs() { name = "stores", dt = dr.Table.GetChanges() });
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
            /*    e.Control.KeyPress -= new KeyPressEventHandler(Column3_KeyPress);
                if (dataGridView1.CurrentCell.ColumnIndex == 3) //Desired Column
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column3_KeyPress);
                    }
                }*/
        }

        private void Column3_KeyPress(object sender, KeyPressEventArgs e)
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
        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            var dtt = dt.Select("", "", DataViewRowState.Deleted);
            foreach (DataRow w in dtt)
                D(w);
        }
    }
}
