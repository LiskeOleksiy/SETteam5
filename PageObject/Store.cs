using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using OpenQA.Selenium;

namespace AutomationTest.PageObject
{
    public class Store : PageObjectBase
    {
        private double FirstPrice { get; set; }
        private double SecondPrice { get; set; }
        private bool _check = false;
        
        private static readonly By OpenStoreButton = By.XPath("//*[@id='content']/section/a");
        private static readonly By SortButton = By.XPath("//*[@id='js-product-list-top']/div[2]/div/div[1]/button");
        private static readonly By ParseFirstPrice =
            By.XPath("//*[@id='js-product-list']/div[1]/article[1]/div/div[1]/div/span[2]");
        private static readonly By ParseSecondPrice =
            By.XPath("//*[@id='js-product-list']/div[1]/article[2]/div/div[1]/div/span[2]");
        private static readonly By ParseFirstText =
            By.XPath("//*[@id='js-product-list']/div[1]/article[1]/div/div[1]/h2/a");
        private static readonly By ParseSecondText =
            By.XPath("//*[@id='js-product-list']/div[1]/article[2]/div/div[1]/h2/a");
        static readonly Dictionary<string, By> SortTypeList = new Dictionary<string, By>()
        {
            {"SortLowToHigh", By.XPath("//*[@id='js-product-list-top']/div[2]/div/div[1]/div/a[4]")},
            {"SortHighToLow", By.XPath("//*[@id='js-product-list-top']/div[2]/div/div[1]/div/a[5]")},
            {"SortAToZ", By.XPath("//*[@id='js-product-list-top']/div[2]/div/div[1]/div/a[2]")},
            {"SortZToA", By.XPath("//*[@id='js-product-list-top']/div[2]/div/div[1]/div/a[3]")}
        };
        static readonly Dictionary<string, By> StoreDeptList = new Dictionary<string, By>()
        {
            {"Clothes", By.XPath("//*[@id='category-3']/a")},
            {"Accessories", By.XPath("//*[@id='category-6']/a")},
            {"Art", By.XPath("//*[@id='category-9']/a")},
            {"AllProducts", By.XPath("//*[@id='content']/section/a")}
            
        };
        private string _sortType2;
        public Store(IWebDriver driver) : base(driver)
        {
        }
        public Store OpenStore(string storeDept)
        {
            InputData(StoreDeptList[storeDept]);
            return this;
        }
        public Store ClickSort()
        {
            InputData(SortButton);
            return this;
        }
        public Store Sort(string sortType)
        {
            InputData(SortTypeList[sortType]);
            _sortType2 = sortType;
            Thread.Sleep(2000);
            return this;
        }
        public bool IsSortValid()
        {
            IWebElement firstPriceText = FindData(ParseFirstPrice);
            double firstPrice = Convert.ToDouble(firstPriceText.Text.Trim('$'), CultureInfo.InvariantCulture);
            FirstPrice = firstPrice;
            IWebElement secondPriceText = FindData(ParseSecondPrice);
                double secondPrice = Convert.ToDouble(secondPriceText.Text.Trim('$'), CultureInfo.InvariantCulture);
            SecondPrice = secondPrice;
            IWebElement firstText = FindData(ParseFirstText);
            IWebElement secondText = FindData(ParseSecondText);
            int compareItem = String.Compare(firstText.Text, secondText.Text);
            switch (_sortType2)
            {
                case "SortLowToHigh":
                    _check = FirstPrice <= SecondPrice;
                    break;
                case "SortHighToLow":
                    _check = FirstPrice >= SecondPrice;
                    break;
                case "SortAToZ":
                    if (compareItem <= 0)
                        _check = true;
                    break;
                case "SortZToA":
                    if (compareItem >= 0)
                        _check = true;
                    break;
                    
                default:
                    Console.WriteLine("Wrong sorting type");
                    break;
            }
            return _check;
        }
    }
}