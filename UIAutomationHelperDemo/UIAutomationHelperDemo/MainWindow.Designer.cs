namespace UIAutomationHelperDemo
{
    partial class MainWindow
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
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.NewSession = new System.Windows.Forms.ToolStripMenuItem();
            this.NewGPSession = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Tools = new System.Windows.Forms.ToolStripMenuItem();
            this.myMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.Tools,
            this.myMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1113, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // File
            // 
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewSession,
            this.NewGPSession,
            this.Exit});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(37, 20);
            this.File.Text = "&File";
            // 
            // NewSession
            // 
            this.NewSession.Name = "NewSession";
            this.NewSession.Size = new System.Drawing.Size(152, 22);
            this.NewSession.Text = "&NewUISession";
            this.NewSession.Click += new System.EventHandler(this.newSession_Click);
            // 
            // NewGPSession
            // 
            this.NewGPSession.Name = "NewGPSession";
            this.NewGPSession.Size = new System.Drawing.Size(152, 22);
            this.NewGPSession.Text = "&NewGPSession";
            this.NewGPSession.Click += new System.EventHandler(this.GPSession_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(152, 22);
            this.Exit.Text = "&Exit";
            // 
            // Tools
            // 
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(48, 20);
            this.Tools.Text = "Tools";
            // 
            // myMenu
            // 
            this.myMenu.Name = "myMenu";
            this.myMenu.Size = new System.Drawing.Size(50, 20);
            this.myMenu.Text = "Menu";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 576);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "MainWindow";
            this.Text = "ASF Builder ToolSet  Demo";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripMenuItem NewSession;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem Tools;
        private System.Windows.Forms.ToolStripMenuItem myMenu;
        private System.Windows.Forms.ToolStripMenuItem NewGPSession;

    }
}

