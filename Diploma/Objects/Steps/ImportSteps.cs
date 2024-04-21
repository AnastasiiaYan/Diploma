using Allure.NUnit.Attributes;
using Diploma.Objects.Pages;
using OpenQA.Selenium;

namespace Diploma.Objects.Steps
{
    public class ImportSteps : BaseSteps
    {
        ProjectRepositoryPage projectRepositoryPage;
        public ImportSteps(IWebDriver driver) : base(driver) 
        {
            projectRepositoryPage = new ProjectRepositoryPage(driver);            
        }                      
            
        [AllureStep]
        public void ImportCase(string filePath)
        {
            projectRepositoryPage.ClickImportButton();
            projectRepositoryPage.SendKeysIntoEmailInputField(filePath);
            projectRepositoryPage.ClickImportTestsButton();
        }        
    }
}