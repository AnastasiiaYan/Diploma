using Diploma.Helpers;
using OpenQA.Selenium;

namespace Diploma.Objects.Pages
{
    public class StartPage : BasePage
    {
        public StartPage(IWebDriver driver) : base(driver) { }

        private static readonly By signInButton = By.Id("signin");
        private static readonly By createAccountButton = By.XPath("//a[contains(text(), 'Start for free')]");

        public IWebElement SignInButton => WaitsHelper.WaitForExists(signInButton);
        public IWebElement CreateAccountButton => WaitsHelper.WaitForExists(createAccountButton);

        public void ClickOnSignInButton() => SignInButton.Click();
        public void ClickCreateAccountButton() => CreateAccountButton.Click();        
        public override bool IsPageOpened()
        {
            if (SignInButton.Displayed)
            {
                _logger.Debug("Стартовая страница Gase.io открыта");
                return true;
            }
            return false;
        }
    }
}