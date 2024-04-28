using Allure.NUnit.Attributes;
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

        [AllureStep]
        public void Registration(User newUser)
        {
            startPage.ClickCreateAccountButton();
            createAccountPage.SendKeysIntoEmailInputField(newUser.GetUsername());
            createAccountPage.SendKeysIntoPasswordInputField(newUser.GetPassword());
            createAccountPage.SendKeysIntoPasswordConfirmationField(newUser.GetPswConfirm());
            createAccountPage.ClickOnSubmitButton();
        }
    }
}