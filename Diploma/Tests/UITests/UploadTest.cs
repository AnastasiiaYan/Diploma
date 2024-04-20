using Allure.NUnit.Attributes;
using Diploma.Helpers.Configuration;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;
using System.Reflection;

namespace Diploma.Tests.UITests
{
    internal class UploadTest : BaseUiTest
    {
        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
        public void UploadFileTest()
        {

            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectsPage projectsPage = new ProjectsPage(Driver);
            ProjectRepositoryPage projectRepositoryPage = new ProjectRepositoryPage(Driver);
            var uploadFile = "case.json";
            var caseTitle = "Upload";
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources", uploadFile);

            loginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            projectsPage.ClickCreateProjectButton();
            projectsPage.SendKeysProjectNameInput("UploadFileTest");
            projectsPage.ClickCreateProjDialogButton();

            projectRepositoryPage.ClickImportButton();
            projectRepositoryPage.SendKeysIntoEmailInputField(filePath);
            projectRepositoryPage.ClickImportTestsButton();

            Assert.That(projectRepositoryPage.GetUploadCaseText(), Is.EqualTo(caseTitle));
        }
    }
}