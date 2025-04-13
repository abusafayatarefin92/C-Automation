using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using PageObjects.PageObjects;

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

        [SetUp]
        public void SetUp()
        {
            Driver = new EdgeDriver();

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            WebForm = new WebFormPages(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
