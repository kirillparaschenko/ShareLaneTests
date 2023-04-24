using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ShareLaneTests.Pages;

namespace ShareLaneTests.Tests
{
    internal class BaseTest
    {
        protected WebDriver ChromeDriver { get; set; }
        public MainPage MainPage { get; set; }

        [SetUp]
        public void Setup()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            MainPage = new MainPage(ChromeDriver);

            ChromeDriver.Navigate().GoToUrl("https://www.sharelane.com/cgi-bin/main.py");

            string email = "vladimir_fuente@465.74.sharelane.com";
            string password = "1111";

            MainPage.TryToLogin(email, password);
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}