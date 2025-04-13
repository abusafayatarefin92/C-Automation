using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace SeleniumWebdriverProject.Tests
{
    internal class LocatorsTest
    {
        [Test]
        public void LocatorsTests()
        {
            IWebDriver driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.selenium.dev/");
            Assert.That(driver.Title, Is.EqualTo("Selenium"));

            var xPathValidator = driver.FindElement(By.XPath("(//a[@href='/documentation'])[1]")).Displayed;
            Assert.That(xPathValidator, Is.EqualTo(true));

            //var classNameValidator = driver.FindElement(By.ClassName("DocSearch")).Displayed;
            //Assert.That(classNameValidator, Is.EqualTo(true));

            //var cssSelectorValidator = driver.FindElement(By.CssSelector(".DocSearch")).Displayed;
            //Assert.That(cssSelectorValidator, Is.EqualTo(true));

            //var idValidator = driver.FindElement(By.Id("selenium_logo")).Displayed;
            //Assert.That(idValidator, Is.EqualTo(true));

            //var nameValidator = driver.FindElement(By.Name("submit")).Displayed;
            //Assert.That(nameValidator, Is.EqualTo(true));

            //var linkTextValidator = driver.FindElement(By.LinkText("Documentation")).Displayed;
            //Assert.That(linkTextValidator, Is.EqualTo(true));

            //var partialLinkTextValidator = driver.FindElement(By.PartialLinkText("Doc")).Displayed;
            //Assert.That(partialLinkTextValidator, Is.EqualTo(true));

            //var tagTextValidator = driver.FindElement(By.TagName("nav")).Displayed;
            //Assert.That(tagTextValidator, Is.EqualTo(true));


        }
    }
}
