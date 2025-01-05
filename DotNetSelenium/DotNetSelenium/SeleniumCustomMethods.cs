using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DotNetSelenium
{
    public static class SeleniumCustomMethods
    {
        public static void ClickElement(this IWebElement locator)
        {
            locator.Click();
        }

        public static void SubmitElement(this IWebElement locator)
        {
            locator.Submit();
        }

        public static void SendKeys(this IWebElement locator)
        {
            locator.SendKeys("Selenium");
        }

        public static void ReturnElement(this IWebElement locator)
        {
            locator.SendKeys(Keys.Return);
        }

        //public static void EnterText(IWebElement locator, string text)
        //{
        //    locator.Clear();
        //    locator.SendKeys(text);
        //}

        public static void EnterText(this IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }

        public static void DropDownByText(this IWebElement locator, string text)
        {
            SelectElement selectDropdown = new SelectElement(locator);
            selectDropdown.SelectByText(text);
        }

        public static void DropDownByValue(this IWebElement locator, string text)
        {
            SelectElement selectDropdown = new SelectElement(locator);
            selectDropdown.SelectByValue(text);
        }

        public static void WaitElement(this IWebDriver driver, int number)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(number);
        }

        public static void Multiselect(this IWebElement locator, string[] texts)
        {
            SelectElement multiSelect = new SelectElement(locator);

            foreach (var item in texts)
            {
                multiSelect.SelectByText(item);
            }
        }

        public static List<string> GetAllSelectedLists(this IWebElement locator)
        {
            List<string> options = new List<string>();
            SelectElement multiSelect = new SelectElement(locator);

            IList<IWebElement> selectedOption = multiSelect.AllSelectedOptions;

            foreach (IWebElement option in selectedOption)
            {
                options.Add(option.Text);
            }

            return options;
        }
    }
}
