using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace DotNetSelenium
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver driver = new EdgeDriver();

            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
            //IWebElement webElement = driver.FindElement(By.XPath("(//textarea[@id='APjFqb'])[1]"));
            //webElement.SendKeys("Selenium");
            SeleniumCustomMethods.EnterText(driver, By.XPath("(//textarea[@id='APjFqb'])[1]"), "Selenium");
            //webElement.SendKeys(Keys.Return);
            //SeleniumCustomMethods.SendKeys(driver, By.XPath("(//textarea[@id='APjFqb'])[1]"));
            SeleniumCustomMethods.Return(driver, By.XPath("(//textarea[@id='APjFqb'])[1]"));
        }

        [Test]
        public void EAWebSiteTest()
        {
            IWebDriver driver = new EdgeDriver();

            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();

            //IWebElement loginLink = driver.FindElement(By.XPath("(//a[normalize-space()='Login'])[1]"));
            //loginLink.Click();
            SeleniumCustomMethods.Click(driver, By.XPath("(//a[normalize-space()='Login'])[1]"));

            //IWebElement txtUserName = driver.FindElement(By.XPath("(//input[@id='UserName'])[1]"));
            //txtUserName.SendKeys("admin");
            SeleniumCustomMethods.EnterText(driver, By.XPath("(//input[@id='UserName'])[1]"), "admin");
            //IWebElement txtUserPassword = driver.FindElement(By.XPath("(//input[@id='Password'])[1]"));
            //txtUserPassword.SendKeys("password");
            SeleniumCustomMethods.EnterText(driver, By.XPath("(//input[@id='Password'])[1]"), "password");
            //IWebElement btnLogIn = driver.FindElement(By.XPath("(//input[@id='loginIn'])[1]"));
            ////btnLogIn.Submit();
            //btnLogIn.Click();
            SeleniumCustomMethods.Click(driver, By.XPath("(//input[@id='loginIn'])[1]"));

        }

        [Test]
        public void HANDICAP() 
        {
            IWebDriver driver = new EdgeDriver();

            //Log in
            driver.Navigate().GoToUrl("https://test.jobs.hi-bd.org/admin/login");
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            SeleniumCustomMethods.Wait(driver, 2);

            //driver.FindElement(By.XPath("(//input[@id='username'])[1]")).SendKeys("arefin_super_admin");
            SeleniumCustomMethods.EnterText(driver, By.XPath("(//input[@id='username'])[1]"), "arefin_super_admin");
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            SeleniumCustomMethods.Wait(driver, 1);

            //driver.FindElement(By.XPath("(//input[@id='password'])[1]")).SendKeys("123456");
            SeleniumCustomMethods.EnterText(driver, By.XPath("(//input[@id='password'])[1]"), "123456");
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            SeleniumCustomMethods.Wait(driver, 1);

            driver.FindElement(By.XPath("(//button[normalize-space()='Log in'])[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Recruitment Request Module
            driver.FindElement(By.XPath("(//a[normalize-space()='Recruitment Request'])[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.XPath("(//a[@href='https://test.jobs.hi-bd.org/admin/recruitment-request'])[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Hiring Manager
            driver.FindElement(By.XPath("(//a[normalize-space()='Add New'])[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //SelectElement selectProjectOrDepartment = new SelectElement(driver.FindElement(By.XPath("(//select[@id='department'])[1]")));
            //selectProjectOrDepartment.SelectByValue("Finance");
            SeleniumCustomMethods.DropDownByText(driver, By.XPath("(//select[@id='department'])[1]"), "Finance");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            driver.FindElement(By.XPath("(//input[@id='name_of_department'])[1]")).SendKeys("Sample Automation Test");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            driver.FindElement(By.XPath("(//input[@id='position_title'])[1]")).SendKeys("Sample Automation Test");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            SelectElement selectJobDescription = new SelectElement(driver.FindElement(By.XPath("(//select[@id='job_description'])[1]")));
            selectJobDescription.SelectByText("Project Officer_Job Description");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            driver.FindElement(By.XPath("(//input[@id='number_of_position'])[1]")).SendKeys("2");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            SelectElement selectEmployeeAtPresent = new SelectElement(driver.FindElement(By.XPath("(//select[@id='employee_at_present'])[1]")));
            selectEmployeeAtPresent.SelectByValue("No");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            SelectElement selectTypeOfAppointment = new SelectElement(driver.FindElement(By.XPath("(//select[@id='appointment_type'])[1]")));
            selectTypeOfAppointment.SelectByValue("Permanent");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            driver.FindElement(By.XPath("(//input[@id='job_starting_date'])[1]")).SendKeys("31-12-2024");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            driver.FindElement(By.XPath("(//input[@id='job_ending_date'])[1]")).SendKeys("31-12-2026");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            driver.FindElement(By.XPath("(//input[@id='vacancy_caused_due_to'])[1]")).SendKeys("Sample Automation Test");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            driver.FindElement(By.XPath("(//input[@id='vacancy_caused_due_to'])[1]")).SendKeys("Sample Automation Test");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            driver.FindElement(By.XPath("(//input[@id='salary_range_from'])[1]")).SendKeys("30000");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            SelectElement selectTypeOfRecruitment = new SelectElement(driver.FindElement(By.XPath("(//select[@id='recruitment_type'])[1]")));
            selectTypeOfRecruitment.SelectByValue("External Recruitment");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            SelectElement selectHOD = new SelectElement(driver.FindElement(By.XPath("(//select[@id='hodam_id'])[1]")));
            selectHOD.SelectByText("Arefin Super Admin ( Super Admin ) - Super Admin");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            driver.FindElement(By.XPath("(//input[@id='salary_range_to'])[1]")).SendKeys("40000");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
    }
}