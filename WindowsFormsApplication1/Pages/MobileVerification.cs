using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Pages
{
    class MobileVerification
    {
        IWebDriver driver;
        public MobileVerification(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "a[href='UpdateDtls.jsp?displayType=FORM']")]
        public IWebElement backLink { get; set; }

        public void ClickBack()
        {
            backLink.Click();

        }
    }
}
