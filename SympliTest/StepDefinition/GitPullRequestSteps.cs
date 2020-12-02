using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestUIAutomation.PageObjects;

namespace TestUIAutomation.Features
{
    [Binding]
    class GitPullRequestSteps
    {
        IWebDriver _driver = (IWebDriver)FeatureContext.Current["driver"];

        RepositoryHomePage _repositoryHomePage;
        LoginPage _loginPage;


        [Given(@"I navigate to GitHub url '(.*)'")]
        public void GivenINavigateToGitHubUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        [Given(@"I login by entering the user credentials")]
        public void GivenILoginByEnteringTheUserCredentials()
        {
            _loginPage = new LoginPage(_driver);
            _loginPage.EnterLoginDetails("simplitest", "gansuber8");
        }


        [When(@"I click Pull requests tab")]
        public void GivenIClickPullRequestsTab()
        {
            _repositoryHomePage = new RepositoryHomePage(_driver);
            _repositoryHomePage.ClickPullRequestsTab();
        }

        [When(@"I click New pull request button")]
        public void GivenIClickNewPullRequestButton()
        {
            _repositoryHomePage.ClickNewPullRequestBtn();
            System.Threading.Thread.Sleep(5000);
        }

        [When(@"I select '(.*)' branch as '(.*)'")]
        public void WhenISelectBranchAs(string branchType, string branch)
        {
            _repositoryHomePage.SelectBranchFromDropdown(branchType, branch);
            System.Threading.Thread.Sleep(5000);
        }

        [Then(@"I validate if Create pull request button is enabled")]
        public void ThenIValidateIfCreatePullRequestButtonIsEnabled()
        {
            var createPullRequestEnabled = _repositoryHomePage.CheckIfCreatePullRequestButtonEnabled();
            Assert.IsTrue(createPullRequestEnabled, "Create pull request button is not enabled!");
        }

        [Then(@"I validate if Create pull request button is disabled")]
        public void ThenIValidateIfCreatePullRequestButtonIsDisabled()
        {
            var createPullRequestEnabled = _repositoryHomePage.CheckIfCreatePullRequestButtonEnabled();
            Assert.IsFalse(createPullRequestEnabled, "Create pull request button is enabled!");
        }

        [Then(@"Display error message that both branches are same")]
        public void ThenDisplayErrorMessageThatBothBranchesAreSame()
        {
            var errorMessageDisplayed = _repositoryHomePage.CheckIfErrorMessageIsDisplayed();
            Assert.IsTrue(errorMessageDisplayed);
        }


        [Then(@"I validate if View pull request button is enabled")]
        public void ThenIValidateIfViewPullRequestButtonIsEnabled()
        {
            var viewPullRequestEnabled = _repositoryHomePage.CheckIfViewPullRequestButtonEnabled();
            Assert.IsTrue(viewPullRequestEnabled);
        }


    }
}
