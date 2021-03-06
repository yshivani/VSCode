﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using EAEmployeeTest.Pages;
using EAAutoFramework.Base;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using EAAutoFramework.Helpers;
using EAAutoFramework.Config;

namespace EAEmployeeTest
{
    [TestClass]
    public class UnitTest1 : HookInitialize
    {

        [TestMethod]
        public void TestMethod1()
        {

            //ConfigReader.SetFrameworkSettings();
            //DriverContext.Driver.Navigate().GoToUrl(url);
            //LogHelpers.CreateLogFile();

            string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsx";

            ExcelHelpers.PopulateInCollection(fileName);
            
            //OpenBrowser(BrowserType.Firefox);
            //LogHelpers.Write("Opened the Browser !!!!");

            //DriverContext.Browser.GotoUrl(Settings.AUT);
            //LogHelpers.Write("Navigated to the Page !!!");

            //Login Page
            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<LoginPage>().ClickLoginLink();
            CurrentPage.As<LoginPage>().CheckIfLoginExists();
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

        [TestMethod]
        public void TableOperation()
        {
            LogHelpers.CreateLogFile();

            string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsx";

            ExcelHelpers.PopulateInCollection(fileName);

            //OpenBrowser(BrowserType.Firefox);
            LogHelpers.Write("Opened the Browser !!!!");

            DriverContext.Browser.GotoUrl(Settings.AUT);
            LogHelpers.Write("Navigated to the Page !!!");

            //Login Page
            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<LoginPage>().ClickLoginLink();
            CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1, "Username"), ExcelHelpers.ReadData(1, "Password"));
            //Employee Page
            CurrentPage = CurrentPage.As<LoginPage>().ClickEmployeeList();

            var table = CurrentPage.As<EmployeePage>().GetEmployeeList();

            HtmlTableHelper.ReadTable(table);
            HtmlTableHelper.PerformActionOnCell("5", "Name", "Ramesh", "Benefits");
            
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
