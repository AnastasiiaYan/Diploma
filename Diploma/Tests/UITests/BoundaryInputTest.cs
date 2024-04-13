/* проверка поля для ввода на граничные значения + ввод данных превышающих допустимые + проверка всплывающего сообщения */

using Diploma.Tests.UITests;
using OpenQA.Selenium;

namespace Diploma.Tests
{
    internal class BoundaryInputTest : BaseTest
    {
        [Test]
        public void NotEnoughInputTest()
        {
            Driver.Navigate().GoToUrl("https://app.qase.io/signup");
            Thread.Sleep(2000);//тут должен быть вейтхелпер          

            IWebElement emailInput = Driver.FindElement(By.Name("email"));
            emailInput.SendKeys("aytestqaa@gmail.com");
            IWebElement pswInput = Driver.FindElement(By.Name("password"));
            pswInput.SendKeys("Qa111111.11");
            IWebElement pswConfirmInput = Driver.FindElement(By.Name("passwordConfirmation"));
            pswConfirmInput.SendKeys("Qa111111.11");
            IWebElement signInButton = Driver.FindElement(By.CssSelector("button[type= 'submit']"));
            signInButton.Click();
            Thread.Sleep(2000);//тут должен быть вейтхелпер 

            IWebElement passwordWarning = Driver.FindElement(By.XPath("//small[@class='f75Cb_' and text()='Password must has at least 12 characters']"));
        }
        [Test]
        public void TooMuchInputTest()
        {
            Driver.Navigate().GoToUrl("https://app.qase.io/signup");
            Thread.Sleep(2000);//тут должен быть вейтхелпер          

            IWebElement emailInput = Driver.FindElement(By.Name("email"));
            emailInput.SendKeys("aytestqaaqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqpqz@gmail.com"); // на 1 символ больше допустимого, можно улучшить рандомайзером
            IWebElement pswInput = Driver.FindElement(By.Name("password"));
            pswInput.SendKeys("Qa111111.1112");
            IWebElement pswConfirmInput = Driver.FindElement(By.Name("passwordConfirmation"));
            pswConfirmInput.SendKeys("Qa111111.1112");
            IWebElement signInButton = Driver.FindElement(By.CssSelector("button[type= 'submit']"));
            signInButton.Click();
            Thread.Sleep(500);//тут должен быть вейтхелпер 

            IWebElement emailError = Driver.FindElement(By.XPath("//span[@class='xtWHgv' and text()=\"Value 'aytestqaaqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqpqz@gmail.com' does not match format email of type string\"]"));
        }
    }
}