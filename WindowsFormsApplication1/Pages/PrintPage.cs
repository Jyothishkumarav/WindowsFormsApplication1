using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Pages
{
    class PrintPage
    {
        IWebDriver driver;
        public PrintPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "select[name='WediassmtYear']")]
        public IWebElement AssessYear { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value='Submit']")]
        public IWebElement submitBtn { get; set; }

        public void SelectYearAndVaigate(string year)
        {
            SelectElement selector = new SelectElement(AssessYear);
            selector.SelectByText(year);
            submitBtn.Click();

        }
    }
}
