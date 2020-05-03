using System;
using System.Collections.Generic;
using AutomationTest.Framework;
using OpenQA.Selenium;

namespace AutomationTest.PageObject
{
    public class Currency : PageObjectBase
    {
        private static readonly By CurrencyDropdownButton =
            By.XPath("//*[@id='_desktop_currency_selector']/div/button/span");
        static readonly Dictionary<char, By> CurrencyType = new Dictionary<char, By>()
        {
            {'$', By.XPath("//*[@id='_desktop_currency_selector']/div/ul/li[3]/a")},
            {'€', By.XPath("//*[@id='_desktop_currency_selector']/div/ul/li[1]/a")},
            {'₴', By.XPath("//*[@id='_desktop_currency_selector']/div/ul/li[2]/a")},
        };
        public Currency(IWebDriver driver) : base(driver)
        {
        }
        public void OpenCurrencyDropdown()
        {
            InputData(CurrencyDropdownButton);
        }

        public Currency ChooseCurrency(char currency)
        {
            OpenCurrencyDropdown();
            InputData(CurrencyType[currency]);
            return this;
        }
        public bool IsCurrencyOk(char currency)
        {

            IWebElement priceText =
                Driver.FindElement(By.XPath("//*[@id='search_filters']"));
//*[@id="facet_label_76345"]
//*[@id="search_filters"]/section[3]
//*[@id="search_filters"]/section[3]
//*[@id="search_filters"]/section[6]
//*[@id="search_filters"]
            //By.XPath("//ul[@id='footer_sub_menu_84186']//a[@id='link-static-page-contact-2']");
            return priceText.Text.Contains(currency);
        }

    }
}