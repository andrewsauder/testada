using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Testada.tests.test_helpers;

namespace Testada.tests
{
    class TestCitizenConnectLogin
    {
        public string baseUrl = "https://www.garrettcounty.org";
        public string username = "demo@garrettcounty.org";
        public string password = "demo123";
        public TestManager tm;

        public TestCitizenConnectLogin(bool run = true, string testTitle = "Citizen Connect Login")
        {

            this.tm = new TestManager(testTitle);

            this.steps();
            this.cleanupSteps();

            if (run)
            {
                this.tm.startTest();
            }

        }

        public TestManager useAsSubTest()
        {
            return this.tm;
        }

        public void steps()
        {

            tm.addTestStep(() =>
            {
                //delete any cookies we have so that we don't accidentially stay logged in
                tm.cWebDriver.Manage().Cookies.DeleteAllCookies();

                // Go to the home page
                tm.cWebDriver.Navigate().GoToUrl(baseUrl + "/public_users");

            }, "Open browser");

            tm.addTestStep(() =>
            {
                try
                {
                    // Get the page elements
                    var userNameField = tm.cWebDriver.FindElementById("gc-signin-username");
                    var userPasswordField = tm.cWebDriver.FindElementById("gc-signin-password");
                    var loginButton = tm.cWebDriver.FindElementById("gc-signin-button");

                    // Type user name and password
                    userNameField.SendKeys(this.username);
                    userPasswordField.SendKeys(this.password);

                    // and click the login button
                    loginButton.Click();

                    tm.log("Sign in submitted");
                }
                catch
                {
                    tm.log("Element not found on sign in form", 3);
                }
            }, "Login");

            tm.addTestStep(() =>
            {
                try
                {
                    var result = tm.cWebDriver.FindElementByCssSelector(".page-subtitle").Text;

                    HelperGeneric.AssertString(tm, result, "Signed in as " + this.username, "Login status");

                }
                catch
                {
                    tm.log("Page subtitle not found after log in form submitted", 3);
                }
            }, "Verify login success");


            tm.addTestStep(() =>
            {
                HelperGeneric.Screenshot(tm, "signin");
            }, "Take Screenshot");


        }


        public void cleanupSteps()
        {
            //tm.addCleanupStep(() =>
            //{
            //});
        }


    }
}
