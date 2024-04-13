using Diploma.Helpers;
using OpenQA.Selenium;

namespace Diploma.Objects.Pages
{
    public class StartPage : BasePage
    {
        public StartPage(IWebDriver driver) : base(driver) { }

        private static readonly By srartSignInButton = By.Id("signin");                

        public void ClickOnStartSignInButton()
        {
            WaitsHelper
                .WaitForExists(srartSignInButton)
                .Click();
        }
    }
}
