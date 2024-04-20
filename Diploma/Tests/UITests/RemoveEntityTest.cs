using Allure.NUnit.Attributes;
using Diploma.Helpers.Configuration;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;

namespace Diploma.Tests.UITests
{
    public class RemoveEntityTest : BaseUiTest
    {
        [Test]
        [AllureFeature("Удаление сущности: проект"), Order(2), Retry(15)]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
        public void RemoveProjectTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectsPage projectsPage = new ProjectsPage(Driver);
                        
            loginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

            projectsPage.IsProjectExist();
            
            projectsPage.ClickProjectBreadcrumbs();
            projectsPage.ClickRemoveProjectButton();
            projectsPage.ClickDeleteProjectButton();
            Driver.Navigate().Refresh();
            
            Assert.IsFalse(projectsPage.IsProjectExist());          
        }
    }
}