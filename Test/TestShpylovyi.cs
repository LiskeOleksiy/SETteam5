using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using AutomationTest.Framework;
using AutomationTest.PageObject;
using NUnit.Framework;

namespace AutomationTest.Test
{
    [TestFixture]
    public class Test2
    {
        private static readonly TimeSpan ImplicitWait = TimeSpan.FromMilliseconds(Convert.ToInt32("3000"));
        private IWebDriver _driver;
        private MainPage _mainPage;
        private void DriverSettings()
       
        {
           
        }

    }
}