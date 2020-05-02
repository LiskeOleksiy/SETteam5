using System;
using System.Linq;
using AutomationTest.Framework;
using OpenQA.Selenium;
using Selenium1.Framework;

namespace AutomationTest.PageObject
{
    public class Contact : PageObjectBase
    {
        private static readonly By SubmitMessage =
            By.XPath("//footer[@class='form-footer text-sm-right']//input[@class='btn btn-primary']");
        private static readonly By IsDataValid =
            By.XPath(
                "//form[@action='http://52.177.12.77:8080/uk/contact-us']//div[@class='col-xs-12 alert alert-danger']");
        private static readonly By ByEmail =
            By.XPath("//div[@class='col-md-6']//input[@class='form-control']");
        private static readonly By ByMessage =
            By.XPath("//div[@class='col-md-9']//textarea[@class='form-control']");
        public Contact(IWebDriver driver) : base(driver)
        {
        }
        public bool IsDataOk()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            bool isOk = Wait.WaitFor(() => Driver.FindElements(IsDataValid).Any());
            Driver.Manage().Timeouts().ImplicitWait = Settings.ImplicitWait;
            return isOk;
        }
        public Contact EnterData(string email, string message)
        {
            InputData(ByEmail, email);
            InputData(ByMessage, message);          
            return this;
        }
        public Contact SubmitNewMessage()
        {
            InputData(SubmitMessage);
            return this;
        }
    }
}