using OpenQA.Selenium;

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
            TextArea.SendKeys(text);

            return this;
        }

        public TargetPage SubmitForm()
        {
            SubmitButton.Click();

            return new TargetPage(driver);
        }
    }
}
