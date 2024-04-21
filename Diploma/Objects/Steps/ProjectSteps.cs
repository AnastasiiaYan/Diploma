using Allure.NUnit.Attributes;
using Diploma.Objects.Pages;
using OpenQA.Selenium;

namespace Diploma.Objects.Steps
{
    public class ProjectSteps : BaseSteps
    {
        ProjectsPage projectsPage;
        public ProjectSteps(IWebDriver driver) : base(driver) 
        {
            projectsPage = new ProjectsPage(driver);            
        }                      
            
        [AllureStep]
        public void CreateProject(string projectNameInput)
        {
            projectsPage.IsPageOpened();
            projectsPage.ClickCreateProjectButton();
            projectsPage.SendKeysProjectNameInput(projectNameInput);
            projectsPage.ClickCreateProjDialogButton();
        }

        [AllureStep]
        public void CreateProjectAddGoToProjectsPage(string projectNameInput)
        {
            projectsPage.IsPageOpened();
            projectsPage.ClickCreateProjectButton();
            projectsPage.SendKeysProjectNameInput(projectNameInput);
            projectsPage.ClickCreateProjDialogButton();
            projectsPage.ClickProjectsButton();
        }        

        [AllureStep]
        public void RemoveProject()
        {
            projectsPage.ClickProjectsButton();                      
            projectsPage.ClickProjectBreadcrumbs();
            projectsPage.ClickRemoveProjectButton();
            projectsPage.ClickDeleteProjectButton();
            Driver.Navigate().Refresh();                                  
        }
    }
}