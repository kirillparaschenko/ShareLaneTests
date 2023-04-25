using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareLaneTests.Pages
{
    internal class ShopingCartPage : BasePage
    {
        By UpdateButtonLocator = By.XPath("//input[@value='Update']");
        By ProceedToCheckOutButtonLocatot = By.XPath("//input[@value='Proceed to Checkout']");
        By QantityInputLocator = By.Name("q");

        public ShopingCartPage(WebDriver driver) : base(driver)
        {
        }

        public CheckOutPage ClickProceedToCheckOut ()
        {
            ChromeDriver.FindElement(ProceedToCheckOutButtonLocatot).Click();
            return new CheckOutPage(ChromeDriver);
        }
    }
}
