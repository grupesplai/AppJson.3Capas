Feature: StudentRepositoryInsert
	Insert Student in Student Repository

@adding
Scenario: Adding an Student
	Given I have an Student without Id
	When I run the method Insert of Student Repository
	Then the result Repository should return an Stuent with Id
