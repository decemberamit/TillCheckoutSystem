using System.Collections.Generic;
using System.Linq;
using TillCheckoutSystem.Model;

namespace TillCheckoutSystem.CheckoutSystem
{
    public class Checkout
    {
        private readonly Item _item;
        public Checkout(Item item)
        {
            _item = item;
        }

        public List<ItemList> DeleteItemFromList(List<ItemList> listOfItems, List<ItemList> listOfItemsToBeDeleted)
        {
            foreach (var item in listOfItemsToBeDeleted)
            {
                var itemToRemove = listOfItems.SingleOrDefault(i => i.itemName == item.itemName && i.itemType == item.itemType);
                if (itemToRemove != null && item.itemQuantity >= itemToRemove.itemQuantity)
                {
                    listOfItems.Remove(itemToRemove);
                }
                else if (itemToRemove != null && item.itemQuantity < itemToRemove.itemQuantity)
                {
                    listOfItems.Where(i => i.itemName == item.itemName && i.itemType == item.itemType).Single().itemQuantity -= item.itemQuantity;
                }
            }
            return listOfItems;
        }

        public List<ItemList> AddItemToList(List<ItemList> listOfItems, List<ItemList> listOfItemsToBeAdded)
        {
            foreach (var item in listOfItemsToBeAdded)
            {
                var itemToAdd = listOfItems.SingleOrDefault(i => i.itemName == item.itemName && i.itemType == item.itemType);
                if (itemToAdd != null)
                {
                    listOfItems.Where(i => i.itemName == item.itemName && i.itemType == item.itemType).Single().itemQuantity += item.itemQuantity;
                }
                else
                {
                    listOfItems.Add(item);
                }
            }
            return listOfItems;
        }

        public List<ItemList> UpdateQuantiyOfItemWithinList(List<ItemList> listOfItems, List<ItemList> listOfItemsToUpdated)
        {
            foreach (var item in listOfItemsToUpdated)
            {
                var itemToUpdate = listOfItems.SingleOrDefault(i => i.itemName == item.itemName && i.itemType == item.itemType);
                if (itemToUpdate != null)
                {
                    listOfItems.Where(i => i.itemName == item.itemName && i.itemType == item.itemType).Single().itemQuantity = item.itemQuantity;
                }
            }
            return listOfItems;
        }

        public decimal CalcTotalCost(List<ItemList> listOfItems)
        {
            decimal totalCost = 0;
            foreach (var listItem in listOfItems)
            {
                totalCost += _item.GetItemPrice(listItem.itemType) * listItem.itemQuantity;
            }
            return totalCost;
        }
    }
}
