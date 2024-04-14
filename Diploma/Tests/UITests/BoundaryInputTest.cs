/* проверка поля для ввода на граничные значения + ввод данных превышающих допустимые */

using Diploma.Helpers.Configuration;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;

namespace Diploma.Tests.UITests
{
    internal class BoundaryInputTest : BaseUiTest
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

        [Test]
        public void ExactBoundaryInputTest()
        {
            CreateAccounSteps createAccounSteps = new CreateAccounSteps(Driver);
            CreateAccountPage createAccountPage = new CreateAccountPage(Driver);
            var exactBoundaryEmail = "cytestqaaqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqpq@gmail.com"; //можно улучшить рандомайзером
            var exactBoundaryPsw = "Qa111111.112";
            var pswConfirmInput = exactBoundaryPsw;

            createAccounSteps.Registration(exactBoundaryEmail, exactBoundaryPsw, pswConfirmInput);

            Assert.Multiple(() =>
            {
                Assert.That(!createAccountPage.IsPageOpened());
                Assert.That(!createAccountPage.EmailWarning.Displayed);
                Assert.That(!createAccountPage.PasswordWarning.Displayed);
            });
        }

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