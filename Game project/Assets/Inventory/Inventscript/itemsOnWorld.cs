using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemsOnWorld : MonoBehaviour
{
    public items thisItem;
    public inventories playerInventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            AddNewItem();
            Destroy(gameObject);
        }
    }

    private void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem)) {
            playerInventory.itemList.Add(thisItem);
        } else {
            thisItem.itemHeld++;
        }

        InventoryManager.RefreshItem();
    }
}
