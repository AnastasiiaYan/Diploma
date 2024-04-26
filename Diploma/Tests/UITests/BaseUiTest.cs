using System.Text;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using Diploma.Core;
using Diploma.Core.Clients;
using Diploma.Helpers;
using Diploma.Helpers.Configuration;
using Diploma.Services.Projects;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Diploma.Tests.UITests
{
    [Parallelizable(scope: ParallelScope.All)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [AllureNUnit]
    [AllureOwner("A.SAMOYLOVA")]
    public class BaseUiTest
    {
        protected IWebDriver Driver { get; set; }
        protected WaitsHelper WaitsHelper { get; private set; }
        protected static ProjectsService ProjectsService { get; set; }

        [OneTimeSetUp]
        public static void GlobalSetup()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;
            WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                    byte[] screenshotBytes = screenshot.AsByteArray;

                    AllureApi.AddAttachment("data.txt", "text/plain",
                        Encoding.UTF8.GetBytes("This is the file content."));
                    AllureApi.AddAttachment("Screenshot", "image/png", screenshotBytes);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            finally
            {
                Driver.Quit();
            }
        }
        [OneTimeTearDown]
        public static void CleanProjectsAfterTests()
        {
            ProjectsService = new ProjectsService(new ApiRestClient());
            var allProjectEntity = ProjectsService.GetAllProjects().Result.Result.ProjectEntities;
            if (allProjectEntity.Count > 0)
            {
                foreach (var entity in allProjectEntity)
                {
                    ProjectsService.DeleteProjectByCode(entity.Code);
                    Thread.Sleep(1000);
                }
            }
        }
    }
}