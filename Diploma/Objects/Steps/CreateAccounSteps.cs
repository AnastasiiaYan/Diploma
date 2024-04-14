using Diploma.Objects.Pages;
using OpenQA.Selenium;

namespace Diploma.Objects.Steps
{
    public class CreateAccounSteps : BaseSteps
    {
        private StartPage startPage;
        private CreateAccountPage createAccountPage;

        public CreateAccounSteps(IWebDriver driver) : base(driver) 
        {
            startPage = new StartPage(driver);
            createAccountPage = new CreateAccountPage(driver);
        }

        public void Registration(string email, string password, string passwordConfirmation)
        {
            startPage.ClickCreateAccountButton();
            createAccountPage.SendKeysIntoEmailInputField(email);
            createAccountPage.SendKeysIntoPasswordInputField(password);
            createAccountPage.SendKeysIntoPasswordConfirmationField(passwordConfirmation);
            createAccountPage.ClickOnSubmitButton();
        }
    }
}