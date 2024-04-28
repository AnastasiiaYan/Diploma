using System.Reflection;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using Diploma.Helpers.Configuration;
using Diploma.Models.UIModels;
using Diploma.Objects;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;
using OpenQA.Selenium.Interactions;

namespace Diploma.Tests.UITests
{
    [TestFixture]
    internal class UITests : BaseUiTest
    {
        Random random = new Random();
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        User user = new User(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        public void SuccessfulLoginTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectsPage projectsPage = new ProjectsPage(Driver);
           
            loginSteps.Login(user); 

            Assert.That(projectsPage.IsPageOpened());
        }
        [Test]
        [AllureFeature("Создание новой сущности: проект"), Order(1), AllureSeverity(SeverityLevel.critical)]
        public void CreateProjectTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectSteps projectSteps = new ProjectSteps(Driver);
            ProjectRepositoryPage projectRepositoryPage = new ProjectRepositoryPage(Driver);
            Project project = new Project.Builder()
                .SetName("CreateToRemove")
                .SetCode("TOREMOVE")
                .SetDescription("TestDescription")
                .Build();

            loginSteps.Login(user);
            projectSteps.CreateProject(project);

            Assert.That(projectRepositoryPage.GetHeaderElementText(), Does.Contain($"{project.Code} repository"));
        }

        [Test]
        [AllureFeature("Удаление сущности: проект"), Order(2), AllureSeverity(SeverityLevel.normal)]
        public void RemoveProjectTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectSteps projectSteps = new ProjectSteps(Driver);
            ProjectsPage projectsPage = new ProjectsPage(Driver);

            loginSteps.Login(user);
            projectSteps.RemoveProject();

            Assert.IsFalse(projectsPage.IsProjectExist());
        }

        [AllureSubSuite("Проверка поля для ввода на граничные значения")]
        [Test(Description = "NotEnoughInputTest"), AllureFeature("Ввод граничного значения минус один")]
        public void NotEnoughInputTest()
        {
            CreateAccounSteps createAccounSteps = new CreateAccounSteps(Driver);
            CreateAccountPage createAccountPage = new CreateAccountPage(Driver);            
            User newUser = new User("createNewUser@gmail.com", "Lessthan12.");

            createAccounSteps.Registration(newUser); 

            Assert.Multiple(() =>
            {
                Assert.That(createAccountPage.GetPasswordWarningText(), Is.EqualTo("Password must has at least 12 characters"));
                Assert.That(createAccountPage.IsPageOpened());
            });
        }

        [Test(Description = "ExactBoundaryInputTest")]
        [AllureFeature("Ввод граничного значения")]
        public void ExactBoundaryInputTest()
        {
            CreateAccounSteps createAccounSteps = new CreateAccounSteps(Driver);
            CreateAccountPage createAccountPage = new CreateAccountPage(Driver);
            string exactRandStr = new string(Enumerable.Repeat(chars, 64).Select(s => s[random.Next(s.Length)]).ToArray());                      
            User newUser = new User($"{exactRandStr}@gmail.com", "Exactly12Ch.");

            createAccounSteps.Registration(newUser); 

            Assert.That(createAccountPage.IsPageSuccessCreatedOpened());
        }

        [Test(Description = "ToolargeInputTest")]
        [AllureFeature("Ввод граничного значения плюс один")]
        public void ToolargeInputTest()
        {
            CreateAccounSteps createAccounSteps = new CreateAccounSteps(Driver);
            CreateAccountPage createAccountPage = new CreateAccountPage(Driver);
            string tooLargeRandStr = new string(Enumerable.Repeat(chars, 65).Select(s => s[random.Next(s.Length)]).ToArray());            
            User newUser = new User($"{tooLargeRandStr}@gmail.com", "Exactly12Ch.");
            createAccounSteps.Registration(newUser); 

            Assert.Multiple(() =>
            {
                Assert.That(createAccountPage.GetEmailWarningText(), Is.EqualTo($"Value '{tooLargeRandStr}'@gmail.com does not match format email of type string"));
                Assert.That(createAccountPage.IsPageOpened());
            });
        }

        [Test]
        [AllureFeature("Ввод некорректных данных при авторизации"), AllureSeverity(SeverityLevel.critical)]
        public void InvalidLoginTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            LoginPage loginPage = new LoginPage(Driver);
            User invalidPswUser = new User(Configurator.AppSettings.Username, "invalidPassword");
            
            loginSteps.Login(invalidPswUser);            

            Assert.Multiple(() =>
            {
                Assert.That(loginPage.GetErrorLoginAlertText(), Is.EqualTo("These credentials do not match our records."));
                Assert.That(loginPage.IsPageOpened());
            });
        }

        [Test]
        [AllureSeverity(SeverityLevel.minor)]
        public void PopUpMessageTest()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            ProjectsPage projectsPage = new ProjectsPage(Driver);
            Actions action = new Actions(Driver);
            var expectedMessage = "Notifications";

            loginSteps.Login(user); 
            var actualMessage = projectsPage.MessageElement.GetAttribute("aria-label");
            action.MoveToElement(projectsPage.MessageElement, 5, 5).Build().Perform();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        [AllureSeverity(SeverityLevel.blocker), AllureIssue("JIRA-123")]
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

            loginSteps.Login(user);
            projectSteps.CreateProject(project);
            importSteps.ImportCase(filePath);

            Assert.That(projectRepositoryPage.GetImportErrorMessageText(), Is.EqualTo("Unable to import file. Invalid file structure"));
        }

        [Test]
        [AllureSeverity(SeverityLevel.normal)]
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

            loginSteps.Login(user);
            projectSteps.CreateProject(project);
            importSteps.ImportCase(filePath);

            Assert.That(projectRepositoryPage.GetUploadCaseText(), Is.EqualTo(caseTitle));
        }
    }
}