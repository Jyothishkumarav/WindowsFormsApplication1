using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace WindowsFormsApplication1.Pages
{
    public class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver,this);
        }

        [FindsBy(How = How.CssSelector, Using = "input[name='txtUser']")]
        public IWebElement UserID { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name='txtPassword']")]
        public IWebElement PassWord { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name='Image1']")]
        public IWebElement LoginBtn { get; set; }

        public string SetLoginData(string userName,string password)
        {
            UserID.Clear();
            PassWord.Clear();
            UserID.SendKeys(userName);
            PassWord.SendKeys(password);
            return ClickOnLogin();
        }
        private string  ClickOnLogin()
        {
            LoginBtn.Click();
            return ManageAlert();
        }

        private string ManageAlert()
        {
            IAlert alert = driver.SwitchTo().Alert();
            var text = alert.Text;
            alert.Accept();
            return text;
        }
    }
}
