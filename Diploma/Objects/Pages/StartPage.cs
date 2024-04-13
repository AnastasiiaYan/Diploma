using Diploma.Helpers;
using OpenQA.Selenium;

namespace Diploma.Objects.Pages
{
    public class StartPage : BasePage
    {
        public StartPage(IWebDriver driver) : base(driver) { }

        private static readonly By signInButton = By.Id("signin");

        public IWebElement SignInButton => WaitsHelper.WaitForExists(signInButton);

        public void ClickOnSignInButton()
        {
            SignInButton.Click();
        }

        public override bool IsPageOpened()
        {
            return SignInButton.Displayed;
        }
    }
}
