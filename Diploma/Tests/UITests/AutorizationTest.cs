using Diploma.Objects.Pages;
using Diploma.Tests.UITests;
using OpenQA.Selenium;

namespace Diploma.Tests
{
    internal class AutorizationTests : BaseTest
    {
        [Test]    
        public void SuccessfulAuthorizationTest()
        {
            LoginPage loginPage = new LoginPage(Driver);
            var emailText = "aytestqa@gmail.com";
            var passwordText = "qwertyTMS24.";

            Driver.Navigate().GoToUrl("https://qase.io/");            

            IWebElement mainSigninButton = Driver.FindElement(By.Id("signin"));
            mainSigninButton.Click();

            loginPage.SendKeysIntoEmailInputField(emailText);
            loginPage.SendKeysIntoPasswordInputField(passwordText);
            loginPage.ClickOnSignInButton();

            Assert.That(IsPageOpened());
        }        
    }    
}