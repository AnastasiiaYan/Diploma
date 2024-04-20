using Allure.NUnit.Attributes;
using Diploma.Helpers.Configuration;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;

namespace Diploma.Tests.UITests
{
    public class RemoveEntityTest : BaseUiTest
    {
        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
        public void RemoveProjectTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectsPage projectsPage = new ProjectsPage(Driver);
                        
            loginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

            projectsPage.IsProjectExist();//переписать 
            projectsPage.ClickProjectBreadcrumbs();
            projectsPage.ClickRemoveProjectButton();
            projectsPage.ClickDeleteProjectButton();

            Assert.That(!projectsPage.IsProjectExist());//переписать            
        }
    }
}