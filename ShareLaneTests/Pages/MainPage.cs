using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareLaneTests.Pages
{
    internal class MainPage : BasePage
    {
        By SearchInputLocator = By.Name("keyword");
        By SearchButton = By.XPath("//input[@value='Search']");

        By ShopingCartLinkLocator = By.LinkText("Shopping Cart");

        By EmailInputLocator = By.Name("email");
        By PasswordInputLocaor = By.Name("password");
        By LoginButtonLocator = By.XPath("//input[@value='Login']");
        By SignUpLinkLocator = By.LinkText("Sign up");

        By LogOutLinkLocator = By.LinkText("Logout");

        By FirstBookLink = By.XPath("/html/body/center/table/tbody/tr[5]/td/table/tbody/tr/td[1]/table/tbody/tr[3]/td/a");

        public MainPage(WebDriver driver) : base(driver)
        {
        }

        void SetEmail (string email)
        {
            ChromeDriver.FindElement(EmailInputLocator).SendKeys(email);
        }

        void SetPassword (string password)
        {
            ChromeDriver.FindElement(PasswordInputLocaor).SendKeys(password);
        }

        void ClickLoginButton ()
        {
            ChromeDriver.FindElement(LoginButtonLocator).Click();
        }
        public void ClickBook()
        {
            ChromeDriver.FindElement(FirstBookLink).Click();
        }

        void ClickLogOut()
        {
            ChromeDriver.FindElement(LogOutLinkLocator).Click();
        }

        public void TryToLogin(string email = "", string password = "")
        {
            SetEmail (email);
            SetPassword (password);
            ClickLoginButton ();
        }

        public void TryToLogOut()
        {
            ClickLogOut();
        }

        public BookPage SetSearch(string bookName)
        {
            ChromeDriver.FindElement(SearchInputLocator).SendKeys(bookName);
            ChromeDriver.FindElement(SearchButton).Click ();

            return new BookPage(ChromeDriver);
        }

        public BookPage SelectBook()
        {
            string firstBookName = ChromeDriver.FindElement(FirstBookLink).Text;
            ClickBook();

            return new BookPage(ChromeDriver);
            //TO DO: BookPage.Check add check of book name
        }

        public ShopingCartPage OpenShoppingCart()
        {
            ChromeDriver.FindElement(ShopingCartLinkLocator).Click();
            return new ShopingCartPage(ChromeDriver);
        }

        public bool CheckLogOutLink()
        {
            return ChromeDriver.FindElement(LogOutLinkLocator).Displayed;
        }
    }
}
