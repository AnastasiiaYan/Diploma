using NLog;
using OpenQA.Selenium;

namespace Diploma.Objects.Steps
{
    public class BaseSteps
    {
        protected readonly Logger _logger = LogManager.GetCurrentClassLogger();
        protected IWebDriver Driver;

        public BaseSteps(IWebDriver driver)
        {
            Driver = driver;
        }       
    }
}