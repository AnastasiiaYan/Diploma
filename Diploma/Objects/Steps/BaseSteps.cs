using OpenQA.Selenium;

namespace Diploma.Objects.Steps
{
    public class BaseSteps
    {
        protected IWebDriver Driver;

        public BaseSteps(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}