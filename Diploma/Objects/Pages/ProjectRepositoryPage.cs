using OpenQA.Selenium;

namespace Diploma.Objects.Pages
{
    public class ProjectRepositoryPage : BasePage
    {
        public ProjectRepositoryPage(IWebDriver driver) : base(driver) { }

        private static readonly By headerElement = By.CssSelector("h1.pOpqJc");
        private static readonly By importButton = By.XPath("//button[@class='G1dmaA ecSEF_ IAcAWv']/span[text()='Import']");
        private static readonly By chooseFileButton = By.XPath("//div/label/input[@type='file']");
        private static readonly By importTestsButton = By.XPath("//button[@class='G1dmaA ecSEF_ IAcAWv' and @type='submit']");
        private static readonly By importErrorMessage = By.XPath("//span[@class='xtWHgv']");
        private static readonly By uploadCase = By.CssSelector(".YkyiUm.t1vo_q");        

        public IWebElement HeaderElement => WaitsHelper.WaitForExists(headerElement);
        public IWebElement ImportButton => WaitsHelper.WaitForExists(importButton);
        public IWebElement ChooseFileButton => WaitsHelper.WaitForExists(chooseFileButton);
        public IWebElement ImportTestsButton => WaitsHelper.WaitForExists(importTestsButton);
        public IWebElement ImportErrorMessage => WaitsHelper.WaitForExists(importErrorMessage);
        public IWebElement UploadCase => WaitsHelper.WaitForExists(uploadCase);        

        public void ClickImportButton() => ImportButton.Click();
        public void ClickImportTestsButton() => ImportTestsButton.Click();
        public void SendKeysIntoEmailInputField(string input) => ChooseFileButton.SendKeys(input);
        public string GetHeaderElementText() => HeaderElement.Text;
        public string GetImportErrorMessageText() => ImportErrorMessage.Text;        
        public string GetUploadCaseText() => UploadCase.Text;
        public override bool IsPageOpened() 
        {
            if (HeaderElement.Displayed)
            {
                _logger.Debug("Открыт репозиторий проекта");
                return true;
            }
            return false;
        }
    }
}