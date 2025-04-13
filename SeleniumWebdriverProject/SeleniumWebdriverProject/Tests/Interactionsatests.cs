using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebdriverProject.Tests
{
    class Interactionsatests
    {
        [Test]
        public void InteractionsTests()
        {
            var results = new List<string>();

            IWebDriver driver = new EdgeDriver();

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

            //check-box
            driver.FindElement(By.Id("my-check-2")).Click();
            Thread.Sleep(3000);

            //radio button
            driver.FindElement(By.Id("my-radio-2")).Click();
            Thread.Sleep(3000);

            //right click
            var actions = new Actions(driver);
            var button = driver.FindElement(By.TagName("button"));
            actions.ContextClick(button).Perform();
            Thread.Sleep(3000);

            //double click
            var checkBox1 = driver.FindElement(By.Id("my-check-1"));
            actions.DoubleClick(checkBox1).Perform();
            Thread.Sleep(3000);

            //sendkeys input
            driver.FindElement(By.Id("my-text-id")).SendKeys(Guid.NewGuid().ToString());
            Thread.Sleep(3000);

            //text area
            var textArea = driver.FindElement(By.Name("my-textarea"));
            textArea.SendKeys(Guid.NewGuid().ToString());
            Thread.Sleep(3000);

            //clear
            textArea.Clear();
            Thread.Sleep(3000);

            //select
            var selectElement = driver.FindElement(By.Name("my-select"));
            var select = new SelectElement(selectElement);

            select.SelectByText("One");
            Thread.Sleep(3000);
            select.SelectByValue("2");
            Thread.Sleep(3000);
            select.SelectByIndex(3);
            Thread.Sleep(3000);

            //upload
            var filePath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".txt";
            File.WriteAllText(filePath, Guid.NewGuid().ToString());
            driver.FindElement(By.Name("my-file")).SendKeys(filePath);
        }
    }
}
