using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Automation;
using System.Reflection;

namespace UIAutomationHelperDemo
{
    public partial class workForm : Form
    {
        public workForm()
        {
            InitializeComponent();
            TreeNode root = new TreeNode("Desktop");
            root.Tag = UILib.UIAutomationAccess.Instance.GetRootElement();
            treeView1.Nodes.Add(root);
            treeView1.SelectedNode = null;

        }

        private void UIElement_Capture(object sender, KeyEventArgs e)
        {            
            if (e.Control)
            {
                AutomationElementCollection allContainer = UILib.UIAutomationAccess.Instance.Get_AllDirectContainerUIElement();
                System.Windows.Point myPoint = UILib.UIAutomationAccess.Instance.GetMousePosition();
                AutomationElement targUIEle = UILib.UIAutomationAccess.Instance.GetRootTarget(null,myPoint);
                if (targUIEle == null)
                {
                    MessageBox.Show("Do not get the root window of the target element");
                    return;
                }
                TreeNode root = treeView1.Nodes[0];
                root.Nodes.Clear();
                TreeNode targetNode = null;
                targetNode=Generate_Tree(root, allContainer, Element.UIType.Container,targUIEle);
                bool returnflag = Locate_TargetButton(targetNode, myPoint);
                if (returnflag == false)
                {
                    MessageBox.Show("the target control is not a button, not supported in this demo version");
                }
            }
        }

        private void Item_Select(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Desktop")
            {
                return;
            }
            Element.Element treeNodeData = e.Node.Tag as Element.Element;            
            try
            {
                PatternComBox.BeginUpdate();
                AutomationElement UIElem = treeNodeData.UIEle;
                AutomationPattern[] SupporttedPatterns = UILib.UIAutomationAccess.Instance.GetSupporttedPatterns(UIElem);
                PatternComBox.Items.Clear();
                foreach (AutomationPattern each in SupporttedPatterns)
                {
                    
                    PatternComBox.Items.Add(each.ProgrammaticName.Replace("Identifiers.Pattern",""));
                }
            }
            finally
            {
                PatternComBox.EndUpdate();
            }

        }




        #region mycode

        private bool Locate_TargetButton(TreeNode root, System.Windows.Point myPoint)
        {
            AutomationElement rootElem= ((Element.Element)root.Tag).UIEle;
            AutomationElementCollection allButtons = UILib.UIAutomationAccess.Instance.Get_AllDirectButtonUIElements(rootElem);
            AutomationElementCollection allContainer = UILib.UIAutomationAccess.Instance.Get_AllDirectContainerUIElement(rootElem);
            AutomationElement targetButton = UILib.UIAutomationAccess.Instance.GetTargetButton(rootElem, myPoint);
            AutomationElement targetContainer = UILib.UIAutomationAccess.Instance.GetRootTarget(rootElem, myPoint);
            TreeNode targetNode = Generate_Tree(root, allButtons, Element.UIType.Button, targetButton);
            if (targetNode != null)
            {
                treeView1.SelectedNode = targetNode;
                return true;
            }
            else
            {
                targetNode = Generate_Tree(root, allContainer, Element.UIType.Container, targetContainer);
                if (targetNode == null)
                {
                    return false;
                }
                else
                {
                    return Locate_TargetButton(targetNode, myPoint);
                }
            }
        }

        private TreeNode Generate_Tree(TreeNode root,AutomationElementCollection UIElems,Element.UIType ElemType,AutomationElement Target=null)
        {
            TreeNode returnNode = null;
            foreach (AutomationElement each in UIElems)
            {
                Element.Element eachNode = new Element.Element(each.Current.Name, ElemType, each);
                TreeNode eachTreeNode = new TreeNode(eachNode.Name);
                eachTreeNode.Tag = eachNode;
                root.Nodes.Add(eachTreeNode);
                if ((Target != null) && (Target == each))
                {
                    returnNode = eachTreeNode;
                }
            }
            return returnNode;
        }

        #endregion

        private void Pattern_Select(object sender, EventArgs e)
        {
            string[] SupporttedFuncNames = UILib.UIAutomationAccess.Instance.GetSupporttedFunctions(PatternComBox.Text);
            if (SupporttedFuncNames == null)
            {
                MessageBox.Show("Not Supported in this demo version");
                return;
            }
            try
            {
                FunctionComBox.BeginUpdate();
                FunctionComBox.Items.Clear();
                foreach (string each in SupporttedFuncNames)
                {
                    FunctionComBox.Items.Add(each);
                }
            }
            finally
            {
                FunctionComBox.EndUpdate();
            }
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            TreeNode parentNode = treeView1.SelectedNode;
            Element.Element treeNodeData = parentNode.Tag as Element.Element;
            while (parentNode.Parent.Text != "Desktop")
            {
                parentNode = parentNode.Parent;
            }
            if (!checkBox1.Checked)
            {
                outputView.Clear();
            }
            if (treeNodeData.Type != Element.UIType.Button)
            {
                MessageBox.Show("not support in this demo version");
                return;
            }
            string code = UIAutomationHelperDemo.GenerateCode.ASF.Instance.GetButtonTD(treeNodeData.UIEle,parentNode.Text);
            if (checkBox1.Checked)
            {
                outputView.Text += code;
            }
            else
            {
                outputView.Text = code;
            }
        }

    }
}
