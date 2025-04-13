using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace SeleniumWebdriverProject.Tests
{
    class FindElementTests
    {
        [Test]
        public void LocatorsTests()
        {
            var results = new List<string>();

            IWebDriver driver = new EdgeDriver();

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.selenium.dev/");

            Assert.That(driver.Title, Is.EqualTo("Selenium"));

            //Find element
            var firstH2 = driver.FindElement(By.XPath("//h2"));
            results.Add($"FindElement: {firstH2.Text}");

            //Find Elements
            var h2Collection = driver.FindElements(By.XPath("//h2"));
            foreach (var h2 in h2Collection)
            {
                results.Add($"FindElement: {h2.Text}");
            }

            //Evaluate a subset of the DOM
            var parentElement = driver.FindElement(By.CssSelector("div[id='main_navbar']"));
            var links = parentElement.FindElements(By.TagName("a"));
            foreach (var link in links)
            {
                var result = link.Text;
                if (!string.IsNullOrEmpty(result))
                {
                    results.Add($"links: {link.Text}");
                }
            }

            File.WriteAllLines("results", results);

            driver.Quit();
        }
    }
}
