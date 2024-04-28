using Diploma.Helpers;
using OpenQA.Selenium;
using NLog;

namespace Diploma.Objects.Pages
{
    public class CreateAccountPage : BasePage
    {
        public CreateAccountPage(IWebDriver driver) : base(driver) { }

        private static readonly By emailInputField = By.Name("email");
        private static readonly By passwordInputField = By.Name("password");       
        private static readonly By passwordConfirmationField = By.Name("passwordConfirmation");
        private static readonly By submitButton = By.CssSelector("button[type= 'submit']");
        private static readonly By passwordWarning = By.XPath("//small[@class='f75Cb_']");
        private static readonly By emailWarning = By.XPath("//span[@class='xtWHgv']");
        private static readonly By resendLink = By.XPath("//a[@id='resend' and @class='index-button mt-4 mb-3']");

        public IWebElement EmailInputField => WaitsHelper.WaitForExists(emailInputField);
        public IWebElement PasswordInputField => WaitsHelper.WaitForExists(passwordInputField);
        public IWebElement PasswordConfirmationField => WaitsHelper.WaitForExists(passwordConfirmationField);
        public IWebElement SubmitButton => WaitsHelper.WaitForExists(submitButton);
        public IWebElement PasswordWarning =>  WaitsHelper.WaitForExists(passwordWarning);
        public IWebElement EmailWarning => WaitsHelper.WaitForExists(emailWarning);
        public IWebElement ResendLink => WaitsHelper.WaitForExists(resendLink);

        public void SendKeysIntoEmailInputField(string input) => EmailInputField.SendKeys(input);        
        public void SendKeysIntoPasswordInputField(string input) => PasswordInputField.SendKeys(input);
        public void SendKeysIntoPasswordConfirmationField(string input) => PasswordConfirmationField.SendKeys(input);
        public void ClickOnSubmitButton() => SubmitButton.Click();
        public string GetPasswordWarningText() => PasswordWarning.Text;
        public string GetEmailWarningText() => EmailWarning.Text;
        public override bool IsPageOpened() => EmailInputField.Displayed && PasswordConfirmationField.Displayed;
        public  bool IsPageSuccessCreatedOpened()
        { 
            if (ResendLink.Displayed)
            {
                _logger.Debug("Открыта страница успешной регистрации нового пользователя");
                return true;
            }       
            return false;
        }     
    }
}