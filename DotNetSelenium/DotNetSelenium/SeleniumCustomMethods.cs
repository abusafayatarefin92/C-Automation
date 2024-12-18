using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSelenium
{
    public class SeleniumCustomMethods
    {
        public static void Click(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Click();
        }

        public static void SendKeys(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).SendKeys("Selenium");
        }

        public static void Return(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).SendKeys(Keys.Return);
        }

        public static void EnterText(IWebDriver driver, By locator, string text)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
        }

        public static void DropDownByText(IWebDriver driver, By locator, string text)
        {
            SelectElement selectDropdown = new SelectElement(driver.FindElement(locator));
            selectDropdown.SelectByText(text);
        }

        public static void DropDownByValue(IWebDriver driver, By locator, string text)
        {
            SelectElement selectDropdown = new SelectElement(driver.FindElement(locator));
            selectDropdown.SelectByValue(text);
        }

        public static void Wait(IWebDriver driver, int number)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(number);
        }
    }
}
