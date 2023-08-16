namespace WFApp.Forms
{
    partial class FormReport
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
            storeBindingSource = new BindingSource(components);
            goodBindingSource = new BindingSource(components);
            lotBindingSource = new BindingSource(components);
            pharmBindingSource = new BindingSource(components);
            panel2 = new Panel();
            comboBox1 = new ComboBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            Товар = new DataGridViewTextBoxColumn();
            nDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            goodByPharmBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)storeBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)goodBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lotBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pharmBindingSource).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)goodByPharmBindingSource).BeginInit();
            SuspendLayout();
            // 
            // storeBindingSource
            // 
            storeBindingSource.DataSource = typeof(RestSRV.Classes.Store);
            // 
            // goodBindingSource
            // 
            goodBindingSource.DataSource = typeof(RestSRV.Classes.Good);
            // 
            // lotBindingSource
            // 
            lotBindingSource.DataSource = typeof(RestSRV.Classes.Lot);
            // 
            // pharmBindingSource
            // 
            pharmBindingSource.DataSource = typeof(RestSRV.Classes.Pharm);
            // 
            // panel2
            // 
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 69);
            panel2.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.DataSource = pharmBindingSource;
            comboBox1.DisplayMember = "name";
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(93, 23);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(304, 23);
            comboBox1.TabIndex = 1;
            comboBox1.ValueMember = "id";
            comboBox1.SelectedValueChanged += comboBox1_SelectedValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 26);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 0;
            label1.Text = "Аптека";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Товар, nDataGridViewTextBoxColumn });
            dataGridView1.DataSource = goodByPharmBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 69);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(800, 381);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
            // 
            // Товар
            // 
            Товар.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Товар.DataPropertyName = "name";
            Товар.HeaderText = "Товар";
            Товар.Name = "Товар";
            Товар.Resizable = DataGridViewTriState.True;
            // 
            // nDataGridViewTextBoxColumn
            // 
            nDataGridViewTextBoxColumn.DataPropertyName = "N";
            nDataGridViewTextBoxColumn.HeaderText = "Количество";
            nDataGridViewTextBoxColumn.Name = "nDataGridViewTextBoxColumn";
            // 
            // goodByPharmBindingSource
            // 
            goodByPharmBindingSource.DataSource = typeof(RestSRV.Classes.GoodByPharm);
            // 
            // FormReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Name = "FormReport";
            Text = "Отчет";
            FormClosed += FormGoods_FormClosed;
            Load += FormGoods_Load;
            ((System.ComponentModel.ISupportInitialize)storeBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)goodBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)lotBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pharmBindingSource).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)goodByPharmBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource goodBindingSource;
        private BindingSource pharmBindingSource;
        private BindingSource storeBindingSource;
        private BindingSource lotBindingSource;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Label label1;
        private ComboBox comboBox1;
        private BindingSource goodByPharmBindingSource;
        private DataGridViewTextBoxColumn Товар;
        private DataGridViewTextBoxColumn nDataGridViewTextBoxColumn;
    }
}