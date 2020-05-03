using OpenQA.Selenium;

namespace AutomationTest.PageObject
{
    public class Accessories : PageObjectBase
    {
        private static readonly By ChooseAccessoriesButton =
            By.XPath("/ html / body / main / header / div[2] / div / div[1] / div[2] / div[1] / ul / li[2] / a");
        public Accessories(IWebDriver driver) : base(driver)
        {
        }
        public Accessories ChooseAccessories()
        {
            InputData(ChooseAccessoriesButton);
            return this;

            public Accessories ClickSort()
            {
                InputData(SortButton);
                return this;
            }
    }
}
