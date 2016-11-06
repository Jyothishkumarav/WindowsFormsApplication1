using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Pages
{

    public class EReturn
    {
        IWebDriver driver;
        public EReturn(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "a[title='Print Return']")]
        public IWebElement printReturn { get; set; }

        public void ClickBackToPrint()
        {
            printReturn.Click();

        }
    }
}
