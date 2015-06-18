namespace Versionizer.Admin
{
    partial class MainWin
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
            this.components = new System.ComponentModel.Container();
            this.lstAssembly = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVersion2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colComVisibility = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsAssembly = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAssembly.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstAssembly
            // 
            this.lstAssembly.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colVersion,
            this.colVersion2,
            this.colComVisibility});
            this.lstAssembly.ContextMenuStrip = this.cmsAssembly;
            this.lstAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAssembly.FullRowSelect = true;
            this.lstAssembly.GridLines = true;
            this.lstAssembly.Location = new System.Drawing.Point(0, 0);
            this.lstAssembly.MultiSelect = false;
            this.lstAssembly.Name = "lstAssembly";
            this.lstAssembly.Size = new System.Drawing.Size(892, 573);
            this.lstAssembly.TabIndex = 0;
            this.lstAssembly.UseCompatibleStateImageBehavior = false;
            this.lstAssembly.View = System.Windows.Forms.View.Details;
            this.lstAssembly.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnEdit);
            // 
            // colName
            // 
            this.colName.Text = "Assembly Name";
            this.colName.Width = 400;
            // 
            // colVersion
            // 
            this.colVersion.Text = "Assembly Version";
            this.colVersion.Width = 200;
            // 
            // colVersion2
            // 
            this.colVersion2.Text = "Assembly File Version";
            this.colVersion2.Width = 200;
            // 
            // colComVisibility
            // 
            this.colComVisibility.Text = "COM Visibility";
            this.colComVisibility.Width = 88;
            // 
            // cmsAssembly
            // 
            this.cmsAssembly.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddNew,
            this.tsmiEdit,
            this.tsmiDelete});
            this.cmsAssembly.Name = "cmsAssembly";
            this.cmsAssembly.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsAssembly.ShowImageMargin = false;
            this.cmsAssembly.Size = new System.Drawing.Size(119, 70);
            // 
            // tsmiAddNew
            // 
            this.tsmiAddNew.Name = "tsmiAddNew";
            this.tsmiAddNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiAddNew.Size = new System.Drawing.Size(118, 22);
            this.tsmiAddNew.Text = "New";
            this.tsmiAddNew.Click += new System.EventHandler(this.OnAdd);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.tsmiEdit.Size = new System.Drawing.Size(118, 22);
            this.tsmiEdit.Text = "Edit";
            this.tsmiEdit.Click += new System.EventHandler(this.OnEdit);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmiDelete.Size = new System.Drawing.Size(118, 22);
            this.tsmiDelete.Text = "Delete";
            this.tsmiDelete.Click += new System.EventHandler(this.OnDelete);
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 573);
            this.Controls.Add(this.lstAssembly);
            this.Name = "MainWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Versionizer Administration";
            this.Load += new System.EventHandler(this.OnLoad);
            this.cmsAssembly.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstAssembly;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colVersion;
        private System.Windows.Forms.ColumnHeader colVersion2;
        private System.Windows.Forms.ColumnHeader colComVisibility;
        private System.Windows.Forms.ContextMenuStrip cmsAssembly;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
    }
}