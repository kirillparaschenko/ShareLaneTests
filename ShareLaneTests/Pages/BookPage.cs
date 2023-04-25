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
        By BookName = By.XPath("//p[2]");

        public BookPage(WebDriver driver) : base(driver)
        {
        }

        public void ClickAddtoCart()
        {
            ChromeDriver.FindElement(AddToCartImage).Click();
        }

        public string ReadBookName()
        {
            return ChromeDriver.FindElement(BookName).Text;
        }
    }
}
