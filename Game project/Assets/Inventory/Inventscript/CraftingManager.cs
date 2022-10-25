using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public inventories playerInventory;
    public GameObject bag;
    private items[] currentItem = new items[2];
    public string[] receipt;
    public items[] result;
    string itemName1, itemName2;
    private bool successCraft;
    
    public void craftItem()
    {
        currentItem[0] = transform.GetChild(1).gameObject.GetComponent<Craftslot>().item;
        currentItem[1] = transform.GetChild(2).gameObject.GetComponent<Craftslot>().item;
    
        if (currentItem[0] == null) {
            itemName1 = "null";
        } else {
            if (currentItem[0].itemHeld <= 0) { return; }
            itemName1 = currentItem[0].itemName;
        }

        if (currentItem[1] == null) {
            itemName2 = "null";
        } else {
            if (currentItem[1].itemHeld <= 0) { return; }
            itemName2 = currentItem[1].itemName;
        }

        int count = 0;
        successCraft = false;
        foreach (string curRe in receipt) {
            if (curRe == receipt[count] && !successCraft) {
                if (!playerInventory.itemList.Contains(result[count])) {
                    playerInventory.itemList.Add(result[count]);
                } else {
                    result[count].itemHeld++;
                }
                successCraft = true;
                if (currentItem[0] != null) { currentItem[0].itemHeld--; }
                if (currentItem[1] != null) { currentItem[1].itemHeld--; }
            }
            count++;
        }

        if (successCraft) {
            InventoryManager.RefreshItem();
            Debug.Log("Crafted success ");
            // implement success message here
        }
    }
}
