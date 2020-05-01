using OpenQA.Selenium;

namespace AutomationTest.PageObject
{
    public class MainPage : PageObjectBase
    {
        private static readonly By SigninButton = By.XPath("//*[@id='_desktop_user_info']/div/a[@href='http://52.177.12.77:8080/uk/my-account']");
        public MainPage(IWebDriver driver) : base(driver)
        {}
        public User OpenLoginPage()
                {
                    Driver.FindElement(SigninButton).Click();
                    return new User(Driver);
                }
    }
}