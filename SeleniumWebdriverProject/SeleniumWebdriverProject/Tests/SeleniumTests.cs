using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace SeleniumWebdriverProject.Tests
{
    public class SeleniumTests
    {
        [Test]
        public void FirstSeleniumTests()
        {
            IWebDriver driver = new EdgeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/");

            Assert.That(driver.Title, Is.EqualTo("Selenium"));

            driver.Quit();
        }
    }
}
