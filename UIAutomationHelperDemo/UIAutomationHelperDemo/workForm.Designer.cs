namespace UIAutomationHelperDemo
{
    partial class workForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.outputView = new System.Windows.Forms.RichTextBox();
            this.FunctionComBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PatternComBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.PatternComBox);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.outputView);
            this.splitContainer1.Panel2.Controls.Add(this.FunctionComBox);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(919, 511);
            this.splitContainer1.SplitterDistance = 219;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(219, 511);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Item_Select);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UIElement_Capture);
            // 
            // outputView
            // 
            this.outputView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.outputView.Location = new System.Drawing.Point(0, 199);
            this.outputView.Name = "outputView";
            this.outputView.Size = new System.Drawing.Size(696, 312);
            this.outputView.TabIndex = 2;
            this.outputView.Text = "";
            // 
            // FunctionComBox
            // 
            this.FunctionComBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FunctionComBox.FormattingEnabled = true;
            this.FunctionComBox.Location = new System.Drawing.Point(502, 38);
            this.FunctionComBox.Name = "FunctionComBox";
            this.FunctionComBox.Size = new System.Drawing.Size(149, 21);
            this.FunctionComBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(394, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SupportedFunctions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SupportedPattern";
            // 
            // PatternComBox
            // 
            this.PatternComBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PatternComBox.FormattingEnabled = true;
            this.PatternComBox.Location = new System.Drawing.Point(145, 38);
            this.PatternComBox.Name = "PatternComBox";
            this.PatternComBox.Size = new System.Drawing.Size(180, 21);
            this.PatternComBox.TabIndex = 4;
            this.PatternComBox.SelectedValueChanged += new System.EventHandler(this.Pattern_Select);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "GenerateCode";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Generate_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(196, 116);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Multi-Steps";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // workForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 511);
            this.Controls.Add(this.splitContainer1);
            this.Name = "workForm";
            this.Text = "Work Sheet";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.RichTextBox outputView;
        private System.Windows.Forms.ComboBox FunctionComBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PatternComBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;

    }
}