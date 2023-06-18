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
            string email = "ming_gupta@259.33.sharelane.com";
            string password = "1111";

            MainPage.TryToLogin(email, password);

            Assert.IsTrue(MainPage.CheckLogOutLink());
        }

        [Test, Category("Negative")]
        public void LoginWithEmptyCredentials()
        {
            string errorMessage = "Oops, error. Email and/or password don't match our records";

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
