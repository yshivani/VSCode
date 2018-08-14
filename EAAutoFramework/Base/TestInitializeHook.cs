using EAAutoFramework.Config;
using EAAutoFramework.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework.Base
{
    public abstract class TestInitializeHook : Base
    {
        public readonly BrowserType Browser;

        public TestInitializeHook(BrowserType browser)
        {
            Browser = browser;
        }

        public void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

            //Set log
            LogHelpers.CreateLogFile();

            //Open Browser
            OpenBrowser(Browser);
            LogHelpers.Write("Initialize Method is Done !!!!");

        }

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

        public virtual void NavigateSite()
        {
            DriverContext.Browser.GotoUrl(Settings.AUT);
        }
    }
}
