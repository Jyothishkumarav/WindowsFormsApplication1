using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Pages
{
    public class MainPage
    {
        IWebDriver driver;
        
        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("leftFrame")));
            driver.SwitchTo().Frame("leftFrame");
            PageFactory.InitElements(this.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "a[title='e-Returns']")]
        public IWebElement eReturns { get; set; }

        public void ClickEReturn()

        {
            //driver.SwitchTo().Frame("leftFrame");
            eReturns.Click();

        }
    }
}
