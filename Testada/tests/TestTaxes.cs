using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Drawing.Imaging;

using Testada.test_helpers;

namespace Testada.tests
{
    class TestTaxes
    {
        public string baseUrl = "https://www.garrettcounty.org";
        public string accountNumber = "17014226";
        public string numberInUrlOfAccount = "77624";
        public TestManager tm;

        public TestTaxes(bool run = true, string testTitle = "Citizen Connect Taxes")
        {

            //log into CitizenConnect
            TestCitizenConnectLogin tccl = new TestCitizenConnectLogin(false, testTitle);
            this.tm = tccl.useAsSubTest();

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

            //add tax account from dashboard
            tm.addTestStep(() =>
            {
                HelperCitizenConnect.openAddAccountPopout(tm, "taxes");
            }, "Click to add tax account from dashboard");
            
            tm.addTestStep(() =>
            {
                HelperCitizenConnect.addAccount(tm, accountNumber, "taxes", numberInUrlOfAccount);
            }, "Enter tax account from dashboard");


            //remove account from dashboard
            tm.addTestStep(() =>
            {
                HelperGeneric.LoadPage(tm, baseUrl + "/public_users/dashboard");
            }, "Return to dashboard to remove account");
            
            tm.addTestStep(() =>
            {
                HelperCitizenConnect.removeAccount(tm, numberInUrlOfAccount, "taxes");
            }, "Remove tax account from dashboard");
            



            //add tax account from taxes overview screen
            tm.addTestStep(() =>
            {
                HelperGeneric.LoadPage(tm, baseUrl + "/public_users/payments/taxes");
            }, "Go to taxes overview");

            tm.addTestStep(() =>
            {
                HelperCitizenConnect.openAddAccountPopout(tm, "taxes");
            }, "Click to add tax account from taxes overview");
            
            tm.addTestStep(() =>
            {
                HelperCitizenConnect.addAccount(tm, accountNumber, "taxes", numberInUrlOfAccount);
            }, "Enter tax account from taxes overview");




            //open payment form and fill it out
            tm.addTestStep(() =>
            {
                 //open payment form
                 HelperCitizenConnect.openPaymentForm(tm);

                //fill out payment form
                HelperCitizenConnect.fillOutNewCreditCard(tm);

                //submit payment form
                HelperCitizenConnect.submitPaymentForm(tm);

                //wait for payment for to complete and then load success page
                HelperGeneric.WaitForAjax(tm);

                //check if the successful transacation info is displayed on the detail page
                try
                {
                    var successfulTransaction = tm.cWebDriver.FindElementByClassName("successful-transaction");
                    var accountInfo = tm.cWebDriver.FindElementByCssSelector(".successful-transaction .account").Text;

                    if (accountInfo == "Account " + accountNumber)
                    {
                        HelperGeneric.Screenshot(tm, "payment-success");
                        tm.log("Transaction for account " + accountNumber + " successful!");
                    }
                    else
                    {
                        HelperGeneric.Screenshot(tm, "payment-failure");
                        tm.log("Transaction failure on account " + accountNumber, 2);
                    }

                }
                catch
                {
                    HelperGeneric.Screenshot( tm, "transaction-failure");
                    tm.log("Transaction failure", 3);
                }

            }, "openPaymentForm");





        }

        public void cleanupSteps()
        {
            
            //remove account from tax overview
            tm.addCleanupStep(() =>
            {
                HelperGeneric.LoadPage(tm, baseUrl + "/public_users/payments/taxes");
                HelperCitizenConnect.removeAccount(tm, numberInUrlOfAccount, "taxes");
            }, "Remove tax account from taxes overview");


            //delete the payment by hand from the database
            tm.addCleanupStep(() =>
            {
                db dbc = new db( HelperSettings.get("dbTax") );
                string q = "DELETE FROM [Trans] WHERE Account_No = '"+ accountNumber + "' AND[Year] = '2016-17' AND[Code] = 'P'; ";
                dbc.write(q);
            });
            
        }



    }
}
