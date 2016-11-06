using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Core
{
    public static class DriverFactory
    {

        public static  IWebDriver getDriver()
        {
            IWebDriver driver=null;

            string driverType = ConfigurationManager.AppSettings["driver"];

            if (driverType.Equals("chrome"))
            {
                driver = GetChromeDriver();
            }

            return driver;

        }

        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver=new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            return driver;
        }

    }
}
