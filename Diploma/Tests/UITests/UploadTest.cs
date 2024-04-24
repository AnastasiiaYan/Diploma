/*using Allure.NUnit.Attributes;
using Diploma.Helpers.Configuration;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;
using System.Reflection;
using Diploma.Models.UIModels;

namespace Diploma.Tests.UITests
{
    internal class UploadTest : BaseUiTest
    {
        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
        public void UploadFileTest()
        {

            LoginSteps loginSteps = new LoginSteps(Driver);
            ImportSteps importSteps = new ImportSteps(Driver);
            ProjectSteps projectSteps = new ProjectSteps(Driver);
            ProjectRepositoryPage projectRepositoryPage = new ProjectRepositoryPage(Driver);
            var uploadFile = "case.json";
            var caseTitle = "Upload";
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources", uploadFile);
            Project project = new Project.Builder()
                .SetName("UploadFileTest")
                .SetCode("Uplo")
                .Build();

            loginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            projectSteps.CreateProject(project);
            importSteps.ImportCase(filePath);

            Assert.That(projectRepositoryPage.GetUploadCaseText(), Is.EqualTo(caseTitle));

            projectSteps.RemoveProject();
        }
    }
}
*/