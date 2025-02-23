Feature: User login functionality with Hooks

#Background halps to add context to a scenario. it shall execute prior to execution of each scenario , but post of any "before hooks".
Background: 
  Given Create the Chrome driver
  Then Enter the URL

@Usertag
Scenario: Login the user and setup the pre and post operation in hooks
	Given I enter the user credential