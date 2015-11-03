using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UIAutomationHelperDemo
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void newSession_Click(object sender, EventArgs e)
        {
            workForm form = new workForm();
            form.MdiParent = this;
            form.Show();
        }

        private void GPSession_Click(object sender, EventArgs e)
        {
            GroupPolicy.GroupPolicy form = new GroupPolicy.GroupPolicy();
            form.MdiParent = this;
            form.Show();
        }
    }
}
