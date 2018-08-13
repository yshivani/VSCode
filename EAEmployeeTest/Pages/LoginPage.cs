using EAAutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using EAAutoFramework.Extensions;
using System;

namespace EAEmployeeTest.Pages
{
    class LoginPage : BasePage
    {
        //Objects
        [FindsBy(How = How.LinkText, Using ="Log in")]
        IWebElement lnkLogin { get; set; }

        [FindsBy(How = How.Id, Using = "UserName")]
        IWebElement txtUsername { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        IWebElement txtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn")]
        IWebElement btnLogin { get; set; }

        [FindsBy(How = How.LinkText, Using = "Employee List")]
        IWebElement lnkEmploeeList { get; set; }


        public void Login(string username, string password)
        {
            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);
            btnLogin.Submit();
        }

        public void ClickLoginLink()
        {
            lnkLogin.Click();

        }


        public EmployeePage ClickEmployeeList()
        {
            lnkEmploeeList.Click();
            return GetInstance<EmployeePage>();
        }

        internal void CheckIfLoginExists()
        {
            txtUsername.AssertElementPresent();
        }
    }
}
