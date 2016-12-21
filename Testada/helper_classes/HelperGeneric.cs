using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Testada
{
    class HelperGeneric
    {

        public static void LoadPage(TestManager tm, string urlToGoTo)
        {
            try
            {
                tm.cWebDriver.Navigate().GoToUrl(urlToGoTo);

                //verify we landed at the page we wanted to go to
                var actualUrl = new Uri(tm.cWebDriver.Url);
                var targetUrl = new Uri(urlToGoTo);

                if (actualUrl.AbsolutePath == targetUrl.AbsolutePath)
                {
                    tm.log("Navigation to " + urlToGoTo + " successful");
                }
                else
                {
                    tm.log("Navigation to " + urlToGoTo + " failed", 2);
                }

            }
            catch
            {
                tm.log("Error while navigating to " + urlToGoTo, 3);
            }
        }

        public static bool HasClass(IWebElement el, string className)
        {
            return el.GetAttribute("class").Split(' ').Contains(className);
        }

        public static void WaitForAjax(TestManager tm)
        {
            try
            {
                //wait for any debounce time to expire
                Thread.Sleep(1000);

                //tm.log("Waiting for ajax request to complete",1);

                while (true) // Handle timeout somewhere
                {
                    var ajaxIsComplete = (bool)(tm.cWebDriver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0");
                    if (ajaxIsComplete)
                    {
                        //tm.log("Ajax request completed");
                        break;
                    }
                    Thread.Sleep(1000);
                }
            }
            catch
            {
                tm.log("Error while waiting for ajax request", 2);
            }

        }

        public static string Screenshot(TestManager tm, string name = "screenshot")
        {
            string fileName = "";
            try
            {
                fileName = tm.getTestName() + "-" + name + ".png";
                string fullScreenshotPath = "screenshots/" + fileName;

                tm.cWebDriver.GetScreenshot().SaveAsFile(fullScreenshotPath, ImageFormat.Png);

                tm.addScreenshot(fullScreenshotPath);
            }
            catch
            {
            }


            return fileName;
        }

        public static bool ConfirmUrl(TestManager tm, string expectedUrlPath, int errorLevel = 2)
        {
            try
            {
                var actualUrl = new Uri(tm.cWebDriver.Url);

                if (actualUrl.AbsolutePath == expectedUrlPath)
                {
                    tm.log("URL match - " + expectedUrlPath);
                    return true;
                }
                else
                {
                    tm.log("URL does not match. Actual: " + actualUrl.AbsolutePath + ", Expected: " + expectedUrlPath, errorLevel);
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static string GetUrlHash(TestManager tm)
        {

            string hash = (string)tm.cWebDriver.ExecuteScript("return window.location.hash.substr(1)");

            return hash;

        }

        public static void SetUrlHash(TestManager tm, string value)
        {

            tm.cWebDriver.ExecuteScript("window.location.hash = " + value);

            HelperGeneric.WaitForAjax(tm);

        }

        public static bool AssertString(TestManager tm, string a, string b, string msg = "", int logLevel = 2)
        {
            msg += " | Expected: " + b + ", Actual: " + a;

            if (a != b)
            {
                tm.log("AssertString failed: " + msg, logLevel);
                return false;
            }
            else
            {
                tm.log("AssertString: " + msg);
                return true;
            }
        }

        public static bool AssertInt(TestManager tm, int a, int b, string msg = "", int logLevel = 2)
        {
            msg += " | Expected: " + b.ToString() + ", Actual: " + a.ToString();

            if (a != b)
            {
                tm.log("AssertInt failed: " + msg, logLevel);
                return false;
            }
            else
            {
                tm.log("AssertInt: " + msg);
                return true;
            }
        }

        public static bool AssertDecimal(TestManager tm, decimal a, decimal b, int places = 2, string msg = "", int logLevel = 2)
        {
            msg += " | Expected: " + b.ToString() + ", Actual: " + a.ToString();

            a = Math.Round(a, places);
            b = Math.Round(b, places);

            if (a != b)
            {
                tm.log("AssertDecimal failed: " + msg, logLevel);
                return false;
            }
            else
            {
                tm.log("AssertDecimal: " + msg);
                return true;
            }
        }

        public static bool AssertBool(TestManager tm, bool a, bool b, string msg, int logLevel = 2)
        {
            msg += " | Expected: " + b.ToString() + ", Actual: " + a.ToString();

            if (a != b)
            {
                tm.log("AssertBool failed: " + msg, logLevel);
                return false;
            }
            else
            {
                tm.log("AssertBool: " + msg);
                return true;
            }
        }
    }
}
