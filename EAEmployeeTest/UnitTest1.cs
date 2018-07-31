using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using EAEmployeeTest.Pages;
using EAAutoFramework.Base;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using EAAutoFramework.Helpers;

namespace EAEmployeeTest
{
    [TestClass]
    public class UnitTest1:Base
    {
       
        string url = "http://localhost/";

        public void OpenBrowser(BrowserType browserType = BrowserType.Firefox)
        {
            switch (browserType)
            {
                case BrowserType.InterExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Firefox:
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Shivani\VS\EAAutoFramework\EAEmployeeTest");
                    service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    DriverContext.Driver = new FirefoxDriver(service);
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                default:
                    break;
            }
        }

        [TestMethod]
        public void TestMethod1()
        {

            //DriverContext.Driver.Navigate().GoToUrl(url);
            LogHelpers.CreateLogFile();

            string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsx";

            ExcelHelpers.PopulateInCollection(fileName);
            
            OpenBrowser(BrowserType.Firefox);
            LogHelpers.Write("Opened the Browser !!!!");

            DriverContext.Browser.GotoUrl(url);
            LogHelpers.Write("Navigated to the Page !!!");

            //Login Page
            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<LoginPage>().ClickLoginLink();
            CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1,"Username"), ExcelHelpers.ReadData(1,"Password"));
            //Employee Page
            CurrentPage = CurrentPage.As<LoginPage>().ClickEmployeeList();
            CurrentPage.As<EmployeePage>().clickCreateNew();
                        
            //LoginPage page = new LoginPage();

            //page.ClickLoginLink();
            //page.Login("admin", "password");

            //CurrentPage = page.ClickEmployeeList();
            //((EmployeePage)CurrentPage).clickCreateNew();
        }

        //public void Login()
        //{

            //_driver.FindElement(By.LinkText("Log in")).Click();

            ////user name
            //_driver.FindElement(By.Id("UserName")).SendKeys("admin");
            //_driver.FindElement(By.Id("Password")).SendKeys("password");

            ////click login
            //_driver.FindElement(By.CssSelector("input.btn")).Submit();
       // }
    }
}
