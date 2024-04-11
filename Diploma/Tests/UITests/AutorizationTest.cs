using Diploma.Tests.UITests;
using OpenQA.Selenium;

namespace Diploma.Tests
{
    internal class AutorizationTests : BaseTest
    {
        [Test]   //это будет BASESTEP    
        public void SuccessfulAuthorizationTest()
        {
            Driver.Navigate().GoToUrl("https://qase.io/");            

            IWebElement mainSigninButton = Driver.FindElement(By.Id("signin"));
            mainSigninButton.Click();            

            IWebElement emailInput = Driver.FindElement(By.Name("email"));
            emailInput.SendKeys("aytestqa@gmail.com");
            IWebElement pswInput = Driver.FindElement(By.Name("password"));
            pswInput.SendKeys("qwertyTMS24.");

            IWebElement signInButton = Driver.FindElement(By.CssSelector("button[type= 'submit']"));
            signInButton.Click();
            Thread.Sleep(2000);//тут должен быть вейтхелпер                     
            
            Assert.That(IsPageOpened());//тут должно обыть описание страницы отдельным файлом
        }        
    }    
}