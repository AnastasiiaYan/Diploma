/* 1 тест воспроизводящий любой дефект, в данном случае корректное альтернативное поведение при загрузке файла с неожиданной структурой*/

using Allure.NUnit.Attributes;
using Diploma.Helpers.Configuration;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;
using java.awt;
using OpenQA.Selenium;
using System;
using System.Reflection;

namespace Diploma.Tests.UITests
{
    internal class ReproductionBugTest : BaseUiTest
    {
        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.blocker)]
        [AllureIssue("JIRA-123")]
        public void ReproductionImportBugTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectsPage projectsPage = new ProjectsPage(Driver);
            ProjectRepositoryPage projectRepositoryPage = new ProjectRepositoryPage(Driver);
            var uploadFile = "schema.json";
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources", uploadFile);

            loginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            projectsPage.ClickCreateProjectButton();
            projectsPage.SendKeysProjectNameInput("ReproductionImportBugTest");
            projectsPage.ClickCreateProjDialogButton();
                       
            projectRepositoryPage.ClickImportButton();  
            projectRepositoryPage.SendKeysIntoEmailInputField(filePath);
            projectRepositoryPage.ClickImportTestsButton();
            
            Assert.That(projectRepositoryPage.GetImportErrorMessageText(), Is.EqualTo("Unable to import file. Invalid file structure"));
        }
    }
}