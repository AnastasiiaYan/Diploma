using OpenQA.Selenium;
using Diploma.Core;

namespace Diploma.Tests.UITests;

[Parallelizable(scope: ParallelScope.All)] //параллелизация запусков
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)] //отдельный экземпляр для каждого
public class BaseTest
{
    protected IWebDriver Driver { get; set; }

    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;

    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
    public bool IsPageOpened() //проверяется открытие станицы после логина
    {
        try
        {
            Driver.FindElement(By.ClassName("mTiiQU"));//попробовать переписать с подставлением page
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}