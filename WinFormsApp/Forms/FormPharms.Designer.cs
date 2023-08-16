namespace WFApp.Forms
{
    partial class FormPharms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                Program.DataChanged -= DataChangedHandler;
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            address = new DataGridViewTextBoxColumn();
            phone = new DataGridViewTextBoxColumn();
            pharmBindingSource = new BindingSource(components);
            goodBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pharmBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)goodBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, address, phone });
            dataGridView1.DataSource = pharmBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(800, 450);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            dataGridView1.RowValidated += dataGridView1_RowValidated;
            dataGridView1.UserDeletedRow += dataGridView1_UserDeletedRow;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "id";
            idDataGridViewTextBoxColumn.Frozen = true;
            idDataGridViewTextBoxColumn.HeaderText = "id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 50;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            nameDataGridViewTextBoxColumn.HeaderText = "наименование";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 113;
            // 
            // address
            // 
            address.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            address.DataPropertyName = "address";
            address.HeaderText = "адрес";
            address.Name = "address";
            // 
            // phone
            // 
            phone.DataPropertyName = "phone";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            phone.DefaultCellStyle = dataGridViewCellStyle1;
            phone.HeaderText = "телефон";
            phone.Name = "phone";
            // 
            // pharmBindingSource
            // 
            pharmBindingSource.DataSource = typeof(RestSRV.Classes.Pharm);
            // 
            // goodBindingSource
            // 
            goodBindingSource.DataSource = typeof(RestSRV.Classes.Good);
            // 
            // FormPharms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Name = "FormPharms";
            Text = "Аптеки";
            FormClosed += FormGoods_FormClosed;
            Load += FormGoods_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pharmBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)goodBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private BindingSource goodBindingSource;
        private BindingSource pharmBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn address;
        private DataGridViewTextBoxColumn phone;
    }
}