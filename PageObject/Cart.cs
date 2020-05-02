using OpenQA.Selenium;

namespace AutomationTest.PageObject
{
    public class Cart : PageObjectBase
    {
        private static readonly By AddToCartButton =
            By.XPath("//*[@id='add-to-cart-or-refresh']/div[2]/div/div[2]/button");
        private static readonly By ProceedButton =
            By.XPath("//*[@id='blockcart-modal']/div/div/div[2]/div/div[2]/div/div/a");
        
        public Cart(IWebDriver driver) : base(driver)
        {
        } 
        public Cart AddToCart()
        {
            InputData(AddToCartButton);
            return this;
        }
        public Cart Proceed()
        {
            InputData(ProceedButton);
            return this;
        }
    }
}