Feature: CheckoutSystemTestFeature
	In order to test the checkout functionality of a restaurant till
	As a tester
	I want to verify the checkout system can Add, update, delete and calculate correct cost based on the quantity specified.

	Add Scenario    - Verifies that new list items are added and in case the same items are already present then validates quantities are updated accordingly.
	Update Scenario - Verifies quantities of the items within the list are correctly updated.
	Delete Scenario - Verifies that list items are removed as expected based on the quantity passed in by the test. Validates that item is removed if the quantity is same or greater than.
	Total Cost		- Validates that total cost is calculated correctly.

@totalCostPositive
Scenario: Verify total cost calculation from a list of menu items
	Given a list of menu items
	| itemName | itemType | itemQuantity |
	| item1    | Starter  | 2            |
	| item2    | Main     | 3            |
	When order is checked out
	Then the total cost should be 29.80


@addNewItemsToItemList
Scenario: Verify successful addition of items in checkout list
	Given a list of menu items
	| itemName | itemType | itemQuantity |
	| item1    | Starter  | 2            |
	| item2    | Main     | 3            |
	When following items are added to the checkout list
	| itemName | itemType | itemQuantity |
	| item1    | Starter  | 2            |
	| item3    | Main     | 1            |
	| item4    | Main     | 1            |
	Then checkout list should be updated to
	| itemName | itemType | itemQuantity |
	| item1    | Starter  | 4            |
	| item2    | Main     | 3            |
	| item3    | Main     | 1            |
	| item4    | Main     | 1            |


@deleteItemsFromList
Scenario: Verify items are correctly removed from the checkout list
	Given a list of menu items
	| itemName | itemType | itemQuantity |
	| item1    | Starter  | 2            |
	| item2    | Main     | 3            |
	| item3    | Main     | 1            |
	| item4    | Main     | 1            |
	When following items are deleted from the checkout list
	| itemName | itemType | itemQuantity |
	| item1    | Starter  | 1            |
	| item2    | Main     | 5            |
	| item3    | Main     | 1            |
	| item4    | Main     | 1            |
	| item5    | Main     | 1            |
	Then checkout list should be updated to
	| itemName | itemType | itemQuantity |
	| item1    | Starter  | 1            |


@updateItemQuantity
Scenario: Verify item quantities are being updated correctly
	Given a list of menu items
	| itemName | itemType | itemQuantity |
	| item1    | Starter  | 2            |
	| item2    | Main     | 3            |
	When quantities of the following items are updated
	| itemName | itemType | itemQuantity |
	| item1    | Starter  | 1            |
	| item2    | Main     | 1            |
	Then checkout list should be updated to
	| itemName | itemType | itemQuantity |
	| item1    | Starter  | 1            |
	| item2    | Main     | 1            |