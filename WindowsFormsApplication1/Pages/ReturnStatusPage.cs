using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Utitity;

namespace WindowsFormsApplication1.Pages
{
    public class ReturnStatusPage
    {
        IWebDriver driver;
        public ReturnStatusPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".clsTableControl tbody tr")]
        public IList<IWebElement> eReturnsList { get; set; }

        //iCOMITRAX/LogOut.jsp
        [FindsBy(How = How.CssSelector, Using = "a[href='iCOMITRAX/LogOut.jsp']")]
        public IWebElement signOut { get; set; }

        public string getInitiatedData()
        {
            string initiatedList = "";
            IList<IWebElement> columns;
            eReturnsList.RemoveAt(0);
            foreach (IWebElement row in eReturnsList)
            {
                try
                {
                    columns = row.FindElements(By.TagName("td"));
                    var status = columns[8].Text;
                    if (status.ToLower().Contains("initiated"))
                    {
                        initiatedList = initiatedList + columns[0].Text + ";";
                    }
                    Debug.WriteLine(status);

                }
                catch (Exception ex)
                {
                    continue;
                }               
            }
            Debug.WriteLine(initiatedList);
            DoSignOutAndLogin();
            return initiatedList;
        }

        public void DoSignOutAndLogin()
        {
            signOut.Click();
            driver.Url = ReadSettings.GetuRL();


        }
    }
}
