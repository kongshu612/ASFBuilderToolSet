using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIAutomationHelperDemo.GroupPolicy
{
    public partial class GroupPolicy : Form
    {
        public GroupPolicy()
        {
            InitializeComponent();
        }

        private void GeneateTDs_Click(object sender, EventArgs e)
        {
            List<GPLib.GPPolicyEnty> gpPolicyConfig = GPLib.GPAccess.Instance.GetPolicyConfig();
            richTextBox1.Text = GenerateCode.ASF.Instance.GetCTXGPConfigTD(gpPolicyConfig);
        }
    }
}
