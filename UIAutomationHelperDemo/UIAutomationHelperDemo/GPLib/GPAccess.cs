using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Management.Automation.Runspaces;
using System.Xml;
using System.Collections;

namespace UIAutomationHelperDemo.GPLib
{
    public class GPPolicyEnty
    {
        private string _gpName;
        private string _policyName;
        private string _state;
        private string _value;
        private string _userContext;

        public string GpName
        {
            get{
                return _gpName;
            }
            set
            {
                _gpName=value;
            }
        }
        public string PolicyName
        {
            get
            {
                return _policyName;
            }
            set
            {
                _policyName=value;
            }
        }
        public string State
        {
            get{return _state;}
            set{_state=value;}
        }
        public string Value
        {
            get{return _value;}
            set{_value=value;}
        }
        public string UserContext
        {
            get{return _userContext;}
            set{_userContext=value;}
        }
    }

    public class GPPolicy
    {
        private string _gpName;
        private string _priority;
        private string _description;

        public string GPName
        {
            get{return _gpName;}
            set{_gpName=value;}
        }
        public string Priority
        {
            get{return _priority;}
            set{_priority=value;}
        }
        public string Description
        {
            get{return _description;}
            set{_description=value;}
        }
    }



    public class GPAccess
    {
        private static GPAccess _instances=null;
        public const string cmd1 = "Get-GPNames";
        public const string cmd2 = "Get-GPHsTable";
        public const string cmd3 = "Generate-PolicyTree";
        public const string GPScript = "GPLib\\GPDetect.ps1";
        public const string policyConfigFile = @"c:\programdata\GPConfig.xml";


        public static GPAccess Instance
        {
            get {
                if (_instances == null)
                {
                    _instances = new GPAccess();
                }
                return _instances;
            }
        }
        #region public function
        public List<GPPolicyEnty> GetPolicyConfig()
        {
            List<GPPolicyEnty> policyConfigObj = new List<GPPolicyEnty>();
            PowerShell ps = PowerShell.Create();
            string scriptPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), GPScript);
            string cmdtmp = ". " + scriptPath + ";" + cmd2;
            ps.AddScript(cmdtmp);
            Collection<PSObject> results = ps.Invoke();
            for(int i=1;i<results.Count;i++)
            {
                Hashtable eachGpEntry = (Hashtable)results[i].BaseObject;
                GPPolicyEnty gpobj = new GPPolicyEnty();
                gpobj.GpName = eachGpEntry["GPName"].ToString();
                gpobj.PolicyName = eachGpEntry["PolicyName"].ToString();
                gpobj.UserContext = eachGpEntry["UserContext"].ToString();
                if (!string.IsNullOrEmpty(eachGpEntry["Value"].ToString()))
                {
                    gpobj.Value = eachGpEntry["Value"].ToString();
                }
                else
                {
                    gpobj.State = eachGpEntry["State"].ToString();
                }
                policyConfigObj.Add(gpobj);
            }
            return policyConfigObj;
        }

        #endregion
    }
}
