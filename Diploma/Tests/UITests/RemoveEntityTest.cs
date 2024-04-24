/*using Allure.NUnit.Attributes;
using Diploma.Core;
using Diploma.Helpers;
using Diploma.Helpers.Configuration;
using Diploma.Models.UIModels;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;


namespace Diploma.Tests.UITests
{   
    public class RemoveEntityTest : BaseUiTest
    {               

        [Test]
        [AllureFeature("Удаление сущности: проект"), Order(7), Retry(2)]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
        public void RemoveProjectTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectSteps projectSteps = new ProjectSteps(Driver);
            ProjectsPage projectsPage = new ProjectsPage(Driver);
                        
            loginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            Project project = new Project.Builder()
                .SetName("TOREMOVE")
                .SetCode("TOREMOVE")
                .SetDescription("TestDescription")
                .Build();

            projectsPage.ClickProjectsButton();
            projectSteps.RemoveProject();

            Assert.IsFalse(projectsPage.IsProjectExist());          
        }
    }
}*/