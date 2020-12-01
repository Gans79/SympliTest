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
    class RepositoryHomePage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//span[text()='Pull requests']")]
        private IWebElement _btnPullRequestsTab;

        [FindsBy(How = How.XPath, Using = "//span[text()='New pull request']")]
        private IWebElement _btnNewPullRequest;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'shown')]//button[contains(text(),'Create pull request')]")]
        private IWebElement _btnCreatePullRequest;

        public RepositoryHomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(30), TimeSpan.FromMilliseconds(500)));
        }

        public void ClickPullRequestsTab() => Utility.WaitAndClick(_btnPullRequestsTab);

        public void ClickNewPullRequestBtn() => Utility.WaitAndClick(_btnNewPullRequest);


        public void SelectBranchFromDropdown(string branchType, String branch)
        {
            var _ddBranch = _driver.FindElement(By.XPath($"//i[text()='{branchType}:']/parent::summary"));
            Utility.WaitAndClick(_ddBranch);

            System.Threading.Thread.Sleep(5000);
            var _ddBranchText = _driver.FindElement(By.XPath($"//a//span[text()='{branch}']"));
            Utility.WaitAndClick(_ddBranchText);
        }

        public bool CheckIfCreatePullRequestButtonEnabled()
        {
            Utility.Wait(_btnCreatePullRequest);
            return _btnCreatePullRequest.Displayed;
        }

    }
}
