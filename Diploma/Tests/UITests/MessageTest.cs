/* проверка всплывающего сообщения */

using Diploma.Helpers.Configuration;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Diploma.Tests.UITests
{
    internal class MessageTest : BaseUiTest
    {
        [Test]
        public void PopUpMessageTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectsPage projectsPage = new ProjectsPage(Driver);
            Actions action = new Actions(Driver);
            loginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            var actualMessage = projectsPage.MessageElement.GetAttribute("aria-label");
            var expectedMessage = "Notifications";

            action.MoveToElement(projectsPage.MessageElement,5,5).Build().Perform();
            
            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}