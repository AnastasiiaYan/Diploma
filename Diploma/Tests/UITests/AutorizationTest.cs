using Diploma.Helpers.Configuration;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;
using Diploma.Tests.UITests;

namespace Diploma.Tests
{
    internal class LoginTests : BaseTest
    {
        [Test]    
        public void SuccessfulLoginTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectsPage projectsPage = new ProjectsPage(Driver);

            loginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

            Assert.That(projectsPage.IsPageOpened());
        }        
    }    
}