using Allure.NUnit.Attributes;
using Diploma.Models.UIModels;
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
        public void CreateProject(Project project)
        {
            projectsPage.IsPageOpened();
            projectsPage.ClickCreateProjectButton();
            projectsPage.SendKeysProjectNameInput(project.Name);
            projectsPage.ClearProjectCodeInput();
            projectsPage.SendKeysProjectCodeInput(project.Code);
            projectsPage.SendKeysProjectDescriptionInput(project.Description ?? "");
            projectsPage.ClickCreateProjDialogButton();
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