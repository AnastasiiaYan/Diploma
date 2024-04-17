using OpenQA.Selenium;
using Diploma.Core;
using Diploma.Helpers;
using Diploma.Helpers.Configuration;
using Allure.Net.Commons;
//using Allure.NUnit;
using Diploma.Objects.Steps;
using System.Text;
using NUnit.Allure.Core;

namespace Diploma.Tests.UITests
{
    [Parallelizable(scope: ParallelScope.All)] //параллелизация запусков
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)] //отдельный экземпляр для каждого
    [AllureNUnit]
    public class BaseUiTest
    {
        protected IWebDriver Driver { get; set; }
        protected WaitsHelper WaitsHelper { get; private set; }
        protected AllureSteps AllureSteps;

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
            AllureSteps = new AllureSteps(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            try 
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
                {
                    Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                    byte[] screenshotBytes = screenshot.AsByteArray;
                    // скрин области
                    //IWebElement element = Driver.FindElement(By.Id("SSS"));
                    //Screenshot screenshotElement = ((ITakesScreenshot)element).GetScreenshot();

                    // Прикрепление скриншота к отчету Allure
                    // Вариант 1
                    //AllureLifecycle.Instance.AddAttachment("Screenshot", "image/png", screenshotBytes);

                    // Вариант 2
                    AllureApi.AddAttachment(
                        "data.txt",
                        "text/plain",
                        Encoding.UTF8.GetBytes("This is the file content.")
                    );
                    AllureApi.AddAttachment(
                        "Screenshot",
                        "image/png",
                        screenshotBytes
                    );
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Driver.Quit();
        }
    }
}