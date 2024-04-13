/* проверка всплывающего сообщения */

using OpenQA.Selenium;

namespace Diploma.Tests.UITests
{
    internal class MessageTest : BaseTest
    {
        [Test]
        public void PopUpMessageTest()
        {
            //базовый степ логин
            Driver.Navigate().GoToUrl("https://qase.io/");

            IWebElement mainSigninButton = Driver.FindElement(By.Id("signin"));
            mainSigninButton.Click();

            IWebElement emailInput = Driver.FindElement(By.Name("email"));
            emailInput.SendKeys("aytestqa@gmail.com");
            IWebElement pswInput = Driver.FindElement(By.Name("password"));
            pswInput.SendKeys("qwertyTMS24.");
            IWebElement signInButton = Driver.FindElement(By.CssSelector("button[type= 'submit']"));
            signInButton.Click();

            //сам кейс
            Thread.Sleep(4000);//тут должен быть вейтхелпер
            IWebElement element = Driver.FindElement(By.CssSelector(".b5tgEy [aria-label='Notifications']"));
            Assert.That(element.GetAttribute("data-balloon-pos").Contains("down"));
        }
    }
}