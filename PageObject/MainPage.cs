using AutomationTest.Framework;
using OpenQA.Selenium;

namespace AutomationTest.PageObject
{
    public class MainPage : PageObjectBase
    {
        private static readonly By SigninButton =
            By.XPath("//*[@id='_desktop_user_info']/div/a[@href='http://52.177.12.77:8080/uk/my-account']");
        private static readonly By ContactButton =
            By.XPath("//ul[@id='footer_sub_menu_84186']//a[@id='link-static-page-contact-2']");

        public MainPage(IWebDriver driver) : base(driver)
        {}
        public User OpenLoginPage()
                {
                    Driver.FindElement(SigninButton).Click();
                    return new User(Driver);
                }
        public User OpenStartPage()
        {
            Driver.Navigate().GoToUrl(Settings.Url);
            return new User(Driver);
        }
        public Contact OpenContactPage()
        {
            Driver.FindElement(ContactButton).Click();
            return new Contact(Driver);
        }
        public Currency CreateCurrency()
        {
           return new Currency(Driver);
        }
    }
}