using OpenQA.Selenium;

namespace DotNetSelenium.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement loginLink => driver.FindElement(By.XPath("(//a[normalize-space()='Login'])[1]"));
        IWebElement textUsername => driver.FindElement(By.XPath("(//input[@id='UserName'])[1]"));
        IWebElement textPassword => driver.FindElement(By.XPath("(//input[@id='Password'])[1]"));
        IWebElement btnLogin => driver.FindElement(By.XPath("(//input[@id='loginIn'])[1]"));

        public void ClickLogin()
        {
            loginLink.Click();
        }

        public void Login(string username, string password)
        {
            textUsername.SendKeys(username);
            textPassword.SendKeys(password);
            btnLogin.Click();
        }
    }
}
