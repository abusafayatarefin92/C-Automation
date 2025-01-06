using DotNetSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace DotNetSelenium
{

    [TestFixture("admin", "password")]

    public class NUnitTestDemo
    {

#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        private IWebDriver _driver;
        private readonly string username;
        private readonly string password;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

        public NUnitTestDemo(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        [SetUp]
        public void SetUp()
        {
            _driver = new EdgeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        [TestCase("admin", "password")]
        public void EAWebSiteTest(string userName, string password1)
        {
            IWebElement webElement = _driver.FindElement(By.XPath("(//a[normalize-space()='Login'])[1]"));
            SeleniumCustomMethods.ClickElement(webElement);

            IWebElement webElement1 = _driver.FindElement(By.XPath("(//input[@id='UserName'])[1]"));
            SeleniumCustomMethods.EnterText(webElement1, userName);

            IWebElement webElement2 = _driver.FindElement(By.XPath("(//input[@id='Password'])[1]"));
            SeleniumCustomMethods.EnterText(webElement2, password1);

            IWebElement webElement3 = _driver.FindElement(By.XPath("(//input[@id='loginIn'])[1]"));
            SeleniumCustomMethods.ClickElement(webElement3);
        }

        [Test]
        [Category("smoke")]
        public void EAWebSiteTestWithPOM()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickLogin();
            loginPage.Login(username, password);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
