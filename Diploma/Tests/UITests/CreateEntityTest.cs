/* создание сущности + отображениe диалогового окна */

using OpenQA.Selenium;

namespace Diploma.Tests.UITests
{
    public class CreateEntityTest : BaseTest
    {
        [Test]
        public void CreateProjectTest()
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
            Thread.Sleep(2000);//тут должен быть вейтхелпер                     
            Assert.That(IsPageOpened());//тут должно обыть описание страницы отдельным файлом

            //сам тест на создание сущности 
            IWebElement createButton = Driver.FindElement(By.Id("createButton"));
            createButton.Click();
            Thread.Sleep(3000);
            IWebElement projectNameInput = Driver.FindElement(By.Id("project-name"));
            projectNameInput.SendKeys("CreateProjectTest"); // для уникального значения если понадобится добавлю рандомное число в конце
            Thread.Sleep(3000);

            Thread.Sleep(3000);
            IWebElement createProjButton = Driver.FindElement(By.CssSelector("button[type= 'submit']"));
            createProjButton.Click();
            Thread.Sleep(5000);

            IWebElement headerElement = Driver.FindElement(By.CssSelector("h1.pOpqJc"));
            Assert.That(headerElement.Text, Does.Contain("CREATEPROJ repository"));
        }
    }
}