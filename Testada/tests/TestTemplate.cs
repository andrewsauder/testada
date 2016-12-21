using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Testada.test_helpers;

namespace Testada.tests
{
    class TestTemplate
    {
        public TestManager tm;

        public TestTemplate(bool run = true, string testTitle = "Test template")
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

            //add as many steps as you want
            tm.addTestStep(() =>
            {
                //perform actions here
            }, "Example step 1");

            tm.addTestStep(() =>
            {
                //perform actions here
            }, "Example step 2");

        }


        public void cleanupSteps()
        {
            //add as many clean up steps as you want. these run at the end of the test regardless of whether the test stopped or not
            tm.addCleanupStep(() =>
            {
                //perform clean up actions here (remove an entry from the database, reset values, etc)
            });
        }


    }
}
