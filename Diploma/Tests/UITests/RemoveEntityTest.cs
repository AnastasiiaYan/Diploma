/* тест на удаление сущности */

using OpenQA.Selenium;

namespace Diploma.Tests.UITests
{
    public class RemoveEntityTest : BaseUiTest
    {
        [Test]
        public void RemoveProjectTest()
        {
            //базовый шаг авторизации:
            Driver.Navigate().GoToUrl("https://qase.io/");

            IWebElement mainSigninButton = Driver.FindElement(By.Id("signin"));
            mainSigninButton.Click();

            IWebElement emailInput = Driver.FindElement(By.Name("email"));
            emailInput.SendKeys("aytestqa@gmail.com");
            IWebElement pswInput = Driver.FindElement(By.Name("password"));
            pswInput.SendKeys("qwertyTMS24.");

            IWebElement signInButton = Driver.FindElement(By.CssSelector("button[type= 'submit']"));
            signInButton.Click();

            //сам тест на удаление сущности             
            Thread.Sleep(4000); //без паузы падает вейтером решится
            //нахожу проект далее можно в метод есть/нет проект
            IWebElement project = Driver.FindElement(By.XPath("//div[@class='NFxRR3']/a[@class='cx2QU4' and @href='/project/CREATEPROJ' and text()='CreateProjectTest']"));

            IWebElement projectFild = Driver.FindElement(By.CssSelector("button.G1dmaA.eWFeX4.eij1r4"));
            Thread.Sleep(4000);
            projectFild.Click();
            IWebElement removeButton = Driver.FindElement(By.CssSelector("button.EehRY_.Wy99v3.fwhtHZ[tabindex=\"0\"][type=\"button\"][role=\"menuitem\"]"));
            removeButton.Click();
            Thread.Sleep(4000);
            IWebElement DelProjectButton = Driver.FindElement(By.CssSelector("button.G1dmaA.X8bxUI.IAcAWv"));
            DelProjectButton.Click();


            // Проверяем, что элемент не найден
            try
            {
                IWebElement isExistProject = Driver.FindElement(By.XPath("//div[@class='NFxRR3']/a[@class='cx2QU4' and @href='/project/CREATEPROJ' and text()='CreateProjectTest']"));

            }
            catch (NoSuchElementException)
            {
                // Если исключение выброшено, assert проходит
                Assert.Pass();
            }
        }
    }
}