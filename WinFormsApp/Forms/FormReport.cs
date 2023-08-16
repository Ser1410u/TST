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
    public partial class FormReport : Form
    {
        private DataTable dt = new DataTable(), dtCmbPharm = new DataTable();
        public FormReport()
        {
            Program.DataChanged += DataChangedHandler;
            InitializeComponent();
        }

        private async void DataChangedHandler(object? sender, DataChangedEventArgs e)
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
                if (!Settings.Default.canEditRows)
                    e.Cancel = !dataGridView1.CurrentRow.IsNewRow;
            }
            catch
            {
            }
        }
        private async void R(int pharmID)
        {
            SuspendLayout();
            Result _;
            _ = await Connector.S((MdiParent as FormContainer)._logger, dt, "GET_GoodsByPharm", new SqlParameter[] { new SqlParameter("PharmID", pharmID) });
            if (_.Success)
            {
                dataGridView1.DataSource = _.Table;
                comboBox1.Refresh(); dataGridView1.Refresh();
            }
            ResumeLayout();
        }
        private async void S()
        {
            SuspendLayout();
            object? sv = comboBox1.SelectedValue;
            Result _;
            _ = await Connector.S((MdiParent as FormContainer)._logger, dtCmbPharm, "S_Pharms", Array.Empty<SqlParameter>());
            if (_.Success)
            {
                comboBox1.DataSource = _.Table;
                comboBox1.Refresh(); dataGridView1.Refresh();
                if (sv != null)
                {
                    comboBox1.SelectedValue = sv;
                    //R(Convert.ToInt32(comboBox1.SelectedValue));
                }
            }
            ResumeLayout();
        }

        private void FormGoods_Load(object sender, EventArgs e)
        {
            S();
        }

        private void FormGoods_FormClosed(object sender, FormClosedEventArgs e)
        {
            dt.Dispose();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            SuspendLayout();
            if (comboBox1.SelectedValue != null)
                R(Convert.ToInt32(comboBox1.SelectedValue));
            comboBox1.Refresh(); dataGridView1.Refresh();
            ResumeLayout();
        }
    }
}
