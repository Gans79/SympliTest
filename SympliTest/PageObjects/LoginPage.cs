using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUIAutomation.Extensions;

namespace TestUIAutomation.PageObjects
{
    class LoginPage
    {
        private IWebDriver _driver;


        [FindsBy(How = How.Id, Using = "login_field")]
        private IWebElement _txtUserName;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement _txtPassword;

        [FindsBy(How = How.Name, Using = "commit")]
        private IWebElement _btnSignIn;

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Repositories')][1]")]
        private IWebElement _txtRepositories;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(30), TimeSpan.FromMilliseconds(500)));
        }

        public void EnterLoginDetails(string username, string password)
        {
            Utility.WaitAndClick(_txtUserName);
            _txtUserName.SendKeys(username);

            Utility.WaitAndClick(_txtPassword);
            _txtPassword.SendKeys(password);

            Utility.WaitAndClick(_btnSignIn);

            Utility.Wait(_txtRepositories);
        }
    }
}
