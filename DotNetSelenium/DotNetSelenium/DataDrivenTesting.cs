using DotNetSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Text.Json;

namespace DotNetSelenium
{
    public class DataDrivenTesting
    {
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        private IWebDriver _driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

        [SetUp]
        public void SetUp()
        {
            _driver = new EdgeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();

            //ReadJsonFile();
        }

        [Test]
        [Category("dataDriven")]
        [TestCaseSource(nameof(LoginJsonDataSource))]
        public void EAWebSiteTestWithPOM(LoginModel loginModel)
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);

            //Act
            loginPage.ClickLogin();
            loginPage.Login(loginModel.username, loginModel.password);

            //Assert
            var getLoggedIn = loginPage.IsLoggedIn();
            Assert.That(getLoggedIn.manageUsers, Is.True);
            Assert.That(getLoggedIn.employeeDeatils, Is.True);
        }

        [Test]
        [Category("dataDriven")]
        public void EAWebSiteTestWithPOMWithJsonData()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Login.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            var loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString);

            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickLogin();
            loginPage.Login(loginModel.username, loginModel.password);
        }

        public static IEnumerable<LoginModel> Login()
        {
            yield return new LoginModel()
            {
                username = "admin",
                password = "password"
            };

            yield return new LoginModel()
            {
                username = "admin1",
                password = "password"
            };

            yield return new LoginModel()
            {
                username = "admin",
                password = "password1"
            };
        }

        public static IEnumerable<LoginModel> LoginJsonDataSource()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Login.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            var loginModel = JsonSerializer.Deserialize<List<LoginModel>>(jsonString);

            foreach (var loginData in loginModel)
            {
                yield return loginData;
            }
        }

        private void ReadJsonFile()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Login.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            var loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
 
        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
