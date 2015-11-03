using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

namespace UIAutomationHelperDemo.GenerateCode
{
    public class ASF
    {
        private const string Pattern1=@"
        <TestDefinition>
            <Tag Name=""Action"" Value=""Description"" />
            <TestDescription>Description</TestDescription>
            <TimeLimit>00:05:00</TimeLimit>
            <Function Name=""";

        private const string Pattern2=@"""
                      Args=""";

        private const string Pattern3=@"""
                      ModuleName=""UIAutomation""
                      ModuleBasePath=""Community"" />
            <ExecuteOn>DDC</ExecuteOn>
            <UserContext>Administrator</UserContext>
        </TestDefinition>
";
        private const string GPPatternEnd = @"""
                      ModuleName=""GroupPolicy""
                      ModuleBasePath=""TestAPI"" />
            <ExecuteOn>DDC</ExecuteOn>
            <UserContext>Administrator</UserContext>
        </TestDefinition>

";
        

        private static ASF _instance;

        public static ASF Instance
        {
            get {
                if (_instance == null)
                {
                    _instance = new ASF();
                }
                return _instance;
            }
        }

        public string GetButtonTD(AutomationElement UIElem, string ContainerName)
        {
            string FuncName = "Invoke-UIElementMethodByNameAndType_DLL";
            string FuncArgs="";
            if (UIElem.Current.Name != "")
            {
                FuncArgs = string.Format("-Type Button -FunctionName Invoke -ContainerName '{0}' -Name '{1}' -PatternName InvokePattern -Verbose -timeout 120", ContainerName, UIElem.Current.Name);
            }
            string codeStr = Pattern1 + FuncName + Pattern2 + FuncArgs + Pattern3;
            return codeStr;
        }

        public string GetCTXGPConfigTD(List<GPLib.GPPolicyEnty> gpPolicyConfig)
        {
            string codeHead="";
            string codeStr="";
            string FuncName = "Set-CtxGPConfiguration";
            List<string> gpNames = new List<string>();            
            foreach (GPLib.GPPolicyEnty each in gpPolicyConfig)
            {
                if (!gpNames.Contains(each.GpName))
                {
                    gpNames.Add(each.GpName);
                }
                string FuncArgs="";
                if (!string.IsNullOrEmpty(each.Value))
                {
                    FuncArgs = string.Format("-Name {0} -GPName {1}  -Context {2} -value '{3}' -Verbose", each.PolicyName, each.GpName, each.UserContext, each.Value);
                }
                if (!string.IsNullOrEmpty(each.State))
                {
                    FuncArgs = string.Format("-Name {0} -GPName {1}  -Context {2} -state {3} -Verbose", each.PolicyName, each.GpName, each.UserContext, each.State);
                }
                codeStr += Pattern1 + FuncName + Pattern2 + FuncArgs + GPPatternEnd;
            }
            codeHead = GetCTXTD(gpNames);
            codeStr = codeHead + codeStr;
            return codeStr;
        }

        public string GetCTXTD(List<string> gpPolicyNames)
        {
            string codeStr="";
            string FuncNameRemove = "Remove-CtxGroupPolicy";
            string FuncNameAdd = "new-CtxGroupPolicy";
            foreach (string each in gpPolicyNames)
            {
                string FuncArgs = string.Format("-Name {0} -Context All -Verbose",each);
                codeStr += Pattern1 + FuncNameRemove + Pattern2 + FuncArgs + GPPatternEnd;
                codeStr += Pattern1 + FuncNameAdd + Pattern2 + FuncArgs + GPPatternEnd;                
            }
            return codeStr;
        }


    }
}
