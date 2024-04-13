using Diploma.Objects.Pages;
using Diploma.Tests.UITests;

namespace Diploma.Tests
{
    internal class AutorizationTests : BaseTest
    {
        [Test]    
        public void SuccessfulAuthorizationTest()
        {
            LoginPage loginPage = new LoginPage(Driver);
            StartPage startPage = new StartPage(Driver);
            ProjectsPage projectsPage = new ProjectsPage(Driver);

            var emailText = "aytestqa@gmail.com";
            var passwordText = "qwertyTMS24.";

            startPage.ClickOnSignInButton();
            loginPage.SendKeysIntoEmailInputField(emailText);
            loginPage.SendKeysIntoPasswordInputField(passwordText);
            loginPage.ClickOnSubmitButton();

            Assert.That(projectsPage.IsPageOpened());
        }        
    }    
}