using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryA
{
    public event EventHandler OnItemListChanged;
    private List<Item> itemList;
    
    // InventoryA constructor
    // creates a list of items it contains (initialized empty)
    public InventoryA() {
        itemList = new List<Item>();
        
        // temp initialize add
        AddItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1});
        AddItem(new Item { itemType = Item.ItemType.RedMushroom, amount = 1});
        AddItem(new Item { itemType = Item.ItemType.YellowFlower, amount = 1});
        AddItem(new Item { itemType = Item.ItemType.Starfish, amount = 1});
        Debug.Log(itemList.Count);
    }
    
    // adds an item to the inventory list 
    public void AddItem(Item item) {
        if (item.IsStackable()) {
            bool itemAlreadyInInventory = false;
            // check if it exists in inventory
            foreach (Item inventoryItem in itemList) {
                if (inventoryItem.itemType == item.itemType) {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            // if it does not exist, add it
            if (!itemAlreadyInInventory) {
                itemList.Add(item);
            }
        } else {
            itemList.Add(item);
        }
        
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    
    // returns the inventory list
    public List<Item> GetItemList() {
        return itemList;
    }
}
