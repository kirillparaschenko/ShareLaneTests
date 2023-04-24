using OpenQA.Selenium;
using ShareLaneTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareLaneTests.Tests
{
    internal class SearchTests : BaseTest
    {
        public BookPage BookPage { get; set; }

        [SetUp]
        public void SetUp()
        {
            BookPage = new BookPage(ChromeDriver);
        }

        [Test, Category("Positive")]
        public void SearchValidBook()
        {
            string bookName = "The Analects of Confucius";
            MainPage.SetSearch(bookName);

            BookPage.CheckBookPage(bookName);
        }

        [Test, Category("Negtive")]
        public void SearchInvalidBook()
        {
            string errorMessage = "Nothing is found :(";

            string bookName = "Asdg";
            MainPage.SetSearch(bookName);
            var error = ChromeDriver.FindElement(By.ClassName("confirmation_message"));

            Assert.AreEqual(errorMessage, error.Text);
        }
    }
}
