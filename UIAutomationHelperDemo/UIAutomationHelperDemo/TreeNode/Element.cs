using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Reflection;

namespace UIAutomationHelperDemo.Element
{
    public enum UIType
    {
        Button,
        Container
    }
    public class Element
    {
        public Element(string name, UIType type,AutomationElement uiEle)
        {
            _name = name;
            _type = type;
            _uIEle = uiEle;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public UIType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public AutomationElement UIEle
        {
            get { return _uIEle; }
            set { _uIEle = value; }
        }

        private UIType _type;
        private string _name;
        private AutomationElement _uIEle;
    }

}
