using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using PageObjects.PageObjects;
using NUnit.Framework.Interfaces;
using Utils.Reports;
using Utils.Common;

namespace Tests.Common
{
    internal class TestBase
    {
        protected IWebDriver Driver
        {
            get;
            private set;
        }

        protected WebFormPages WebForm
        {
            get;
            private set;
        }

        protected Browser Browser
        {
            get;
            private set;
        }

        [SetUp]
        public void SetUp()
        {
            ExtentReporting.CreateTest(TestContext.CurrentContext.Test.MethodName);

            Driver = new EdgeDriver();

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            WebForm = new WebFormPages(Driver);

            Browser = new Browser(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            EndTest();
            ExtentReporting.EndReporting();
            Driver.Quit();
        }

        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch(testStatus)
            {
                case TestStatus.Failed:
                    ExtentReporting.LogFail($"Test has failed {message}");
                    break;
                case TestStatus.Skipped:
                    ExtentReporting.LogInfo($"Test skipped {message}");
                    break;
                default:
                    break;
            }

            ExtentReporting.LogScreenShot("Ending test", Browser.GetScreenShot());
        }
    }
}
