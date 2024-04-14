using OpenQA.Selenium;
using Diploma.Core;
using Diploma.Helpers;
using Diploma.Helpers.Configuration;

namespace Diploma.Tests.UITests;

[Parallelizable(scope: ParallelScope.All)] //параллелизация запусков
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)] //отдельный экземпляр для каждого
public class BaseTest
{
    protected IWebDriver Driver { get; set; }
    protected WaitsHelper WaitsHelper { get; private set; }

    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;
        WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
    public bool IsPageOpened()
    {
        try
        {
            Driver.FindElement(By.ClassName("mTiiQU"));
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}