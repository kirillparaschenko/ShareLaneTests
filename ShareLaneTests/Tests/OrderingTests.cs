using OpenQA.Selenium;
using ShareLaneTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareLaneTests.Tests
{
    internal class OrderingTests : BaseTest
    {
        string cardType { get; set; }
        string cardNumber { get; set; }

        [SetUp]
        public void SetUp()
        {
            BookPage = new BookPage(ChromeDriver);
            ShopingCartPage = new ShopingCartPage(ChromeDriver);
            CheckOutPage = new CheckOutPage(ChromeDriver);

            string email = "prashant_watson@693.74.sharelane.com";
            string password = "1111";

            cardType = "Visa";
            cardNumber = "1111111111112013";

            MainPage.TryToLogin(email, password);
        }

        [Test]
        public void OrderBook()
        {
            string sucsessMessage = "Thank you for your order!!!";

            MainPage.SelectBook();
            BookPage.ClickAddtoCart();
            MainPage.OpenShoppingCart();
            ShopingCartPage.ClickProceedToCheckOut();
            CheckOutPage.MakePayment(cardType, cardNumber);

            var message = ChromeDriver.FindElement(By.XPath("//table/tbody/tr[2]/td/p/font/b"));

            Assert.AreEqual(sucsessMessage, message.Text);
        }
    }
}
