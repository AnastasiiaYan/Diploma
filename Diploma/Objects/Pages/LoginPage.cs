using Diploma.Helpers;
using OpenQA.Selenium;

namespace Diploma.Objects.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private static readonly By emailInputField = By.Name("email");
        private static readonly By passwordInputField = By.Name("password");
        private static readonly By signInButton = By.CssSelector("button[type= 'submit']");

        public void SendKeysIntoEmailInputField(string input)
        {
            WaitsHelper
                .WaitForExists(emailInputField)
                .SendKeys(input);
        }

        public void SendKeysIntoPasswordInputField(string input)
        {
            WaitsHelper
                .WaitForExists(passwordInputField)
                .SendKeys(input);
        }

        public void ClickOnSignInButton()
        {
            WaitsHelper
                .WaitForExists(signInButton)
                .Click();
        }
    }
}
