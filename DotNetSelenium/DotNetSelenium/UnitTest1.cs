using DotNetSelenium.Pages;
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
            IWebElement webElement = driver.FindElement(By.XPath("(//textarea[@id='APjFqb'])[1]"));
            //webElement.SendKeys("Selenium");

            SeleniumCustomMethods.EnterText(webElement, "Selenium");
            //webElement.SendKeys(Keys.Return);
            //SeleniumCustomMethods.SendKeys(driver, By.XPath("(//textarea[@id='APjFqb'])[1]"));
            IWebElement webElement2 = driver.FindElement(By.XPath("(//textarea[@id='APjFqb'])[1]"));
            SeleniumCustomMethods.ReturnElement(webElement2);
        }

        [Test]
        public void EAWebSiteTest()
        {
            IWebDriver driver = new EdgeDriver();

            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();

            IWebElement webElement = driver.FindElement(By.XPath("(//a[normalize-space()='Login'])[1]"));
            SeleniumCustomMethods.ClickElement(webElement);

            IWebElement webElement1 = driver.FindElement(By.XPath("(//input[@id='UserName'])[1]"));
            SeleniumCustomMethods.EnterText(webElement1, "admin");

            IWebElement webElement2 = driver.FindElement(By.XPath("(//input[@id='Password'])[1]"));
            SeleniumCustomMethods.EnterText(webElement2, "password");

            IWebElement webElement3 = driver.FindElement(By.XPath("(//input[@id='loginIn'])[1]"));
            SeleniumCustomMethods.ClickElement(webElement3);
        }

        [Test]
        public void EAWebSiteTestWithPOM()
        {
            var driver = new EdgeDriver();

            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.ClickLogin();
            loginPage.Login("admin", "password");
        }

        [Test]
        public void HANDICAPRecruitmentRequest()
        {
            IWebDriver driver = new EdgeDriver();

            //Log in
            driver.Navigate().GoToUrl("https://test.jobs.hi-bd.org/admin/login");
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            SeleniumCustomMethods.WaitElement(driver, 2);

            //driver.FindElement(By.XPath("(//input[@id='username'])[1]")).SendKeys("arefin_super_admin");
            IWebElement webElement = driver.FindElement(By.XPath("(//input[@id='username'])[1]"));
            SeleniumCustomMethods.EnterText(webElement, "arefin_super_admin");
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            SeleniumCustomMethods.WaitElement(driver, 1);

            //driver.FindElement(By.XPath("(//input[@id='password'])[1]")).SendKeys("123456");
            IWebElement webElement1 = driver.FindElement(By.XPath("(//input[@id='password'])[1]"));
            SeleniumCustomMethods.EnterText(webElement1, "123456");
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            SeleniumCustomMethods.WaitElement(driver, 1);

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
            IWebElement webElement2 = driver.FindElement(By.XPath("(//select[@id='department'])[1]"));
            SeleniumCustomMethods.DropDownByText(webElement2, "Finance");

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

        [Test]
        public void HANDICAPJob()
        {
            IWebDriver driver = new EdgeDriver();

            //Log in
            driver.Navigate().GoToUrl("https://test.jobs.hi-bd.org/admin/login");
            driver.Manage().Window.Maximize();
            SeleniumCustomMethods.WaitElement(driver, 2);

            IWebElement webElement = driver.FindElement(By.XPath("(//input[@id='username'])[1]"));
            SeleniumCustomMethods.EnterText(webElement, "arefin_super_admin");
            SeleniumCustomMethods.WaitElement(driver, 1);

            IWebElement webElement1 = driver.FindElement(By.XPath("(//input[@id='password'])[1]"));
            SeleniumCustomMethods.EnterText(webElement1, "123456");
            SeleniumCustomMethods.WaitElement(driver, 1);

            driver.FindElement(By.XPath("(//button[normalize-space()='Log in'])[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Job Module
            IWebElement webElement2 = driver.FindElement(By.XPath("//a[@data-toggle='dropdown'][normalize-space()='Job']"));
            SeleniumCustomMethods.ClickElement(webElement2);
            SeleniumCustomMethods.WaitElement(driver, 3);

            IWebElement webElement3 = driver.FindElement(By.XPath("(//a[normalize-space()='Job Advertisement'])[1]"));
            SeleniumCustomMethods.ClickElement(webElement3);
            SeleniumCustomMethods.WaitElement(driver, 5);

            IWebElement webElement4 = driver.FindElement(By.XPath("(//a[@class='edit btn btn-info btn-sm1'])[1]"));
            SeleniumCustomMethods.ClickElement(webElement4);
            SeleniumCustomMethods.WaitElement(driver, 10);

            IWebElement webElement5 = driver.FindElement(By.XPath("(//a[normalize-space()='Candidate Requirements'])[1]"));
            SeleniumCustomMethods.ClickElement(webElement5);
            SeleniumCustomMethods.WaitElement(driver, 2);
        }
    }
}