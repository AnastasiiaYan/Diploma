/* проверка поля для ввода на граничные значения + ввод данных превышающих допустимые */

using Diploma.Helpers.Configuration;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;
using Diploma.Tests.UITests;
using OpenQA.Selenium;

namespace Diploma.Tests.UITests
{
    internal class BoundaryInputTest : BaseTest
    {
        [Test]
        public void NotEnoughInputTest()
        {
            CreateAccounSteps createAccounSteps = new CreateAccounSteps(Driver);
            CreateAccountPage createAccountPage = new CreateAccountPage(Driver);
            var newEmail = "aytestqa11@gmail.com";
            var notEnoughPsw = "Qa111111.11";
            var pswConfirmInput = notEnoughPsw;

            createAccounSteps.Registration(newEmail, notEnoughPsw, pswConfirmInput);

            Assert.Multiple(() =>
            {
                Assert.That(createAccountPage.GetPasswordWarningText(), Is.EqualTo("Password must has at least 12 characters"));
                Assert.That(createAccountPage.IsPageOpened());
            });
        }

        //добавить тест точное граничное значение?

        [Test]
        public void ToolargeInputTest()
        {
            CreateAccounSteps createAccounSteps = new CreateAccounSteps(Driver);
            CreateAccountPage createAccountPage = new CreateAccountPage(Driver);
            var toolargeEmail = "aytestqaaqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqpqz@gmail.com";// на 1 символ больше допустимого, можно улучшить рандомайзером

            createAccounSteps.Registration (toolargeEmail, Configurator.AppSettings.Password, Configurator.AppSettings.Password);   

            Assert.Multiple(() =>
            {
                Assert.That(createAccountPage.GetEmailWarningText(), Is.EqualTo($"Value '{toolargeEmail}' does not match format email of type string"));
                Assert.That(createAccountPage.IsPageOpened());
            });
        }
    }
}