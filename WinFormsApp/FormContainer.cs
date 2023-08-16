using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;

using WFApp.Classes;
using WFApp.Forms;
using WFApp.Properties;
using RestSRV.Classes;
using System.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

namespace WFApp
{
    public partial class FormContainer : Form
    {
        public readonly ILogger _logger;

        public bool isSQLExists = Connector.sqlExists();

        public FormContainer(ILogger<FormContainer> logger)
        {
            _logger = logger;
            InitializeComponent();
        }

        private Form[] _forms = new Form[5];
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void njToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_forms[0] == null || _forms[0].IsDisposed) _forms[0] = new FormGoods();
            _forms[0].MdiParent = this;
            _forms[0].Show();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormSettings().ShowDialog();

        }

        private void FormContainer_Load(object sender, EventArgs e)
        {
            timer1.Interval = Settings.Default.PingInterval;
            CheckConnections();
            _logger.LogInformation("WFApp загружен");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckConnections();
        }
        public void CheckConnections()
        {
            isSQLExists = Connector.sqlExists();


            if (isSQLExists)
            {
                toolStripStatusLabel1.Text = "MSSQL: ВКЛ";
                toolStripStatusLabel1.ForeColor = Color.Green;
            }
            else
            {
                toolStripStatusLabel1.Text = "MSSQL: ОТКЛ";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
            if (!isSQLExists)
                new FormSettings().ShowDialog();
        }

        private void аптекиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_forms[1] == null || _forms[1].IsDisposed) _forms[1] = new FormPharms();
            _forms[1].MdiParent = this;
            _forms[1].Show();
        }

        private void складыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_forms[2] == null || _forms[2].IsDisposed) _forms[2] = new FormStores();
            _forms[2].MdiParent = this;
            _forms[2].Show();
        }

        private void партииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_forms[3] == null || _forms[3].IsDisposed) _forms[3] = new FormLots();
            _forms[3].MdiParent = this;
            _forms[3].Show();
        }

        private void всеТоварыВыбраннойАптекиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_forms[4] == null || _forms[4].IsDisposed) _forms[4] = new FormReport();
            _forms[4].MdiParent = this;
            _forms[4].Show();
        }
    }
}
