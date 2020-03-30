using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TillCheckoutSystem.CheckoutSystem;
using TillCheckoutSystem.Model;

namespace TillCheckoutSystem.Tests.TestStepDefinitions
{
    [Binding]
    public sealed class CheckoutSystemSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Checkout _checkOut;

        public CheckoutSystemSteps(ScenarioContext scenarioContext, Checkout checkOut)
        {
            _scenarioContext = scenarioContext;
            _checkOut = checkOut;
        }

        [Given(@"a list of menu items")]
        public void GivenAListOfMenuItems(Table table)
        {
            _scenarioContext.Add("listOfItems", table.CreateSet<ItemList>().ToList());
        }

        [When(@"order is checked out")]
        public void WhenOrderIsCheckedOut()
        {
            var actualTotalCost = _checkOut.CalcTotalCost(_scenarioContext.Get<List<ItemList>>("listOfItems"));
            _scenarioContext.Add("actualTotalCost", actualTotalCost);
        }

        [When(@"following items are added to the checkout list")]
        public void WhenFollowingItemsAreAddedToTheCheckoutList(Table table)
        {
            var listOfItems = _scenarioContext.Get<List<ItemList>>("listOfItems");
            var updatedListOfItems = _checkOut.AddItemToList(listOfItems, table.CreateSet<ItemList>().ToList());
            _scenarioContext.Add("updatedListOfItems", updatedListOfItems);
        }

        [When(@"following items are deleted from the checkout list")]
        public void WhenFollowingItemsAreDeletedFromTheCheckoutList(Table table)
        {
            var listOfItems = _scenarioContext.Get<List<ItemList>>("listOfItems");
            var updatedListOfItems = _checkOut.DeleteItemFromList(listOfItems, table.CreateSet<ItemList>().ToList());
            _scenarioContext.Add("updatedListOfItems", updatedListOfItems);
        }

        [When(@"quantities of the following items are updated")]
        public void WhenQuantitiesOfTheFollowingItemsAreUpdated(Table table)
        {
            var listOfItems = _scenarioContext.Get<List<ItemList>>("listOfItems");
            var updatedListOfItems = _checkOut.UpdateQuantiyOfItemWithinList(listOfItems, table.CreateSet<ItemList>().ToList());
            _scenarioContext.Add("updatedListOfItems", updatedListOfItems);
        }

        [Then(@"checkout list should be updated to")]
        public void ThenCheckoutListShouldBeUpdatedTo(Table table)
        {
            var actualListOfItems = _scenarioContext.Get<IEnumerable<ItemList>>("updatedListOfItems");
            table.CompareToSet<ItemList>(actualListOfItems);
        }

        [Then(@"the total cost should be (.*)")]
        public void ThenTheTotalCostShouldBe(decimal expectedTotalCost)
        {
            var actualTotalCost = _scenarioContext.Get<decimal>("actualTotalCost");
            Assert.AreEqual(expectedTotalCost, actualTotalCost, $"Expected Total Cost = {expectedTotalCost} doesn't match with Actual Total Cost {actualTotalCost}");
        }
    }
}
