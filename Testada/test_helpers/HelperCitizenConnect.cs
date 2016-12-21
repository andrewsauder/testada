using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Testada.test_helpers
{
    class HelperCitizenConnect
    {

        public static void deleteSavedCreditCards( TestManager tm, string username )
        {
            db dbc = new db(HelperSettings.get("dbOnlinePayments"));
            string q = "UPDATE [member] SET [public_utilities_customer_id] = NULL,[landfill_customer_id] = NULL,[taxes_customer_id] = NULL,[oakland_wst_customer_id] = NULL WHERE username = '"+username+"'";
            dbc.write(q);
        }

        public static void openPaymentForm( TestManager tm )
        {
            try
            {
                //open payment form
                var proceedToPaymentButton = tm.cWebDriver.FindElementById("proceedToCheckout");
                proceedToPaymentButton.Click();

                var paymentForm = tm.cWebDriver.FindElementById("payment-form");

                Thread.Sleep(1000);

                if (!proceedToPaymentButton.Displayed && paymentForm.Displayed)
                {
                    tm.log("Proceed to payment button works");
                }
                else
                {
                    tm.log("Proceed to payment button failed", 2);
                }
            }
            catch
            {
                tm.log("openPaymentForm", 3);
            }
            
        }

        public static void fillOutNewCreditCard( TestManager tm )
        {
            try
            {
                var newCreditCardRadio = tm.cWebDriver.FindElementByCssSelector("#payment-form input[name='method'][value='new_cc']");
                var newCreditForm = tm.cWebDriver.FindElementByClassName("new-credit-container");

                if (newCreditCardRadio.Selected && !newCreditForm.Displayed)
                {
                    tm.log("New credit form not displayed on opening payment form but should be!", 2);
                }

                //activate new credit card form
                newCreditCardRadio.Click();
                if (!newCreditForm.Displayed)
                {
                    tm.log("New credit form not displayed after choosing new credit card method!", 2);
                }

                //fill out new credit card form
                var fname_cc = tm.cWebDriver.FindElementById("fname_cc");
                var lname_cc = tm.cWebDriver.FindElementById("lname_cc");
                var ccnum = tm.cWebDriver.FindElementById("ccnum");
                var cardid = tm.cWebDriver.FindElementById("cardid");

                fname_cc.SendKeys("Test");
                lname_cc.SendKeys("McTester");
                ccnum.SendKeys("4444333322221111");
                cardid.SendKeys("999");

            }
            catch
            {
                tm.log("fillOutNewCreditCard", 3);
            }
        }

        public static void submitPaymentForm( TestManager tm )
        {
            try
            {
                var payNowButton = tm.cWebDriver.FindElementById("payment-submit");
                payNowButton.Click();

                if (HelperGeneric.HasClass(payNowButton, "loading"))
                {
                    tm.log("Payment form processing");
                }
                else
                {
                    tm.log("An error occured while processing payment form", 2);
                }
            }
            catch
            {
                tm.log("submitPaymentForm", 3);
            }
            

        }




        public static void openAddAccountPopout( TestManager tm, string type="taxes")
        {
            try
            {
                string addBtnClassName = "";
                string popoutClassName = "";

                if (type=="taxes")
                {
                    addBtnClassName = "addTaxAccount";
                    popoutClassName = "addaccount-tax-popout";
                }
                else if(type=="public_utilities")
                {
                    addBtnClassName = "addDPUAccount";
                    popoutClassName = "addaccount-public_utilities-popout";
                }
                else if (type == "landfill")
                {
                    addBtnClassName = "addTrashAccount";
                    popoutClassName = "addaccount-landfill-popout";
                }


                // Get the page elements
                var addTaxAccountBtn = tm.cWebDriver.FindElementByClassName(addBtnClassName);

                // and click the add button
                addTaxAccountBtn.Click();

                //wait for the animation to finish?
                Thread.Sleep(1000);

                //addaccount-tax-popout
                var popout = tm.cWebDriver.FindElementByClassName(popoutClassName);

                if (popout.Displayed)
                {
                    tm.log("Add account popout is visible!");
                }
                else
                {
                    tm.log("Add account popout is NOT visible!", 2);
                }

            }
            catch
            {
                tm.log("Element not found", 3);
            }
        }

        public static void addAccount( TestManager tm, string accountNumberToAdd, string type="taxes", string numberInUrlOfAccountIfDifferent = "")
        {
            try
            {
                //set up variable data types
                string accountFieldSelector = "";
                string addButtonClassName = "";
                string expectedUrlPath = "";

                if (type == "taxes")
                {
                    accountFieldSelector = ".addaccount-tax-popout input[name='account']";
                    addButtonClassName = "postAddTaxAccount";
                    expectedUrlPath = "/public_users/payments/taxes/"+ numberInUrlOfAccountIfDifferent;
                }
                else if (type == "public_utilities")
                {
                    accountFieldSelector = ".addaccount-public_utilities-popout input[name='account']";
                    addButtonClassName = "postAddDPUAccount";
                    expectedUrlPath = "/public_users/payments/public_utilities/" + accountNumberToAdd;
                }
                else if (type == "landfill")
                {
                    accountFieldSelector = ".addaccount-landfill-popout input[name='sticker']";
                    addButtonClassName = "postAddTrashAccount";
                    expectedUrlPath = "/public_users/payments/landfill/" + numberInUrlOfAccountIfDifferent;
                }
                
                // Get the page elements
                var enterAccountField = tm.cWebDriver.FindElementByCssSelector(accountFieldSelector);

                // and click the login button
                enterAccountField.SendKeys(accountNumberToAdd);

                //addaccount-tax-popout
                var addButton = tm.cWebDriver.FindElementByClassName(addButtonClassName);

                // and click the login button
                addButton.Click();

                HelperGeneric.WaitForAjax(tm);

                //check if the account detail page loaded
                var actualUrl = new Uri(tm.cWebDriver.Url);

                if (actualUrl.AbsolutePath == expectedUrlPath)
                {
                    tm.log("Redirect to account successful");
                }
                else
                {
                    tm.log("Redirect to account failed Actual"+ actualUrl.AbsolutePath+", Expected: "+expectedUrlPath, 2);
                }


                /*
                    var pageTitle = tm.cWebDriver.FindElementByCssSelector("#publicUsersPage h2").Text;

                var accountNumberText = tm.cWebDriver.FindElementByClassName("account").Text;

                if (pageTitle == "Tax Account Detail" && accountNumberText == "Account Number " + accountNumberToAdd)
                {
                    tm.log("Redirect to account successful");
                }
                else
                {
                    tm.log("Redirect to account failed", 2);
                }
                */
            }
            catch
            {
                tm.log("Fatal error while adding tax account", 3);
            }
        }


        public static void removeAccount( TestManager tm, string numberInUrlOfAccount, string type )
        {
            try
            {
                //set up variable data types
                string dataType = "";
                string urlQualifier = "";

                if (type == "taxes")
                {
                    dataType = "taxes";
                    urlQualifier = "taxes";
                }
                else if (type == "public_utilities")
                {
                    dataType = "public_utilities";
                    urlQualifier = "public_utilities";
                }
                else if (type == "landfill")
                {
                    dataType = "landfill";
                    urlQualifier = "landfill";
                }


                // Get the page elements
                var removeButton = tm.cWebDriver.FindElementByCssSelector(".remove-account[data-account='" + numberInUrlOfAccount + "'][data-type='"+ dataType + "']");
                removeButton.Click();

                HelperGeneric.WaitForAjax(tm);

                //verify the account has been removed
                try
                {
                    var linkToAccount = tm.cWebDriver.FindElementByCssSelector("a[href='/public_users/payments/"+ urlQualifier + "/" + numberInUrlOfAccount + "']");
                    tm.log("Account still present", 2);
                }
                catch
                {
                    tm.log("Account removed");
                }


            }
            catch
            {
                tm.log("Error while removing account", 3);
            }
        }

    }
}
