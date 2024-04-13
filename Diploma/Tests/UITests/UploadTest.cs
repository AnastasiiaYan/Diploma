/* тест на загрузку файла */

using java.awt;
using OpenQA.Selenium;
using System.Reflection;

namespace Diploma.Tests.UITests
{
    internal class UploadTest : BaseTest
    {
        [Test]
        public void UploadFileTest()
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
            Thread.Sleep(8000);
            IWebElement projectArea = Driver.FindElement(By.CssSelector("a[href= '/project/23']"));
            projectArea.Click();
            Thread.Sleep(8000);
            IWebElement importButton = Driver.FindElement(By.XPath("//button[@class='G1dmaA ecSEF_ IAcAWv']/span[text()='Import']"));
            importButton.Click();
            Thread.Sleep(4000);

            IWebElement fileInput = Driver.FindElement(By.XPath("//div/label/input[@type='file']"));
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); //путь к исполняемому файлу в каталоге
            var filePath = Path.Combine(assemblyPath, "Resources", "case.json"); //путь к файлу внутри проекта
            Thread.Sleep(3000);
            fileInput.SendKeys(filePath);
            Thread.Sleep(3000);
            IWebElement importTestsButton = Driver.FindElement(By.XPath("//button[@class='G1dmaA ecSEF_ IAcAWv' and @type='submit']"));
            importTestsButton.Click();
            Thread.Sleep(10000);

            IWebElement uploadElement = Driver.FindElement(By.CssSelector(".YkyiUm.t1vo_q"));
            Assert.That(uploadElement.Text, Is.EqualTo("Upload"));
        }
    }
}