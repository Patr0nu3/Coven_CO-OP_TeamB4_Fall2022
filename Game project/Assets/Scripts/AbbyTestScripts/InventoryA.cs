using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryA
{
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
        itemList.Add(item);
    }
    
    // returns the inventory list
    public List<Item> GetItemList() {
        return itemList;
    }
}
