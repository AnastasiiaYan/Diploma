using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Objects.Pages
{
    public class ProjectRepositoryPage : BasePage
    {
        public ProjectRepositoryPage(IWebDriver driver) : base(driver) { }

        private static readonly By headerElement = By.CssSelector("h1.pOpqJc");       

        public IWebElement HeaderElement => WaitsHelper.WaitForExists(headerElement);

        //public void ClickImpotButton() => ImpotButton.Click();   
        public override bool IsPageOpened() => HeaderElement.Displayed;        
    }
}