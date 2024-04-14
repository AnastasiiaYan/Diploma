﻿using Diploma.Helpers;
using OpenQA.Selenium;

namespace Diploma.Objects.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private static readonly By emailInputField = By.Name("email");
        private static readonly By passwordInputField = By.Name("password");
        private static readonly By submitButton = By.CssSelector("button[type= 'submit']");
        private static readonly By errorLoginAlert = By.ClassName("xtWHgv");

        public IWebElement EmailInputField => WaitsHelper.WaitForExists(emailInputField);
        public IWebElement PasswordInputField => WaitsHelper.WaitForExists(passwordInputField);
        public IWebElement SubmitButton => WaitsHelper.WaitForExists(submitButton);
        public IWebElement ErrorLoginAlerrt =>  WaitsHelper.WaitForExists(errorLoginAlert);

        public void SendKeysIntoEmailInputField(string input) => EmailInputField.SendKeys(input);        
        public void SendKeysIntoPasswordInputField(string input) => PasswordInputField.SendKeys(input);        
        public void ClickOnSubmitButton() => SubmitButton.Click();

        public string GetErrorLoginAlertText() 
        {
            return ErrorLoginAlerrt.Text;
        }
        public override bool IsPageOpened()
        {
            return EmailInputField.Displayed && PasswordInputField.Displayed;
        }
    }
}