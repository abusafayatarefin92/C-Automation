using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace DotNetSelenium
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver driver = new EdgeDriver();

            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
            IWebElement webElement = driver.FindElement(By.XPath("(//textarea[@id='APjFqb'])[1]"));
            webElement.SendKeys("Selenium");
            webElement.SendKeys(Keys.Return);
        }

        [Test]
        public void EAWebSiteTest()
        {
            IWebDriver driver = new EdgeDriver();

            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();

            IWebElement loginLink = driver.FindElement(By.XPath("(//a[normalize-space()='Login'])[1]"));
            loginLink.Click();

            IWebElement txtUserName = driver.FindElement(By.XPath("(//input[@id='UserName'])[1]"));
            txtUserName.SendKeys("admin");
            IWebElement txtUserPassword = driver.FindElement(By.XPath("(//input[@id='Password'])[1]"));
            txtUserPassword.SendKeys("password");
            IWebElement btnLogIn = driver.FindElement(By.XPath("(//input[@id='loginIn'])[1]"));
            btnLogIn.Submit();
        }
    }
}