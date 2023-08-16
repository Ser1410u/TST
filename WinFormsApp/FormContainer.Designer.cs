namespace WFApp
{
    partial class FormContainer
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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            настройкиToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            формыToolStripMenuItem = new ToolStripMenuItem();
            njToolStripMenuItem = new ToolStripMenuItem();
            аптекиToolStripMenuItem = new ToolStripMenuItem();
            складыToolStripMenuItem = new ToolStripMenuItem();
            партииToolStripMenuItem = new ToolStripMenuItem();
            формыToolStripMenuItem1 = new ToolStripMenuItem();
            всеТоварыВыбраннойАптекиToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, формыToolStripMenuItem, формыToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { настройкиToolStripMenuItem, выходToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // настройкиToolStripMenuItem
            // 
            настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            настройкиToolStripMenuItem.Size = new Size(134, 22);
            настройкиToolStripMenuItem.Text = "Настройки";
            настройкиToolStripMenuItem.Click += настройкиToolStripMenuItem_Click;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(134, 22);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // формыToolStripMenuItem
            // 
            формыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { njToolStripMenuItem, аптекиToolStripMenuItem, складыToolStripMenuItem, партииToolStripMenuItem });
            формыToolStripMenuItem.Name = "формыToolStripMenuItem";
            формыToolStripMenuItem.Size = new Size(94, 20);
            формыToolStripMenuItem.Text = "Справочники";
            // 
            // njToolStripMenuItem
            // 
            njToolStripMenuItem.Name = "njToolStripMenuItem";
            njToolStripMenuItem.Size = new Size(116, 22);
            njToolStripMenuItem.Text = "Товары";
            njToolStripMenuItem.Click += njToolStripMenuItem_Click;
            // 
            // аптекиToolStripMenuItem
            // 
            аптекиToolStripMenuItem.Name = "аптекиToolStripMenuItem";
            аптекиToolStripMenuItem.Size = new Size(116, 22);
            аптекиToolStripMenuItem.Text = "Аптеки";
            аптекиToolStripMenuItem.Click += аптекиToolStripMenuItem_Click;
            // 
            // складыToolStripMenuItem
            // 
            складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            складыToolStripMenuItem.Size = new Size(116, 22);
            складыToolStripMenuItem.Text = "Склады";
            складыToolStripMenuItem.Click += складыToolStripMenuItem_Click;
            // 
            // партииToolStripMenuItem
            // 
            партииToolStripMenuItem.Name = "партииToolStripMenuItem";
            партииToolStripMenuItem.Size = new Size(116, 22);
            партииToolStripMenuItem.Text = "Партии";
            партииToolStripMenuItem.Click += партииToolStripMenuItem_Click;
            // 
            // формыToolStripMenuItem1
            // 
            формыToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { всеТоварыВыбраннойАптекиToolStripMenuItem });
            формыToolStripMenuItem1.Name = "формыToolStripMenuItem1";
            формыToolStripMenuItem1.Size = new Size(60, 20);
            формыToolStripMenuItem1.Text = "Формы";
            // 
            // всеТоварыВыбраннойАптекиToolStripMenuItem
            // 
            всеТоварыВыбраннойАптекиToolStripMenuItem.Name = "всеТоварыВыбраннойАптекиToolStripMenuItem";
            всеТоварыВыбраннойАптекиToolStripMenuItem.Size = new Size(242, 22);
            всеТоварыВыбраннойАптекиToolStripMenuItem.Text = "Все товары выбранной аптеки";
            всеТоварыВыбраннойАптекиToolStripMenuItem.Click += всеТоварыВыбраннойАптекиToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Overflow = ToolStripItemOverflow.Never;
            toolStripStatusLabel1.Size = new Size(785, 17);
            toolStripStatusLabel1.Spring = true;
            toolStripStatusLabel1.Text = "MSSQL: ВКЛ";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 60000;
            timer1.Tick += timer1_Tick;
            // 
            // FormContainer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FormContainer";
            Text = "Тестовое задание №2 Павлов";
            Load += FormContainer_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem формыToolStripMenuItem;
        private ToolStripMenuItem njToolStripMenuItem;
        private ToolStripMenuItem аптекиToolStripMenuItem;
        private ToolStripMenuItem складыToolStripMenuItem;
        private ToolStripMenuItem партииToolStripMenuItem;
        private ToolStripMenuItem формыToolStripMenuItem1;
        private ToolStripMenuItem всеТоварыВыбраннойАптекиToolStripMenuItem;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
    }
}