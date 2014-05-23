namespace ProiectPAWInterfataSGBD
{
    partial class MDIParent
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBTreeviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.populareTreeViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.populareTreeViewMoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(688, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sQLEditorToolStripMenuItem,
            this.dBTreeviewToolStripMenuItem,
            this.newConnectionToolStripMenuItem,
            this.populareTreeViewToolStripMenuItem,
            this.populareTreeViewMoreToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.newToolStripMenuItem.Text = "New";
            // 
            // sQLEditorToolStripMenuItem
            // 
            this.sQLEditorToolStripMenuItem.Name = "sQLEditorToolStripMenuItem";
            this.sQLEditorToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.sQLEditorToolStripMenuItem.Text = "SQLEditor";
            this.sQLEditorToolStripMenuItem.Click += new System.EventHandler(this.sQLEditorToolStripMenuItem_Click);
            // 
            // dBTreeviewToolStripMenuItem
            // 
            this.dBTreeviewToolStripMenuItem.Name = "dBTreeviewToolStripMenuItem";
            this.dBTreeviewToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.dBTreeviewToolStripMenuItem.Text = "DB Treeview";
            this.dBTreeviewToolStripMenuItem.Click += new System.EventHandler(this.dBTreeviewToolStripMenuItem_Click);
            // 
            // newConnectionToolStripMenuItem
            // 
            this.newConnectionToolStripMenuItem.Name = "newConnectionToolStripMenuItem";
            this.newConnectionToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.newConnectionToolStripMenuItem.Text = "New Connection";
            this.newConnectionToolStripMenuItem.Click += new System.EventHandler(this.newConnectionToolStripMenuItem_Click);
            // 
            // populareTreeViewToolStripMenuItem
            // 
            this.populareTreeViewToolStripMenuItem.Name = "populareTreeViewToolStripMenuItem";
            this.populareTreeViewToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.populareTreeViewToolStripMenuItem.Text = "PopulareTreeView";
            this.populareTreeViewToolStripMenuItem.Click += new System.EventHandler(this.populareTreeViewToolStripMenuItem_Click);
            // 
            // populareTreeViewMoreToolStripMenuItem
            // 
            this.populareTreeViewMoreToolStripMenuItem.Name = "populareTreeViewMoreToolStripMenuItem";
            this.populareTreeViewMoreToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.populareTreeViewMoreToolStripMenuItem.Text = "PopulareTree View More";
            this.populareTreeViewMoreToolStripMenuItem.Click += new System.EventHandler(this.populareTreeViewMoreToolStripMenuItem_Click);
            // 
            // MDIParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 445);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDIParent";
            this.Text = "MDIParent";
            this.Load += new System.EventHandler(this.MDIParent_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem populareTreeViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem populareTreeViewMoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBTreeviewToolStripMenuItem;
    }
}