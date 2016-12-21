using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Deployment.Application;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Globalization;
using System.Threading;

namespace Testada
{
    public partial class Form1 : Form
    {
        private Thread testQueueThread;
        private List<string> TestsToRun = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.TopMost = true;

            //update settings values
            //SMTP
            txtSmtpServer.Text = HelperSettings.get("smtpServer");
            numSmtpPort.Value = HelperSettings.get("smtpPort");
            txtSmtpFrom.Text = HelperSettings.get("smtpFrom"); 
            chkSmtpAuthentication.Checked = HelperSettings.get("smtpAuthenticate"); 
            txtSmtpUsername.Text = HelperSettings.get("smtpUsername"); 
            txtSmtpPassword.Text = HelperSettings.get("smtpPassword");
            chkEmailResults.Checked = HelperSettings.get("chkEmailResults");
            txtEmailResultsTo.Text = HelperSettings.get("testEmailResultsTo");
            //load test definition
            dynamic testsDefinition = JsonConvert.DeserializeObject(File.ReadAllText("tests/TestsDefinition.json"));
            

            //generate tests list box
            lsvTestSuite.Columns.Add("Name", 150);
            lsvTestSuite.Columns.Add("Detail", 200);
            int testCount = 0;
            for (int i=0; i<testsDefinition.tests.Count; i++) 
            {
                lsvTestSuite.Groups.Add(new ListViewGroup(testsDefinition.tests[i].suite.ToString(), HorizontalAlignment.Left));

                for (int j=0; j< testsDefinition.tests[i].tests.Count; j++)
                {
                    string[] columns = new string[] { testsDefinition.tests[i].tests[j].name.ToString(), testsDefinition.tests[i].tests[j]["class"].ToString() };
                    lsvTestSuite.Items.Add(new ListViewItem(columns));
                    lsvTestSuite.Items[testCount].Group = lsvTestSuite.Groups[i];
                    testCount++;
                }
                
            }

            
        }
        
        private void lsvTestSuite_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lsvTestSuite.SelectedItems.Count > 0)
            {
                var selectedItem = (dynamic)lsvTestSuite.SelectedItems[0];
                btnRunSelected.Text = "Run Selected Tests";
                
                btnRunSelected.Visible = true;
            }
            else
            {
                btnRunSelected.Visible = false;
            }
        }

        private void btnRunSelected_Click(object sender, EventArgs e)
        {

            TestsToRun.Clear();

            if (lsvTestSuite.SelectedItems.Count > 0)
            {
                for (int i = 0; i < lsvTestSuite.SelectedItems.Count; i++)
                {
                    var selectedItem = (dynamic)lsvTestSuite.SelectedItems[i];
                    string className = selectedItem.SubItems[1].Text.Trim();

                    TestsToRun.Add(className);
                    
                }
                    
            }

            this.testQueueThread = new Thread(new ThreadStart(testQueue));
            this.testQueueThread.Start();
            tabControl1.SelectedTab = tabPage4;
        }

        private void testQueue()
        {
            ToggleRunButton(false);
            foreach (string className in TestsToRun)
            {
                //while every test but the last one runs
                while (Globals.testInProgress == true)
                {
                    Thread.Sleep(2);
                }
                runTest(className);
                Thread.Sleep(2);
            }

            //while last test runs
            while (Globals.testInProgress == true)
            {
                Thread.Sleep(2);
            }
            PostUiMessage("All tests finished");
            ToggleRunButton(true);
        }

        private void runTest(string className)
        {
            try
            {
                Assembly assembly = Assembly.Load("Testada");
                Type t = assembly.GetType("Testada.tests." + className);
                var myObj = Activator.CreateInstance(t, BindingFlags.OptionalParamBinding | BindingFlags.InvokeMethod | BindingFlags.CreateInstance, null, new object[] { true, Type.Missing }, CultureInfo.InvariantCulture);
                Globals.testInProgress = true;
                PostUiMessage("Running " + className);
            }
            catch
            {
                PostUiMessage(className + " could not be found. Make sure you have created a C# file named '" + className + ".cs' in your project and that the class name insde of it is " + className + " and that it has a default constructor method with two optional parameters (bool run=true, string testTitle=\"" + className + "\")");
            }
        }

        public void PostUiMessage(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(PostUiMessage), new object[] { value });
                return;
            }
            tssLabel.Text = value;
        }

        public void ToggleRunButton(bool enabled)
        {

            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(ToggleRunButton), new object[] { enabled });
                return;
            }
            btnRunSelected.Enabled = enabled;
        }

        public void PostToLog(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(PostToLog), new object[] { value });
                return;
            }
            txtLog.AppendText(value);
        }
        
        //get application version
        public Version AssemblyVersion
        {
            get
            {
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    var appDeploy = ApplicationDeployment.CurrentDeployment;
                    return ApplicationDeployment.CurrentDeployment.CurrentVersion;
                }
                else
                {
                    return new Version(Application.ProductVersion);
                }

            }
        }



        //settings modifiers
        //smtp
        private void txtSmtpServer_TextChanged(object sender, EventArgs e)
        {
            HelperSettings.set("smtpServer", txtSmtpServer.Text);
        }

        private void numSmtpPort_ValueChanged(object sender, EventArgs e)
        {
            HelperSettings.set("smtpPort", numSmtpPort.Value);
        }

        private void txtSmtpFrom_TextChanged(object sender, EventArgs e)
        {
            HelperSettings.set("smtpFrom", txtSmtpFrom.Text);
        }

        private void chkSmtpAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            HelperSettings.set("smtpAuthenticate", chkSmtpAuthentication.Checked);
        }

        private void txtSmtpUsername_TextChanged(object sender, EventArgs e)
        {
            HelperSettings.set("smtpUsername", txtSmtpUsername.Text);
        }

        private void txtSmtpPassword_TextChanged(object sender, EventArgs e)
        {
            HelperSettings.set("smtpPassword", txtSmtpPassword.Text);
        }
        
        private void chkEmailResults_CheckedChanged(object sender, EventArgs e)
        {
            HelperSettings.set("chkEmailResults", chkEmailResults.Checked);
        }

        private void txtEmailResultsTo_TextChanged(object sender, EventArgs e)
        {
            HelperSettings.set("testEmailResultsTo", txtEmailResultsTo.Text);
        }

        private void trbCatchStepsLogLevel_ValueChanged(object sender, EventArgs e)
        {
            HelperSettings.set("catchStepsLogLevel", trbCatchStepsLogLevel.Value);
        }

        private void testProgressTimer_Tick(object sender, EventArgs e)
        {
            toolStripProgressBar1.Visible = Globals.testInProgress;
            toolStripProgressBar1.Value = Decimal.ToInt32(Globals.testProgress);
        }
        
        
    }
}
