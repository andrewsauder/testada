# Testada
Testada is a C# Visual Studio application designed to make C# Selenium testing easy for Selenium beginners. Once you've coded your test, it appears in a UI so you can select, run it, watch it, and get the test results by email and in the app.

Testada does not integrate with any build tools so it may not be the perfect solution for you if you want your tests to run automatically (right now you have to trigger the test). We created Testada to make it possible for new comers to Selenium to build tests quickly, and catch regression issues in complex internal web applications without having to learn everything in the entire universe of build automation or continuous integration.

We've included two of our actual tests in the repository for you to use as references.
* TestCitizenConnectLogin
* TestTaxes
  *  This test demonstrates how to use abstraction via a test helper class so that you can make small, reuseable methods that can be used in multiple tests
  * This test shows how to require and run another test when your test is started (in this case, we run the Login test so that the user is authenticated)

## Quick Start
1. Clone the reposititory and open the Visual Studio solution file (*Testada/Testada.sln*) in Visual Studio 2015 or newer.
2. Build the solution, start the application, and from the main screen of Testada, run one or more of the bundled tests.

## Writing your own test
1. All tests are saved under the *tests* directory and namespace. For the rest of this section, we are focused only on that folder.
2. Make a copy of the *TestTemplate.cs* file and rename the file with the name of your test (*ex: TestMySite*).  
3. Open *TestMySite.cs* and replace all references to *TestTemplate* with *TestMySite*. In the constructor function, change the default testTitle to be the title you want your test to use.
4. At this point you have a functional Testada test but it performs no actions. In the *steps()* method, add the steps that you want your test to perform.
5. Selenium web driver methods are available inside each step inside of the variable `tm.cWebDriver` 

## Adding custom tests to UI
After you've writen your own test, you must define it in *tests/TestsDefinition.json* so that the UI knows it exists.

Tests must belong to a suite for grouping. The two bundled tests belong to a suite named Citizen Connect. You can add an unlimited number of suites to *TestsDefinition.json* and each suit can contain an unlimited number of tests.

Example *TestsDefinition.json* file with two suites:
```json
{
  "tests": [
    {
      "suite": "My Internal App Test Suite",
      "tests": [
        {
          "name": "Login",
          "class": "TestLogin"
        }
      ]
    },
    {
      "suite": "My Public App Test Suite",
      "tests": [
        {
          "name": "Login",
          "class": "TestLogin"
        },
        {
          "name": "Password reset",
          "class": "TestPasswordReset"
        },
        {
          "name": "Create and edit page",
          "class": "TestPageCreateEdit"
        }
      ]
    }
  ]
}
```

