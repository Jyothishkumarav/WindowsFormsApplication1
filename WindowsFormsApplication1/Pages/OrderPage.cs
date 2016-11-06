using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Pages
{
    public class OrderPage
    {
        IWebDriver driver;
        public OrderPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "a[href='demand.jsp']")]
        public IWebElement backLink { get; set; }

        public void ClickBack()
        {
            backLink.Click();

        }

    }
}
