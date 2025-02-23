using TechTalk.SpecFlow;

namespace SpecFlowPractice.Hooks
{
    [Binding]
    public sealed class HooksUser
    {
        //BeforeTestRun and AfterTestRun must be static
        [BeforeTestRun]
        public static void BeforeTestRun()=> Console.WriteLine("The Before Test Run is executed");

        [AfterTestRun]
        public static void AfterTestRun() => Console.WriteLine("The After Test Run is executed");

        //BeforeFeature and AfterFeature must be static
        [BeforeFeature]
        public static void BeforeFeature() => Console.WriteLine("Before Feature: Initializing feature-specific resources...");

        [AfterFeature]
        public static void AfterFeature() => Console.WriteLine("After Feature: Releasing feature-specific resources...");

        [BeforeScenario("@Usertag")]
        public void BeforeScenarioWithTag() => Console.WriteLine("The Before Scenario With Tag is executed");

        [AfterScenario]
        public void AfterScenario() => Console.WriteLine("The After Scenario With Tag is executed");

        [BeforeStep]
        public void BeforeStep() => Console.WriteLine("Before Step: Preparing to execute the step...");

        [AfterStep]
        public void AfterStep() => Console.WriteLine("After Step: Cleaning up after the step...");
    }
}

/*Hooks::
 * 
 * In SpecFlow, hooks are special methods that are executed before or after various stages of a scenario or feature.
 * These hooks allow you to run code at specific points in your test execution, such as before or after each test scenario, or before or after a test run.
 * Hooks in SpecFlow help manage setup and teardown for tests at different levels (test run, feature, scenario, step).
 * They provide a powerful way to organize your test code and ensure a clean environment before and after tests are executed.
 * Order and tags allow fine-grained control over when and where hooks are applied.
 * 
 */
/*
 * Execution Order:
 
   Before Test Run: Setting up test environment...
   Before Feature: Initializing feature-specific resources...
   Before Scenario: Setting up for the scenario...
   Before Step: Preparing to execute the step...
     User Successfully login...
   After Step: Cleaning up after the step...
   After Scenario: Tearing down after the scenario...
   After Feature: Releasing feature-specific resources...
   After Test Run: Cleaning up test environment...

 */