using OpenQA.Selenium;
using ShareLaneTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareLaneTests.Tests
{
    [TestFixture]
    internal class LoginTests : BaseTest
    {
        [Test, Category("Positive")]
        public void LoginWithValidCredentials()
        {
            Assert.IsTrue(MainPage.CheckLogOutLink());
        }

        [Test, Category("Negative")]
        public void LoginWithEmptyCredentials()
        {
            string errorMessage = "Oops, error. Email and/or password don't match our records";

            if (MainPage.CheckLogOutLink()) 
            {
                MainPage.TryToLogOut();
                ChromeDriver.Navigate().GoToUrl("https://www.sharelane.com/cgi-bin/main.py");
            }

            MainPage.TryToLogin();
            var error = ChromeDriver.FindElement(By.ClassName("error_message"));

            Assert.Multiple(() =>
            {
                Assert.AreEqual(errorMessage, error.Text);
                Assert.IsTrue(error.Displayed);
            });
        }
    }
}
