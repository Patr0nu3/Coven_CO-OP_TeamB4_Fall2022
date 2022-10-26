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

        string formula = "";
        if (currentItem[0] == null) {
            formula += "null";
        } else {
            if (currentItem[0].itemHeld <= 0) { return; }
            formula += currentItem[0].itemName;
        }

        if (currentItem[1] == null) {
            formula += "null";
        } else {
            if (currentItem[1].itemHeld <= 0) { return; }
            formula += currentItem[1].itemName;
        }

        int count = 0;
        successCraft = false;
        foreach (string curRe in receipt) {
            Debug.Log("receipt: " + receipt[count]);
            if (curRe == formula) {
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
            Debug.Log("Crafted success ");
            // implement success message here
        }
        InventoryManager.RefreshItem();
        transform.GetChild(1).gameObject.transform.DetachChildren();
        transform.GetChild(2).gameObject.transform.DetachChildren();
    }
}
