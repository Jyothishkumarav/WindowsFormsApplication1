using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Model;
using WindowsFormsApplication1.Pages;
using WindowsFormsApplication1.Utitity;

namespace WindowsFormsApplication1.Core
{
    public class EFiller
      {
        private IWebDriver driver;
        private string inputDataFile { get; set; }
        private string outputDataFile { get; set; }
        private string year { get; set; }
        IList<EfillingDetails> fillingStatus { get; set; }
        public EFiller(string ipFile,string opFile,string year)
        {
            this.year = year;
            this.inputDataFile = ipFile;
            this.outputDataFile = opFile;
            fillingStatus = new List<EfillingDetails>();
            driver = DriverFactory.getDriver();
            driver.Url = ReadSettings.GetuRL();
        }
        public void DoLogin()
        {
           IList<UserLogin> users= IExcelReader.ReadExcelData(inputDataFile);
           LoginPage UserLoginPage = new LoginPage(driver);
            string listofmsg="";
            foreach (UserLogin user in users)
            {
                try {
                    var loginInfoText = UserLoginPage.SetLoginData(user.userName, user.passWord);
                    if (loginInfoText.Contains("User Does not Exists"))
                    {
                        fillingStatus.Add(new EfillingDetails(user, "INVALID LOGIN", ""));
                        continue;
                    }
                    else if (loginInfoText.ToLower().Contains("register your mobile"))
                    {
                        listofmsg = DoNavigationForMobileVerificationCust();
                    }
                    else
                    {

                        listofmsg = DoAllNavigationtoPrint();
                    }
                    if (listofmsg.Length > 0)
                    {
                        fillingStatus.Add(new EfillingDetails(user, "LOGIN SUCCESS", "Initiated", listofmsg));
                    }
                    else
                    {
                        fillingStatus.Add(new EfillingDetails(user, "LOGIN SUCCESS", "No Initiated", ""));
                    }

                }catch(Exception e){

                    driver.Url= ReadSettings.GetuRL();
                    fillingStatus.Add(new EfillingDetails(user, "Error occured", "Error", "Error in processing"+e.Message));
                }
            }    
            
            WriteToFile();
            KillChrome();

        }

        private void WriteToFile()
        {
           
            IExcelReader.WriteToExcel(outputDataFile, fillingStatus);
        }
        private string DoAllNavigationtoPrint()
        {
            OrderPage orderPage = new OrderPage(driver);
            orderPage.ClickBack();
            DemandPage demandPage = new DemandPage(driver);
            demandPage.ClickBackToHome();
            MainPage mainPage = new MainPage(driver);
            mainPage.ClickEReturn();
            EReturn eReturPage = new EReturn(driver);
            eReturPage.ClickBackToPrint();
            PrintPage printPage = new PrintPage(driver);
            printPage.SelectYearAndVaigate(year);
            ReturnStatusPage statusListPage = new ReturnStatusPage(driver);
            string message=statusListPage.getInitiatedData();
            return message;
        }
        private string DoNavigationForMobileVerificationCust()
        {

            MobileVerification mverify = new MobileVerification(driver);
            mverify.ClickBack();
            VerifyEmailMobile emailMobile = new VerifyEmailMobile(driver);
            emailMobile.ClickBack();
            MainPage mainPage = new MainPage(driver);
            mainPage.ClickEReturn();
            EReturn eReturPage = new EReturn(driver);
            eReturPage.ClickBackToPrint();
            PrintPage printPage = new PrintPage(driver);
            printPage.SelectYearAndVaigate(year);
            ReturnStatusPage statusListPage = new ReturnStatusPage(driver);
            string message = statusListPage.getInitiatedData();
            return message;

        }

      private void KillChrome()
        {
            foreach (var process in Process.GetProcessesByName("chrome"))
            {
                try {

                    process.Kill();

                } catch (Exception e)
                {
                    break;
                }
            }
        }
    }
}
