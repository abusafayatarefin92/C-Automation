﻿using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Xunit;

namespace DataDrivenTesting
{
#pragma warning disable xUnit1000 // Test classes must be public
    class LoginTest
#pragma warning restore xUnit1000 // Test classes must be public
    {
        [Fact]
        public void LoginWithUsername()
        {
            IWebDriver driver = new EdgeDriver();
            driver.Url = "http://eaapp.somee.com/";

            driver.Manage().Window.Maximize();

            driver.FindElement(By.XPath("(//a[normalize-space()='Login'])[1]")).Click();

            driver.FindElement(By.XPath("(//input[@id='UserName'])[1]")).SendKeys("admin");

            driver.FindElement(By.XPath("(//input[@id='Password'])[1]")).SendKeys("password");

            driver.FindElement(By.XPath("(//input[@id='loginIn'])[1]")).Click();

        }
    }
}
