using AutoFixture;

namespace SpecFlowPractice.StepDefinitions
{
    [Binding]
    internal sealed class UserStepDefinations
    {
        [Given(@"Create the Chrome driver")]
        public void GivenCreateTheChromeDriver()
        {
            Console.WriteLine("Chrome driver is created");
        }

        [Then(@"Enter the URL")]
        public void ThenEnterTheURL()
        {
            Console.WriteLine("Navigating to the URL...");
        }

        [Given(@"I enter the user credential")]
        public void GivenIEnterTheUserCredential()
        {
            Console.WriteLine("User Successfully login...");

            var person = new Fixture().Create<User>();
            Console.WriteLine($"Id is   : {person.Id}");
            Console.WriteLine($"Name is : {person.Name}");
            Console.WriteLine($"Phone is: {person.Phone}");

        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
    }
}
