﻿using Diploma.Helpers;
using OpenQA.Selenium;
using Diploma.Helpers.Configuration;
using NLog;

namespace Diploma.Objects.Pages
{
    public abstract class BasePage
    {
        protected readonly Logger _logger = LogManager.GetCurrentClassLogger();
        protected IWebDriver Driver {  get; set; }
        protected WaitsHelper WaitsHelper { get; set; }       
        public BasePage(IWebDriver driver, bool openPageByUrl = true) 
        {
            Driver = driver;
            WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));

            if (openPageByUrl)
            {
                OpenPageByURL();
            }
        }

        protected void OpenPageByURL()
        {
            Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
        }

        public abstract bool IsPageOpened();
    }
}