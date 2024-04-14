/* использование некорректных данных */

using Diploma.Helpers.Configuration;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;

namespace Diploma.Tests.UITests
{
    internal class InvalidInputTest : BaseUiTest
    {
        [Test]
        public void InvalidLoginTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            LoginPage loginPage = new LoginPage(Driver);
            var invalidPassword = "invalidPassword";
            
            loginSteps.Login(Configurator.AppSettings.Username, invalidPassword);                      

            Assert.Multiple(() =>
            {
                Assert.That(loginPage.GetErrorLoginAlertText(), Is.EqualTo("These credentials do not match our records."));
                Assert.That(loginPage.IsPageOpened());
            });
        }
    }
}