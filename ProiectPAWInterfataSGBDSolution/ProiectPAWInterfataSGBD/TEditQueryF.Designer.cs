namespace SQLEditor
{
    partial class TEditQueryF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TEditQueryF));
            this.listViewOutputSQLEditor = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSQLScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runSQLScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.listViewTabeleSQLEditor = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewOutputSQLEditor
            // 
            this.listViewOutputSQLEditor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.listViewOutputSQLEditor.Location = new System.Drawing.Point(27, 187);
            this.listViewOutputSQLEditor.Name = "listViewOutputSQLEditor";
            this.listViewOutputSQLEditor.Size = new System.Drawing.Size(624, 124);
            this.listViewOutputSQLEditor.TabIndex = 0;
            this.listViewOutputSQLEditor.UseCompatibleStateImageBehavior = false;
            this.listViewOutputSQLEditor.View = System.Windows.Forms.View.Details;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(27, 62);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(390, 119);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(693, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runSQLScriptToolStripMenuItem,
            this.saveSQLScriptToolStripMenuItem,
            this.saveCurrentOutputToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // saveSQLScriptToolStripMenuItem
            // 
            this.saveSQLScriptToolStripMenuItem.Name = "saveSQLScriptToolStripMenuItem";
            this.saveSQLScriptToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.saveSQLScriptToolStripMenuItem.Text = "Save SQL Script";
            this.saveSQLScriptToolStripMenuItem.Click += new System.EventHandler(this.saveSQLScriptToolStripMenuItem_Click);
            // 
            // runSQLScriptToolStripMenuItem
            // 
            this.runSQLScriptToolStripMenuItem.Name = "runSQLScriptToolStripMenuItem";
            this.runSQLScriptToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.runSQLScriptToolStripMenuItem.Text = "Run SQL Script";
            this.runSQLScriptToolStripMenuItem.Click += new System.EventHandler(this.runSQLScriptToolStripMenuItem_Click);
            // 
            // saveCurrentOutputToolStripMenuItem
            // 
            this.saveCurrentOutputToolStripMenuItem.Name = "saveCurrentOutputToolStripMenuItem";
            this.saveCurrentOutputToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.saveCurrentOutputToolStripMenuItem.Text = "Save Current Output";
            this.saveCurrentOutputToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentOutputToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(693, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // listViewTabeleSQLEditor
            // 
            this.listViewTabeleSQLEditor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader13});
            this.listViewTabeleSQLEditor.Location = new System.Drawing.Point(438, 62);
            this.listViewTabeleSQLEditor.Name = "listViewTabeleSQLEditor";
            this.listViewTabeleSQLEditor.Size = new System.Drawing.Size(213, 119);
            this.listViewTabeleSQLEditor.TabIndex = 7;
            this.listViewTabeleSQLEditor.UseCompatibleStateImageBehavior = false;
            this.listViewTabeleSQLEditor.View = System.Windows.Forms.View.Details;
            this.listViewTabeleSQLEditor.SelectedIndexChanged += new System.EventHandler(this.listViewTabeleSQLEditor_SelectedIndexChanged);
            // 
            // columnHeader12
            // 
            this.columnHeader12.Width = 0;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Tabels";
            // 
            // EditQueryF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 356);
            this.Controls.Add(this.listViewTabeleSQLEditor);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listViewOutputSQLEditor);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EditQueryF";
            this.Text = "SQL Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewOutputSQLEditor;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runSQLScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSQLScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ListView listViewTabeleSQLEditor;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
    }
}

