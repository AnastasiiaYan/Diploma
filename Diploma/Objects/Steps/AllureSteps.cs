using Allure.Net.Commons;
using Allure.NUnit;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Diploma.Objects.Steps
{
    public class AllureSteps : BaseSteps
    {
        public AllureSteps(IWebDriver driver) : base(driver)
        {
        }

        [AllureStep("Test {url}")]
        public void TestDomain([Name("Webpage URL")] string url)
        {
            // Добавление дополнительной информации
            AllureLifecycle.Instance.UpdateStep(stepResult =>
                stepResult.parameters.Add(
                    new Parameter
                    {
                        name = "Started at",
                        value = DateTime.Now.ToString()
                    }
                )
            );            
        }        
    }
}