namespace WFApp.Forms
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            button1 = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            button2 = new Button();
            textBox4 = new TextBox();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(93, 139);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Отмена";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 13);
            label2.Name = "label2";
            label2.Size = new Size(177, 15);
            label2.TabIndex = 4;
            label2.Text = "Строка соединения для MSSQL";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(240, 10);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(793, 23);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 61);
            label3.Name = "label3";
            label3.Size = new Size(222, 15);
            label3.TabIndex = 6;
            label3.Text = "Интервал опроса готовности серверов";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(240, 58);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(66, 23);
            textBox3.TabIndex = 5;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // button2
            // 
            button2.Location = new Point(12, 139);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "Сохранить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.Info;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Enabled = false;
            textBox4.Location = new Point(325, 39);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(703, 123);
            textBox4.TabIndex = 10;
            textBox4.Text = resources.GetString("textBox4.Text");
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 103);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(236, 19);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "Редактировать существующие записи";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            AcceptButton = button2;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton = button1;
            ClientSize = new Size(1039, 168);
            ControlBox = false;
            Controls.Add(checkBox1);
            Controls.Add(textBox4);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            MaximumSize = new Size(1055, 207);
            MinimizeBox = false;
            MinimumSize = new Size(1055, 207);
            Name = "FormSettings";
            ShowIcon = false;
            Text = "Настройки";
            TopMost = true;
            Load += FormSettings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Button button2;
        private TextBox textBox4;
        private CheckBox checkBox1;
    }
}