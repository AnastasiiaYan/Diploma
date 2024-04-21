using Allure.NUnit.Attributes;
using Diploma.Helpers.Configuration;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;

namespace Diploma.Tests.UITests
{
    internal class LoginTests : BaseUiTest
    {
        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        public void SuccessfulLoginTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectsPage projectsPage = new ProjectsPage(Driver);

            loginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

            Assert.That(projectsPage.IsPageOpened());
        }        
    }    
}