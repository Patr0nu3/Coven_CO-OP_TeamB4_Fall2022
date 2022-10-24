using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;
    // Player's inventory
    private InventoryA inventory;
    
    private void Awake() {
        uiInventory.SetPlayer(this);
    }
    
    public void SetInventory(InventoryA inventory) {
        this.inventory = inventory;
    }
    
    private void OnTriggerEnter2D(Collider2D collider) {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        
        // if we are touching an item
        if (itemWorld != null) {
            // add item to inventory and remove from world
            Debug.Log("add item");
            bool itemAdded = inventory.AddItem(itemWorld.GetItem());
            // remove item from world only if added to inventory
            if (itemAdded) {
                itemWorld.DestroySelf();
            }
        }
    }
    
    // returns the current position of the player
    public Vector3 GetPosition() {
        // Debug.Log("x: " + this.transform.position.x);
        Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y);
        return pos;
    }
}
