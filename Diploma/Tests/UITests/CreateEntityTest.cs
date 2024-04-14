/* создание сущности + отображениe диалогового окна */

using Diploma.Helpers.Configuration;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;

namespace Diploma.Tests.UITests
{
    public class CreateEntityTest : BaseUiTest
    {
        [Test]
        public void CreateProjectTest()
        {            
            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectsPage projectsPage = new ProjectsPage(Driver);
            ProjectRepositoryPage projectRepositoryPage = new ProjectRepositoryPage(Driver);
            var projectNameInput = "CreateProjectTest";
            //добавить VAR код репозитория и с ним в ассерте сравнивать 
            loginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

            projectsPage.ClickCreateProjectButton();
            projectsPage.SendKeysProjectNameInput(projectNameInput);
            projectsPage.ClickCreateProjDialogButton();
            
            Assert.That(projectRepositoryPage.HeaderElement.Text.ToLower, Does.Contain($"{projectNameInput} repository"));
        }
    }
}