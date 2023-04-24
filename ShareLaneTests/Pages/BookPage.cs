using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShareLaneTests.Pages
{
    internal class BookPage : BasePage
    {
        By AddToCartImage = By.XPath("//p[2]/a/img");
        public BookPage(WebDriver driver) : base(driver)
        {

        }

        void ClickAddtoCart()
        {
            ChromeDriver.FindElement(AddToCartImage).Click();
        }

        public void CheckBookPage(string bookName)
        {
            string currentBookName = ChromeDriver.FindElement(By.XPath("//p[2]")).Text;
            Assert.AreEqual(bookName, currentBookName);
        }
    }
}
