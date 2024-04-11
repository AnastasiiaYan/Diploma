using Diploma.Helpers.Configuration;
using OpenQA.Selenium;
using Diploma.Core;

namespace Diploma.Core
{
    public class Browser
    {
        public IWebDriver? Driver { get; }

        public Browser()
        {
            Driver = Configurator.BrowserType?.ToLower() switch
            {
                "chrome" => new DriverFactory().GetChromeDriver(),
                "firefox" => new DriverFactory().GetFirefoxDriver(),
                _ => Driver
            };

            Driver?.Manage().Window.Maximize();
            Driver?.Manage().Cookies.DeleteAllCookies();
            //Driver!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }
    }
}