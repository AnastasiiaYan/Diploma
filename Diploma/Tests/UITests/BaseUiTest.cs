﻿using OpenQA.Selenium;
using Diploma.Core;
using Diploma.Helpers;
using Diploma.Helpers.Configuration;
using Allure.Net.Commons;
//using Allure.NUnit;
using Diploma.Objects.Steps;
using System.Text;
using NUnit.Allure.Core;
using Allure.NUnit.Attributes;

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