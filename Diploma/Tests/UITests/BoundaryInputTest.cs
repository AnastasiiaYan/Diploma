using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Diploma.Helpers.Configuration;
using Diploma.Objects.Pages;
using Diploma.Objects.Steps;

namespace Diploma.Tests.UITests
{
    [AllureSubSuite("Проверка поля для ввода на граничные значения + ввод данных превышающих допустимые")]
    internal class BoundaryInputTest : BaseUiTest
    {
        [Test(Description = "NotEnoughInputTest")]
        [AllureFeature("Ввод граничного значения минус один")]
        public void NotEnoughInputTest()
        {
            CreateAccounSteps createAccounSteps = new CreateAccounSteps(Driver);
            CreateAccountPage createAccountPage = new CreateAccountPage(Driver);
            var newEmail = "aytestqa11@gmail.com";
            var notEnoughPsw = "Qa111111.11";
            var pswConfirmInput = notEnoughPsw;

            AllureApi.Step("Ввод значения Password на 1 символ меньше допустимого");
            createAccounSteps.Registration(newEmail, notEnoughPsw, pswConfirmInput);

            Assert.Multiple(() =>
            {
                Assert.That(createAccountPage.GetPasswordWarningText(), Is.EqualTo("Password must has at least 12 characters"));
                Assert.That(createAccountPage.IsPageOpened());
            });
        }

        [Test(Description = "ExactBoundaryInputTest")]
        [AllureFeature("Ввод граничного значения")]
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

        [Test(Description = "ToolargeInputTest")]
        [AllureFeature("Ввод граничного значения плюс один")]
        public void ToolargeInputTest()
        {
            CreateAccounSteps createAccounSteps = new CreateAccounSteps(Driver);
            CreateAccountPage createAccountPage = new CreateAccountPage(Driver);
            var toolargeEmail = "aytestqaaqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqpqz@gmail.com";// на 1 символ больше допустимого, можно улучшить рандомайзером
            
            AllureApi.Step("Ввод значения Email на 1 символ больше допустимого");
            createAccounSteps.Registration (toolargeEmail, Configurator.AppSettings.Password, Configurator.AppSettings.Password);   

            Assert.Multiple(() =>
            {
                Assert.That(createAccountPage.GetEmailWarningText(), Is.EqualTo($"Value '{toolargeEmail}' does not match format email of type string"));
                Assert.That(createAccountPage.IsPageOpened());
            });
        }
    }
}