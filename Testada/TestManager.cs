using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;

namespace Testada
{
    class TestManager
    {
        private Thread testingThread;
        private List<Action> testSteps = new List<Action>();
        private List<string> testStepNames = new List<string>();

        private List<Action> cleanupSteps = new List<Action>();

        private List<string> testScreenshots = new List<string>();

        private string testName = "";
        private int worstStatusReported = 0;

        private List<string> msgs = new List<string>();
        volatile bool stopRunningTest = false;
        public ChromeDriver cWebDriver;

        public TestManager(string testNameToRun)
        {
            //reset all variables for new test
            this.msgs = new List<string>();
            this.testSteps = new List<Action>();
            this.testName = testNameToRun;
        }


        public string getTestName()
        {
            return this.testName;
        }

        public int addTestStep(Action newStep, string name = "")
        {
            this.testSteps.Add(newStep);
            this.testStepNames.Add(name);

            return this.testSteps.Count - 1;
        }


        public int addCleanupStep(Action newStep, string name = "")
        {
            this.cleanupSteps.Add(newStep);

            return this.cleanupSteps.Count - 1;
        }

        public int addScreenshot(string filePath)
        {
            this.testScreenshots.Add(filePath);

            return this.testScreenshots.Count - 1;

        }


        public void startTest()
        {

            Globals.testInProgress = true;

            this.addTestStep(() =>
            {
                this.endTest(0);

            }, "End Test After All Steps");

            //log the start of the new test
            this.log("Start test " + this.testName);

            //create the thread start
            // Create the thread object, passing in the Alpha.Beta method
            // via a ThreadStart delegate. This does not start the thread.
            this.testingThread = new Thread(new ThreadStart(runTestThread));

            this.testingThread.Start();

        }

        public void runTestThread()
        {
            using (this.cWebDriver = new ChromeDriver())
            {
                //run test steps
                int i = 0;
                foreach (var action in this.testSteps)
                {
                    Globals.testProgress = Math.Round(((decimal)i / (decimal)this.testSteps.Count) * 100);

                    //log the name of the step
                    this.log("Step Initialized - " + this.testStepNames[i], 1);

                    // And execute the method
                    try
                    {
                        action.Invoke();
                    }
                    catch
                    {
                        this.log("Step " + this.testStepNames[i] + " failed", HelperSettings.get("catchStepsLogLevel"));
                    }


                    if (stopRunningTest)
                    {
                        break;
                    }

                    this.log("Step Finished - " + this.testStepNames[i] + System.Environment.NewLine + System.Environment.NewLine, 1);

                    i++;
                }


                //cleanup
                //log that we're in cleanup
                this.log("Cleanup initialized", 1);

                //run cleanup steps
                i = 0;
                foreach (var action in this.cleanupSteps)
                {
                    try
                    {
                        this.log("Executing cleanup step " + i.ToString(), 1);
                        // And execute the method
                        action.Invoke();
                    }
                    catch
                    {
                        this.log("Cleanup step " + i.ToString() + " failed", 2);
                    }

                    i++;
                }

                this.log("Cleanup completed");

            }
            Globals.testInProgress = false;
        }


        public void endTest(int status)
        {
            if (status == 3)
            {
                HelperGeneric.Screenshot(this, "endTest");
            }

            //prevent any remaining test steps from executing
            this.stopRunningTest = true;

            //log that the test has ended
            this.log("Test " + this.testName + " ended", status, false);

            string emailLog = "";
            //write log to file
            //long term this will be different (in a database? only as an email? something other than one file that will be overwritten)
            TextWriter tw = new StreamWriter(this.testName + "-log.txt");

            foreach (String s in msgs)
            {
                tw.WriteLine(s);
                emailLog += s + System.Environment.NewLine;
            }
            tw.Close();


            //email the log
            HelperEmail.send(HelperSettings.get("testEmailResultsTo"), "Testata: " + this.testName + " [" + this.statusIntToString(worstStatusReported) + "]", emailLog, this.testScreenshots);
        }


        public void log(string message, int level = 0, bool endTestOn3 = true)
        {

            string logMessage = DateTime.UtcNow.ToString("yyyy-MM-dd HH\\:mm\\:ss") + " [" + statusIntToString(level) + "] " + message;

            Program.MainWindow.PostToLog(logMessage + Environment.NewLine);

            msgs.Add(logMessage);

            if (this.worstStatusReported < level && level > 1)
            {
                worstStatusReported = level;
            }

            //level 0=log, 1=notice, 2=warning, 3=fatal
            if (endTestOn3 && level == 3)
            {
                endTest(3);
            }
        }


        public string statusIntToString(int statusToConvert)
        {
            string statusText = "Message";

            if (statusToConvert == 0)
            {
                statusText = "Success";
            }
            else if (statusToConvert == 1)
            {
                statusText = "Notice";
            }
            else if (statusToConvert == 2)
            {
                statusText = "Warning";
            }
            else if (statusToConvert == 3)
            {
                statusText = "Fatal";
            }

            return statusText;
        }

    }
}
