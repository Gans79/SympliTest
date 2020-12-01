Feature: GitPullRequests

@UI
Scenario: Create a pull request
	Given I navigate to GitHub url 'https://github.com/login'
	And I login by entering the user credentials
	And I navigate to GitHub url 'https://github.com/simplitest/QA-CC-V1-OperaHouse'
	When I click Pull requests tab
	And I click New pull request button
	And I select 'compare' branch as 'develop'
	And I select 'base' branch as 'master'
	Then I validate if Create pull request button is enabled
	
