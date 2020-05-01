using AutomationTest.Framework;
using OpenQA.Selenium;

namespace AutomationTest.PageObject
{
    public class User : PageObjectBase
    {
        private static readonly By ByEmail = By.ClassName("form-control");
        private static readonly By ByPassword = By.XPath("//div[@class='input-group js-parent-focus']//input[@class='form-control js-child-focus js-visible-password']");
        private static readonly By Login = By.Id("submit-login");
        public User(IWebDriver driver) : base(driver)
        {
        }
        private void InputData(By byType, string data)
        {
            Driver.FindElement(byType).SendKeys(data);
        }
        private void InputData(By byType)
        {
            Driver.FindElement(byType).Click();
        }
        public User LoginUser()
        {
            InputData(ByEmail, Settings.Email);
            InputData(ByPassword, Settings.Password);
            InputData(Login);
            return this;
        }
    }
}