using Diploma.Helpers;
using OpenQA.Selenium;

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
        // попытаться улучшить поиск для Warnings
        public IWebElement EmailInputField => WaitsHelper.WaitForExists(emailInputField);
        public IWebElement PasswordInputField => WaitsHelper.WaitForExists(passwordInputField);
        public IWebElement PasswordConfirmationField => WaitsHelper.WaitForExists(passwordConfirmationField);
        public IWebElement SubmitButton => WaitsHelper.WaitForExists(submitButton);
        public IWebElement PasswordWarning =>  WaitsHelper.WaitForExists(passwordWarning);
        public IWebElement EmailWarning => WaitsHelper.WaitForExists(emailWarning);

        public void SendKeysIntoEmailInputField(string input) => EmailInputField.SendKeys(input);        
        public void SendKeysIntoPasswordInputField(string input) => PasswordInputField.SendKeys(input);
        public void SendKeysIntoPasswordConfirmationField(string input) => PasswordConfirmationField.SendKeys(input);
        public void ClickOnSubmitButton() => SubmitButton.Click();
        public string GetPasswordWarningText() => PasswordWarning.Text;
        public string GetEmailWarningText() => EmailWarning.Text;
        public override bool IsPageOpened() => EmailInputField.Displayed && PasswordConfirmationField.Displayed;       
    }
}