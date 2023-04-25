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

            string email = "marina_fuente@2033.2.sharelane.com";
            string password = "1111";

            cardType = "Visa";
            cardNumber = "1111111111118832";

            MainPage.TryToLogin(email, password);
        }

        [Test]
        public void OrderBook()
        {
            string sucsessMessage = "Thank you for your order!!!";

            MainPage.SelectBook();

            var bookName = BookPage.ReadBookName();
            BookPage.ClickAddtoCart();

            MainPage.OpenShoppingCart();

            var bookNameInCart = ShopingCartPage.ReadBookName();
            Assert.AreEqual(bookName, bookNameInCart);

            ShopingCartPage.ClickProceedToCheckOut();

            var bookNameInOrder = CheckOutPage.ReadBookName();
            Assert.AreEqual(bookNameInOrder, bookNameInCart);

            CheckOutPage.MakePayment(cardType, cardNumber);

            var message = ChromeDriver.FindElement(By.XPath("//table/tbody/tr[2]/td/p/font/b"));

            Assert.AreEqual(sucsessMessage, message.Text);
        }
    }
}
