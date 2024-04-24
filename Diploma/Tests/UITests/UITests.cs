using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using Diploma.Helpers.Configuration;
using Diploma.Models.UIModels;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Tests.UITests
{
    internal class UITests : BaseUiTest
    {
        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical), Order(3)]
        public void SuccessfulLoginTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectsPage projectsPage = new ProjectsPage(Driver);

            loginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

            Assert.That(projectsPage.IsPageOpened());
        }
        [Test]
        [AllureFeature("Создание новой сущности: проект"), Order(1)]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        public void CreateProjectTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectSteps projectSteps = new ProjectSteps(Driver);
            ProjectRepositoryPage projectRepositoryPage = new ProjectRepositoryPage(Driver);
            Project project = new Project.Builder()
                .SetName("TestTitle")
                .SetCode("Test")
                .SetDescription("TestDescription")
                .Build();

            loginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            projectSteps.CreateProject(project);

            Assert.That(projectRepositoryPage.GetHeaderElementText(), Does.Contain($"{project.Code} repository"));
        }

        [Test]
        [AllureFeature("Удаление сущности: проект"), Order(2), Retry(2)]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal)]
        public void RemoveProjectTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectSteps projectSteps = new ProjectSteps(Driver);
            ProjectsPage projectsPage = new ProjectsPage(Driver);

            loginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            Project project = new Project.Builder()
                .SetName("TOREMOVE")
                .SetCode("TOREM")
                .SetDescription("TestDescription")
                .Build();

            projectsPage.ClickProjectsButton();
            projectSteps.RemoveProject();

            Assert.IsFalse(projectsPage.IsProjectExist());
        }

        [AllureSubSuite("Проверка поля для ввода на граничные значения + ввод данных превышающих допустимые")]
        [Test(Description = "NotEnoughInputTest")]
        [AllureFeature("Ввод граничного значения минус один"), Order(3)]
        public void NotEnoughInputTest()
        {
                CreateAccounSteps createAccounSteps = new CreateAccounSteps(Driver);
                CreateAccountPage createAccountPage = new CreateAccountPage(Driver);
                var newEmail = "aytestqa11@gmail.com";
                var notEnoughPsw = "Qa111111.11";
                var pswConfirmInput = notEnoughPsw;

                AllureApi.Step("Ввод значения Password на 1 символ меньше допустимого");
                createAccounSteps.Registration(newEmail, notEnoughPsw, pswConfirmInput);

                Assert.Multiple(() =>
                {
                    Assert.That(createAccountPage.GetPasswordWarningText(), Is.EqualTo("Password must has at least 12 characters"));
                    Assert.That(createAccountPage.IsPageOpened());
                });
        }

        [Test(Description = "ExactBoundaryInputTest")]
        [AllureFeature("Ввод граничного значения"), Order(3)]
        public void ExactBoundaryInputTest()
        {
                CreateAccounSteps createAccounSteps = new CreateAccounSteps(Driver);
                CreateAccountPage createAccountPage = new CreateAccountPage(Driver);
                var exactBoundaryEmail = "dytestqaaqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqpq@gmail.com"; //можно улучшить рандомайзером
                var exactBoundaryPsw = "Qa111111.112";
                var pswConfirmInput = exactBoundaryPsw;

                createAccounSteps.Registration(exactBoundaryEmail, exactBoundaryPsw, pswConfirmInput);

                Assert.Multiple(() =>
                {
                    Assert.That(!createAccountPage.IsPageOpened());
                    Assert.That(!createAccountPage.EmailWarning.Displayed);
                    Assert.That(!createAccountPage.PasswordWarning.Displayed);
                });
        }
        
        [Test(Description = "ToolargeInputTest")]
        [AllureFeature("Ввод граничного значения плюс один"), Order(3)]
        public void ToolargeInputTest()
        {
                CreateAccounSteps createAccounSteps = new CreateAccounSteps(Driver);
                CreateAccountPage createAccountPage = new CreateAccountPage(Driver);
                var toolargeEmail = "aytestqaaqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqpqz@gmail.com";// на 1 символ больше допустимого, можно улучшить рандомайзером

                AllureApi.Step("Ввод значения Email на 1 символ больше допустимого");
                createAccounSteps.Registration(toolargeEmail, Configurator.AppSettings.Password, Configurator.AppSettings.Password);

                Assert.Multiple(() =>
                {
                    Assert.That(createAccountPage.GetEmailWarningText(), Is.EqualTo($"Value '{toolargeEmail}' does not match format email of type string"));
                    Assert.That(createAccountPage.IsPageOpened());
                });
        }

        [Test]
        [AllureFeature("Ввод некорректных данных при авторизации")]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical), Order(3)]
        public void InvalidLoginTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            LoginPage loginPage = new LoginPage(Driver);
            var invalidPassword = "invalidPassword";

            loginSteps.Login(Configurator.AppSettings.Username, invalidPassword);

            Assert.Multiple(() =>
            {
                Assert.That(loginPage.GetErrorLoginAlertText(), Is.EqualTo("These credentials do not match our records."));
                Assert.That(loginPage.IsPageOpened());
            });
        }

        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.minor), Order(3)]
        public void PopUpMessageTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectsPage projectsPage = new ProjectsPage(Driver);
            Actions action = new Actions(Driver);
            var expectedMessage = "Notifications";

            loginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            var actualMessage = projectsPage.MessageElement.GetAttribute("aria-label");
            action.MoveToElement(projectsPage.MessageElement, 5, 5).Build().Perform();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.blocker), Order(3)]
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

        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.normal), Order(3)]
        public void UploadFileTest()
        {

            LoginSteps loginSteps = new LoginSteps(Driver);
            ImportSteps importSteps = new ImportSteps(Driver);
            ProjectSteps projectSteps = new ProjectSteps(Driver);
            ProjectRepositoryPage projectRepositoryPage = new ProjectRepositoryPage(Driver);
            var uploadFile = "case.json";
            var caseTitle = "Upload";
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources", uploadFile);
            Project project = new Project.Builder()
                .SetName("UploadFileTest")
                .SetCode("Uplo")
                .Build();

            loginSteps.Login(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            projectSteps.CreateProject(project);
            importSteps.ImportCase(filePath);

            Assert.That(projectRepositoryPage.GetUploadCaseText(), Is.EqualTo(caseTitle));

            projectSteps.RemoveProject();
        }
    }
}