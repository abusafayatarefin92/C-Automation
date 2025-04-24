using OpenQA.Selenium;
using Utils.Reports;

namespace PageObjects.PageObjects
{
    public class WebFormPages
    {
        //locators
        IWebDriver driver;
        IWebElement TextArea => driver.FindElement(By.Name("my-textarea"));
        IWebElement SubmitButton => driver.FindElement(By.XPath("(//button[normalize-space()='Submit'])[1]"));

        public WebFormPages(IWebDriver driver)
        {
            this.driver = driver;
        }

        //methods
        public WebFormPages WriteToTextArea(string text)
        {
            ExtentReporting.LogInfo($"Write '{text}' to text area");

            TextArea.SendKeys(text);

            return this;
        }

        public TargetPage SubmitForm()
        {
            ExtentReporting.LogInfo("Click submit form button");

            SubmitButton.Click();

            return new TargetPage(driver);
        }
    }
}
