using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Pages
{
    public class DemandPage
    {
        IWebDriver driver;
        public DemandPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "a[href='iCOMITRAX/Main.jsp?flagBack=YES']")]
        public IWebElement backToHome { get; set; }

        public void ClickBackToHome()
        {
            backToHome.Click();

        }
    }
}
