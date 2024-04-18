/* создание сущности + отображениe диалогового окна */

using Allure.NUnit.Attributes;
using Diploma.Helpers.Configuration;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;

namespace Diploma.Tests.UITests
{
    public class CreateEntityTest : BaseUiTest
    {
        [Test]
        [AllureFeature("Создание новой сущности: проект")]
        public void CreateProjectTest()
        {            
            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectsPage projectsPage = new ProjectsPage(Driver);
            ProjectRepositoryPage projectRepositoryPage = new ProjectRepositoryPage(Driver);
            var projectNameInput = "CREPT";
             
            loginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

            projectsPage.ClickCreateProjectButton();
            projectsPage.SendKeysProjectNameInput(projectNameInput);
            projectsPage.ClickCreateProjDialogButton();
            
            Assert.That(projectRepositoryPage.GetHeaderElementText(), Does.Contain($"{projectNameInput} repository"));
        }
    }
}