/* 1 тест на использование некорректных данных */
using OpenQA.Selenium;

namespace Diploma.Tests.UITests
{
    internal class InvalidInputTest : BaseTest
    {
        [Test]
        public void InvalidInputAuthorizationTest() 
        {
            Driver.Navigate().GoToUrl("https://qase.io/"); //ссылка из конфига     

            IWebElement mainSigninButton = Driver.FindElement(By.Id("signin"));
            mainSigninButton.Click();

            IWebElement emailInput = Driver.FindElement(By.Name("email"));  
            emailInput.SendKeys("aytestqa@gmail.com");//из конфига
            IWebElement pswInput = Driver.FindElement(By.Name("password")); 
            pswInput.SendKeys("qwertyTMS."); //из конфига

            IWebElement signInButton = Driver.FindElement(By.CssSelector("button[type= 'submit']"));
            signInButton.Click();
            Thread.Sleep(1500);//тут должен быть вейтхелпер
            IWebElement errorAlert = Driver.FindElement(By.ClassName("xtWHgv"));

            Assert.Multiple(() =>
            {
                Assert.That(errorAlert.Text, Is.EqualTo("These credentials do not match our records."));
                Assert.That(!IsPageOpened());
            });
        }
    }
}