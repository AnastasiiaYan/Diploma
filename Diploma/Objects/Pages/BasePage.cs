using Diploma.Helpers;
using OpenQA.Selenium;
using Diploma.Helpers.Configuration;

namespace Diploma.Objects.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver {  get; set; }
        protected WaitsHelper WaitsHelper { get; set; }

        public BasePage(IWebDriver driver) 
        {
            Driver = driver;
            WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));
        }
    }
}