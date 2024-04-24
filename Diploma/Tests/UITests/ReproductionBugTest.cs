/*using Allure.NUnit.Attributes;
using Diploma.Helpers.Configuration;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;
using java.awt;
using OpenQA.Selenium;
using System;
using System.Reflection;
using Diploma.Models.UIModels;

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
            ImportSteps importSteps = new ImportSteps(Driver);
            ProjectSteps projectSteps = new ProjectSteps(Driver);
            ProjectRepositoryPage projectRepositoryPage = new ProjectRepositoryPage(Driver);
            var uploadFile = "schema.json";
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources", uploadFile);
            Project project = new Project.Builder()
                .SetName("ReproductionBugTest")
                .SetCode("Repro")
                .Build();

            loginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            projectSteps.CreateProject(project);
            importSteps.ImportCase(filePath);

            Assert.That(projectRepositoryPage.GetImportErrorMessageText(), Is.EqualTo("Unable to import file. Invalid file structure"));
        }
    }
}*/