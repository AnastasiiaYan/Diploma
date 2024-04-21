using Allure.NUnit.Attributes;
using Diploma.Helpers.Configuration;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;

namespace Diploma.Tests.UITests
{
    public class CreateEntityTest : BaseUiTest
    {
        [Test]
        [AllureFeature("Создание новой сущности: проект"), Order(1)]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]

        public void CreateProjectTest()
        {            
            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectSteps projectSteps = new ProjectSteps(Driver);            
            ProjectRepositoryPage projectRepositoryPage = new ProjectRepositoryPage(Driver);
            var projectNameInput = "CREPT";
             
            loginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            projectSteps.CreateProject(projectNameInput);
                       
            Assert.That(projectRepositoryPage.GetHeaderElementText(), Does.Contain($"{projectNameInput} repository"));
        }
    }
}