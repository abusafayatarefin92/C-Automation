using OpenQA.Selenium;
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
    }
}
