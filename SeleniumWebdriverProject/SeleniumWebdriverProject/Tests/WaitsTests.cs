using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebdriverProject.Tests
{
    class WaitsTests
    {
        [Test]
        public void ImplicitWaitTests()
        {
            IWebDriver driver = new EdgeDriver();

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var textArea = driver.FindElement(By.Name("my-textarea"));
            textArea.SendKeys(Guid.NewGuid().ToString());

            driver.Quit();
        }

        [Test]
        public void ExplicitWaitTests()
        {
            IWebDriver driver = new EdgeDriver();

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var condition1 = wait.Until(e => e.Title == "Web form");
            var condition2 = wait.Until(e => e.FindElement(By.Name("my-textarea")));
            var condition3 = wait.Until(e => e.FindElement(By.Name("my-textarea")).Displayed);

            var textArea = driver.FindElement(By.Name("my-textarea"));
            textArea.SendKeys(Guid.NewGuid().ToString());

            driver.Quit();
        }

        [Test]
        public void FluentWaitTests()
        {
            IWebDriver driver = new EdgeDriver();

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromSeconds(1)
            };

            wait.IgnoreExceptionTypes(typeof(HttpRequestException));

            var condition1 = wait.Until(e => e.Title == "Web form");
            var condition2 = wait.Until(e => e.FindElement(By.Name("my-textarea")));
            var condition3 = wait.Until(e => e.FindElement(By.Name("my-textarea")).Displayed);

            var textArea = driver.FindElement(By.Name("my-textarea"));
            textArea.SendKeys(Guid.NewGuid().ToString());

            driver.Quit();
        }
    }
}
