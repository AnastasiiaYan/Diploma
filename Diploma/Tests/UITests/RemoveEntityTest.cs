/* тест на удаление сущности */

using Diploma.Helpers.Configuration;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;
using OpenQA.Selenium;

namespace Diploma.Tests.UITests
{
    public class RemoveEntityTest : BaseUiTest
    {
        [Test]
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