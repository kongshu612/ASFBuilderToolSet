using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

namespace UIAutomationHelperDemo.UILib
{
    public  class UIAutomationAccess
    {
        #region Private properties

        private static UIAutomationAccess _instance;

        private Dictionary<string, string[]> _functionHsTb = new Dictionary<string, string[]>();

        private UIAutomationAccess()
        {
            _functionHsTb.Add("InvokePattern", new string[] { "Invoke" });
            _functionHsTb.Add("WindowPattern", new string[] { "Close","SetWindowVisualState" });
        }
        
        #endregion

        #region Private functions
        private AutomationElement _GetRootElement()
        {
            return AutomationElement.RootElement;
        }

        private  AutomationElement _GetContainerElementByName(string containerName)
        {
            AutomationElement containerElement = null;
            if (!string.IsNullOrEmpty(containerName))
            {
                Condition containerCondition = new OrCondition(
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window),
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Pane),
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Group)
                    );
                PropertyCondition nameCondition = new PropertyCondition(AutomationElement.NameProperty, containerName, PropertyConditionFlags.IgnoreCase);
                containerCondition = new AndCondition(containerCondition, nameCondition);
                containerElement = _GetRootElement().FindFirst(TreeScope.Descendants, containerCondition);
            }
            else
            {
                containerElement = _GetRootElement();
            }
            return containerElement;
        }

        private  AutomationElement _FindFirst(AutomationElement rootElement, TreeScope scope, PropertyCondition propertyCondition)
        {
            return rootElement.FindFirst(scope, propertyCondition);
        }

        private  AutomationElement _GetFirstUIElementByID(string automationID, AutomationElement ancestorElement, TreeScope scope,int timeout)
        {
            if(ancestorElement==null)
            {
                ancestorElement=_GetRootElement();
            }
            PropertyCondition automationIDPropertyCondition = new PropertyCondition(AutomationElement.AutomationIdProperty,automationID,PropertyConditionFlags.IgnoreCase);
            AutomationElement UIElem=null;
            DateTime dtBegin=DateTime.Now;
            do
            {
                UIElem=ancestorElement.FindFirst(scope,automationIDPropertyCondition);
                if(UIElem!=null)
                {
                    return UIElem;
                }
            }while(DateTime.Now<dtBegin.AddSeconds(timeout));
            return UIElem;
        }
        

        #endregion

        #region Public functions
        public AutomationElement GetRootElement()
        {
            return AutomationElement.RootElement;
        }
        public  ControlType GetControlTypeFromName(string typeName)
        {
            FieldInfo fi = typeof(ControlType).GetField(typeName);
            return (ControlType)fi.GetValue(null);
        }

        public  AutomationPattern GetAutomationPatternFromName(string patternName)
        {
            FieldInfo fi = typeof(AutomationPattern).GetField(patternName);
            return (AutomationPattern)fi.GetValue(null);
        }

        public  AutomationElementCollection Get_AllContainerUIElement(AutomationElement ancestorElement=null, bool childOnly = false,int timeout=60)
        {
            if (ancestorElement == null)
            {
                ancestorElement = _GetRootElement();
            }
            AutomationElementCollection UIElems = null;
            TreeScope myScope = TreeScope.Descendants;
            Condition condition = new OrCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty,ControlType.Window),
                new PropertyCondition(AutomationElement.ControlTypeProperty,ControlType.Pane),
                new PropertyCondition(AutomationElement.ControlTypeProperty,ControlType.Group)
                );
            if (childOnly)
            {
                myScope = TreeScope.Children;
            }
            DateTime dtBegin = DateTime.Now;
            do
            {
                UIElems = ancestorElement.FindAll(myScope, condition);
                if (UIElems != null)
                {
                    return UIElems;
                }
            } while (dtBegin.AddSeconds(timeout) < DateTime.Now);
            return UIElems;
        }

        public AutomationElementCollection Get_AllDirectContainerUIElement(AutomationElement ancestorElement = null, int timeout = 60)
        {
            return Get_AllContainerUIElement(ancestorElement, true, timeout);
        }

        #region Button Functions

        public AutomationElementCollection Get_AllButtonUIElements(AutomationElement ancestorElement = null, bool childOnly = false, int timeout = 60)
        {
            if (ancestorElement == null)
            {
                ancestorElement = _GetRootElement();
            }
            AutomationElementCollection UIElems = null;
            TreeScope searchScope = TreeScope.Descendants;
            Condition searchCondition =  new PropertyCondition(AutomationElement.ControlTypeProperty,ControlType.Button);
            if (childOnly)
            {
                searchScope = TreeScope.Children;
            }
            DateTime dtBegin = DateTime.Now;
            do
            {
                UIElems = ancestorElement.FindAll(searchScope, searchCondition);
                if (UIElems != null)
                {
                    return UIElems;
                }
            } while (dtBegin.AddSeconds(timeout) < DateTime.Now);
            return UIElems;
        }

        public AutomationElementCollection Get_AllDirectButtonUIElements(AutomationElement ancestorElement = null, int timeout = 60)
        {
            return Get_AllButtonUIElements(ancestorElement, true,timeout);
        }

        public AutomationElement GetTargetButton(AutomationElement ancestorElement, System.Windows.Point myPoint)
        {
            AutomationElementCollection UIButtons = UILib.UIAutomationAccess.Instance.Get_AllDirectButtonUIElements(ancestorElement);
            AutomationElement targetButton = null;
            foreach (AutomationElement each in UIButtons)
            {
                if ((each.Current.BoundingRectangle.Contains(myPoint)) && !each.Current.IsOffscreen)
                {
                    targetButton = each;
                    break;
                }
            }
            return targetButton;
        }

        public AutomationPattern[] GetSupporttedPatterns(AutomationElement UIElem)
        {
            return UIElem.GetSupportedPatterns();
        }

        public string[] GetSupporttedFunctions(string PatternName)
        {
            if (_functionHsTb.ContainsKey(PatternName))
            {
                return _functionHsTb[PatternName];
            }
            else
                return null;
        }

        #endregion
        public static UIAutomationAccess Instance
        {
            get 
            {
                if (_instance == null)
                {
                     _instance= new UIAutomationAccess();
                }
                return _instance;
            }
        }

        public System.Windows.Point GetMousePosition()
        {
            Point moucePoint = Control.MousePosition;
            System.Windows.Point myPoint = new System.Windows.Point(moucePoint.X, moucePoint.Y);
            return myPoint;
        }

        public  AutomationElement GetRootTarget(AutomationElement ancestorElement,System.Windows.Point myPoint)
        {
            AutomationElementCollection UIElems = UILib.UIAutomationAccess.Instance.Get_AllDirectContainerUIElement(ancestorElement);
            AutomationElement TarUIElem = null;
            foreach (AutomationElement each in UIElems)
            {               
                if ((each.Current.BoundingRectangle.Contains(myPoint)) && !each.Current.IsOffscreen)
                {
                    TarUIElem = each;
                    break;
                }
            }
            return TarUIElem;
        }

        

        #endregion
    }
}
