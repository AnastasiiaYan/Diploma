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

        private static readonly By createProjectButton = By.Id("createButton");
        private static readonly By notificationsButton = By.CssSelector(".b5tgEy [aria-label='Notifications']");

        public IWebElement CreateProjectButton => WaitsHelper.WaitForExists(createProjectButton);

        public void ClickOnSignInButton() => CreateProjectButton.Click();   
        public override bool IsPageOpened() => CreateProjectButton.Displayed;        
    }
}