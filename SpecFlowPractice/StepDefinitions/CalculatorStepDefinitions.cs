using NUnit.Framework;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowPractice.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            Console.WriteLine($"first number is {number}");
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            Console.WriteLine($"first number is {number}");
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            Console.WriteLine($"Two number is added");
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            Console.WriteLine($" Result of two number is {result}");
        }

        [Given(@"I input the following table data")]
        public void GivenIInputTheFollowingTableData(Table table)
        {
            dynamic datas = table.CreateDynamicSet();
            foreach (var data in datas)
            {
                Console.WriteLine($"Numbers in table is {data.Numbers}");
            }
        }

        [Then(@"I see the result and other details")]
        public void ThenISeeTheResultAndOtherDetails(Table table)
        {
            dynamic dataResult = table.CreateDynamicInstance();
            Console.WriteLine($"Result is {dataResult.Results} with logo {dataResult.logo}");
        }
        [When(@"two number are added")]
        public void WhenTwoNumberAreAdded()
        {
           
        }

        [Then(@"test case gets ""([^""]*)""")]
        public void ThenTestCaseGets(string passed)
        {
            Console.WriteLine($"The test case is {passed}");
        }

        private int _integerNumber;
        private decimal _floatNumber;
        private decimal _result;


        [Given(@"Input the (.*) and (.*)")]
        public void GivenInputTheAnd(int p0, Decimal p1)
        {
            _integerNumber= p0;
            _floatNumber = p1;
        }

        [Given(@"Also provide the Plus")]
        public void GivenAlsoProvideThePlus()
        {
           
        }

        [Then(@"will get the result (.*)")]
        public void ThenWillGetTheResult(Decimal p0)
        {
           Calculator cal= new Calculator();
           _result= cal.Add(_integerNumber, _floatNumber);
            Assert.AreEqual(p0, _result);
        }

    }
    public class Calculator
    {
        public decimal Add(int intNumber, decimal floatNumber)
        {
            return intNumber + floatNumber;
        }
    }
}