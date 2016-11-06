using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Pages
{
    class VerifyEmailMobile
    {
        IWebDriver driver;
        public VerifyEmailMobile(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "a[href='iCOMITRAX/Main.jsp?flagBack=YES']")]
        public IWebElement backLink { get; set; }

        public void ClickBack()
        {
            backLink.Click();

        }
    }
}

