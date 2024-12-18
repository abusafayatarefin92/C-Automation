using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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

        public static void Multiselect(IWebDriver driver, By locator, string[] texts)
        {
            SelectElement multiSelect = new SelectElement(driver.FindElement(locator));

            foreach (var item in texts)
            {
                multiSelect.SelectByText(item);
            }
        }

        public static List<string> GetAllSelectedLists(IWebDriver driver, By locator)
        {
            List<string> options = new List<string>();
            SelectElement multiSelect = new SelectElement(driver.FindElement(locator));

            IList<IWebElement> selectedOption = multiSelect.AllSelectedOptions;

            foreach (IWebElement option in selectedOption)
            {
                options.Add(option.Text);
            }

            return options;
        }
    }
}
