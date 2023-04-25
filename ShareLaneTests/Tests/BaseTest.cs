using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ShareLaneTests.Pages;

namespace ShareLaneTests.Tests
{
    internal class BaseTest
    {
        protected WebDriver ChromeDriver { get; set; }
        public MainPage MainPage { get; set; }
        public BookPage BookPage { get; set; }
        public ShopingCartPage ShopingCartPage { get; set; }
        public CheckOutPage CheckOutPage { get; set; }

        [SetUp]
        public void Setup()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            MainPage = new MainPage(ChromeDriver);

            ChromeDriver.Navigate().GoToUrl("https://www.sharelane.com/cgi-bin/main.py");
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}