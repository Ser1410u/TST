using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFApp.Properties;

namespace WFApp.Forms
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            textBox2.Text = Settings.Default.ConnectionString;
            textBox3.Text = Settings.Default.PingInterval.ToString();
            checkBox1.Checked = Settings.Default.canEditRows;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings.Default["ConnectionString"] = textBox2.Text;
            Settings.Default["PingInterval"] = int.Parse(textBox3.Text);
            Settings.Default["canEditRows"] = checkBox1.Checked;
            Settings.Default.Save();
            Close();
        }
    }
}
