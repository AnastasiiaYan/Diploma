using Allure.NUnit.Attributes;
using Diploma.Objects.Pages;
using OpenQA.Selenium;

namespace Diploma.Objects.Steps
{
    public class LoginSteps : BaseSteps
    {
        private StartPage startPage;
        private LoginPage loginPage;

        public LoginSteps(IWebDriver driver) : base(driver) 
        {
            startPage = new StartPage(driver);
            loginPage = new LoginPage(driver);
        }

        [AllureStep]
        public void Login(string email, string password)
        {
            startPage.ClickOnSignInButton();
            loginPage.SendKeysIntoEmailInputField(email);
            loginPage.SendKeysIntoPasswordInputField(password);
            loginPage.ClickOnSubmitButton();
        }
    }
}