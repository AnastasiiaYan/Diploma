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
        public void Login(User user)
        {
            startPage.ClickOnSignInButton();
            loginPage.SendKeysIntoEmailInputField(user.GetUsername());
            loginPage.SendKeysIntoPasswordInputField(user.GetPassword());
            _logger.Debug("Выполнено заполнение полей \"Work email\", \"Password\"");
            loginPage.ClickOnSubmitButton();
        }
    }
}