Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowPractice/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120


@tablesTag
	Scenario: Arithmatic operation using table data
	Given I input the following table data
	   | Numbers |
	   | 20      |
	   | 30      |
	When two number are added

	Then I see the result and other details
	  | Results |logo            |
	  | 50      |Plus_Operartion |

	Then test case gets "Passed and Green"

@ScenarioOutlinesTag
Scenario Outline: Operation using Scenario Outlines
    Given Input the <IntegerNumber> and <FloatNumber>
    And Also provide the <OperationType>
    Then will get the result <Results>

Examples: 
    | IntegerNumber | FloatNumber | OperationType | Results |
    | 20            | 34.5        | Plus          | 54.5    |
    | 50            | 45.7        | Plus          | 95.7    |
	





	

     

