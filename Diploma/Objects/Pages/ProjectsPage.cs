using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
        
        public IWebElement CreateProjectButton => WaitsHelper.WaitForExists(createNewProjectButton);
        public IWebElement NotificationsButton => WaitsHelper.WaitForExists(notificationsButton);
        public IWebElement ProjectNameInput => WaitsHelper.WaitForExists(projectNameInput);
        public IWebElement CreateProjDialogButton => WaitsHelper.WaitForExists(createProjDialogButton);


        public void ClickCreateProjectButton() => CreateProjectButton.Click();
        public void ClickCreateProjDialogButton() => CreateProjDialogButton.Click();
        public void SendKeysProjectNameInput(string input) => ProjectNameInput.SendKeys(input);
        public override bool IsPageOpened() => CreateProjectButton.Displayed;        
    }
}