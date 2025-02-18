﻿using OpenQA.Selenium;

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
        IWebElement linkEmployeeDetails => driver.FindElement(By.LinkText("Employee Details"));
        IWebElement linkManageUsers => driver.FindElement(By.LinkText("Manage Users"));
        IWebElement linkLogOff => driver.FindElement(By.LinkText("Log off"));

        //public void ClickLogin()
        //{
        //    SeleniumCustomMethods.ClickElement(loginLink);
        //}

        public void ClickLogin()
        {
            loginLink.ClickElement();
        }

        //public void Login(string username, string password)
        //{
        //    SeleniumCustomMethods.EnterText(textUsername, username);
        //    SeleniumCustomMethods.EnterText(textPassword, password);
        //    SeleniumCustomMethods.Click(btnLogin);
        //}

        public void Login(string username, string password)
        {
            textUsername.EnterText(username);
            textPassword.EnterText(password);
            btnLogin.SubmitElement();
        }

        public (bool employeeDeatils, bool manageUsers) IsLoggedIn()
        {
            return (linkEmployeeDetails.Displayed, linkManageUsers.Displayed);
        }
    }
}
