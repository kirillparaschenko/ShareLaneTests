using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareLaneTests.Pages
{
    internal class CheckOutPage : BasePage
    {
        By CardTypeDropdownLocator = By.Name("card_type_id");
        By CardNumberInputLocator = By.Name("card_number");
        By MakePaymetnButtonLocator = By.XPath("//input[@value='Make Payment']");
        By BookNameLocator = By.XPath("//table/tbody/tr[3]/td[2]/p/b");

        public CheckOutPage(WebDriver driver) : base(driver)
        {
        }

        public void ClickMakePayment()
        {
            ChromeDriver.FindElement(MakePaymetnButtonLocator).Click();
        }

        void SelectCardType (string cardType)
        {
            SelectElement dropDown = new SelectElement(ChromeDriver.FindElement(CardTypeDropdownLocator));
            dropDown.SelectByText(cardType);

            Assert.That(dropDown.SelectedOption.Text, Is.EqualTo(cardType));
        }

        void SetCardNumber (string cardNumber)
        {
            ChromeDriver.FindElement(CardNumberInputLocator).SendKeys(cardNumber);
        }

        public void MakePayment(string cardType = "", string cardNumber = "")
        {
            SelectCardType(cardType);
            SetCardNumber(cardNumber);
            ClickMakePayment();
        }

        public string ReadBookName()
        {
            return ChromeDriver.FindElement(BookNameLocator).Text;
        }
    }
}
