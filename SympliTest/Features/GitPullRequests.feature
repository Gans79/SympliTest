Feature: GitPullRequests

@UI
Scenario: Create a pull request when both branches are different
	Given I navigate to GitHub url 'https://github.com/login'
	And I login by entering the user credentials
	And I navigate to GitHub url 'https://github.com/simplitest/QA-CC-V1-OperaHouse'
	When I click Pull requests tab
	And I click New pull request button
	And I select 'compare' branch as 'develop'
	And I select 'base' branch as 'master'
	Then I validate if Create pull request button is enabled

Scenario: Error Message when both branches are same 
	Given I navigate to GitHub url 'https://github.com/login'
	And I login by entering the user credentials
	And I navigate to GitHub url 'https://github.com/simplitest/QA-CC-V1-OperaHouse'
	When I click Pull requests tab
	And I click New pull request button
	And I select 'compare' branch as 'master'
	And I select 'base' branch as 'master'
	Then Display error message that both branches are same

Scenario: When there is already a existing open pull request View the pull request
	Given I navigate to GitHub url 'https://github.com/login'
	And I login by entering the user credentials
	And I navigate to GitHub url 'https://github.com/sympli-coding-challenge/QA-CC-V1-Campbelltown'
	When I click Pull requests tab
	And I click New pull request button
	And I select 'compare' branch as 'develop'
	And I select 'base' branch as 'master'
	Then I validate if View pull request button is enabled
	
