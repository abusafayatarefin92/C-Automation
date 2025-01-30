using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Xunit;

namespace DataDrivenTesting
{
    public class DataDrivenLoginTest
    {
        [Xunit.Theory]
        [InlineData("admin", "password", true)]
        [InlineData("admin1", "password", false)]
        public void LoginPositive(String username, String password, Boolean expectedResult)
        {
            IWebDriver driver = new EdgeDriver();

            driver.Url = "http://eaapp.somee.com/";

            driver.Manage().Window.Maximize();

            driver.FindElement(By.XPath("(//a[normalize-space()='Login'])[1]")).Click();
            driver.FindElement(By.XPath("(//input[@id='UserName'])[1]")).SendKeys(username);
            driver.FindElement(By.XPath("(//input[@id='Password'])[1]")).SendKeys(password);
            driver.FindElement(By.XPath("(//input[@id='loginIn'])[1]")).Click();
        }
    }
}
