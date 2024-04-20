using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Objects.Pages
{
    public class ProjectsPage : BasePage
    {
        public ProjectsPage(IWebDriver driver) : base(driver) { }

        private static readonly By createNewProjectButton = By.Id("createButton");
        private static readonly By notificationsButton = By.CssSelector(".b5tgEy [aria-label='Notifications']");
        private static readonly By projectNameInput = By.Id("project-name");
        private static readonly By createProjDialogButton = By.CssSelector("button[type= 'submit']");
        private static readonly By projectBreadcrumbs = By.CssSelector("button.G1dmaA.eWFeX4.eij1r4");
        private static readonly By removeProjectButton = By.CssSelector("button.EehRY_.Wy99v3.fwhtHZ[tabindex=\"0\"][type=\"button\"][role=\"menuitem\"]");
        private static readonly By deleteProjectButton = By.CssSelector("button.G1dmaA.X8bxUI.IAcAWv");
        private static readonly By messageElement = By.CssSelector(".b5tgEy [aria-label='Notifications']");
        private static readonly By project = By.CssSelector("a.cx2QU4[href*='/project/CREPT']");

        public IWebElement CreateProjectButton => WaitsHelper.WaitForExists(createNewProjectButton);
        public IWebElement NotificationsButton => WaitsHelper.WaitForExists(notificationsButton);
        public IWebElement ProjectNameInput => WaitsHelper.WaitForExists(projectNameInput);
        public IWebElement CreateProjDialogButton => WaitsHelper.WaitForExists(createProjDialogButton);
        public IWebElement ProjectBreadcrumbs => WaitsHelper.WaitForExists(projectBreadcrumbs);
        public IWebElement RemoveProjectButton => WaitsHelper.WaitForExists(removeProjectButton);
        public IWebElement DeleteProjectButton => WaitsHelper.WaitForExists(deleteProjectButton);
        public IWebElement MessageElement => WaitsHelper.WaitForExists(messageElement);
        public IWebElement Project => WaitsHelper.WaitForExists(project);

        public void ClickCreateProjectButton() => CreateProjectButton.Click();
        public void ClickCreateProjDialogButton() => CreateProjDialogButton.Click();
        public void ClickProjectBreadcrumbs() => ProjectBreadcrumbs.Click();
        public void ClickRemoveProjectButton() => RemoveProjectButton.Click();
        public void ClickDeleteProjectButton() => DeleteProjectButton.Click();
        public void SendKeysProjectNameInput(string input) => ProjectNameInput.SendKeys(input);
        public override bool IsPageOpened() => CreateProjectButton.Displayed;
        public bool IsProjectExist()
        {
            ReadOnlyCollection<IWebElement> projectElements =  Driver.FindElements(By.CssSelector("a.cx2QU4[href*='/project/C454555']"));

            if (projectElements.Count == 0)  return false;            
            else return true;
        }
        public string GetMessageElementText() => MessageElement.Text;
    }
}