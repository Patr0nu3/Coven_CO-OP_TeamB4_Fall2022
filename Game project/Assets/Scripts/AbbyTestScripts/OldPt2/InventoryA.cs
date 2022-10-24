using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryA
{
    public event EventHandler OnItemListChanged;
    private List<Item> itemList;
    private int capacity = 7;
    private int uniqueItemCount = 0;
    
    // InventoryA constructor
    // creates a list of items it contains (initialized empty)
    public InventoryA() {
        itemList = new List<Item>();
        
        // temp initialize add
        AddItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1});
        // AddItem(new Item { itemType = Item.ItemType.RedMushroom, amount = 1});
        AddItem(new Item { itemType = Item.ItemType.YellowFlower, amount = 1});
        AddItem(new Item { itemType = Item.ItemType.Starfish, amount = 1});
        Debug.Log(itemList.Count);
    }
    
    // adds an item to the inventory list 
    public bool AddItem(Item item) {
        item.amount = 1;    // idk why but okay        
        if (item.IsStackable()) {
            // Debug.Log("adding stackable");
            bool itemAlreadyInInventory = false;
            // check if it exists in inventory
            foreach (Item inventoryItem in itemList) {
                if (inventoryItem.itemType == item.itemType) {
                    inventoryItem.amount += item.amount;
                    // Debug.Log(item.itemType + " pickup amt: " + item.amount);
                    // Debug.Log(item.itemType + " amt: " + inventoryItem.amount);
                    itemAlreadyInInventory = true;
                }
            }
            // if it does not exist, add it
            if (!itemAlreadyInInventory) {
                // only add if there's room
                if (capacity == uniqueItemCount) {
                    return false;
                }
                itemList.Add(item);
                uniqueItemCount++;
            }
        } else {
            // only add if there's room
            if (capacity == uniqueItemCount) {
                return false;
            }
            itemList.Add(item);
            uniqueItemCount++;
        }
        
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
        return true;    // added to inventory
    }
    
    // removes item from inventory
    public void RemoveItem(Item item) {
        if (item.IsStackable()) {
            Item itemInInventory = null;
            // drop the item if it exists in a stack
            foreach (Item inventoryItem in itemList) {
                if (inventoryItem.itemType == item.itemType) {
                    inventoryItem.amount--;
                    // Debug.Log(item.itemType + " amt: " + inventoryItem.amount);
                    itemInInventory = inventoryItem;
                }
            }
            
            if (itemInInventory != null && itemInInventory.amount <= 0) {
                itemList.Remove(itemInInventory);
                uniqueItemCount--;
            }
        } else {
            itemList.Remove(item);
            uniqueItemCount--;
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    
    
    // returns the inventory list
    public List<Item> GetItemList() {
        return itemList;
    }
}
