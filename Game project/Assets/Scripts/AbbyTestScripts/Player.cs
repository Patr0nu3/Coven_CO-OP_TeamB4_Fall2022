using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player's inventory
    private InventoryA inventory;
    
    public void SetInventory(InventoryA inventory) {
        this.inventory = inventory;
    }
    
    private void OnTriggerEnter2D(Collider2D collider) {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        
        // if we are touching an item
        if (itemWorld != null) {
            // add item to inventory and remove from world
            Debug.Log("add item");
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
}
