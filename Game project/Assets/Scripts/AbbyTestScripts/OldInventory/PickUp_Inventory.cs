using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp_Inventory: MonoBehaviour {

      public GameInventory playerInventory;
      public string ItemName = "item1";

      void Awake(){
            if (GameObject.FindWithTag("GameHandler") != null) {
                  playerInventory = GameObject.FindWithTag("GameHandler").GetComponent<GameInventory>();
            }
      }

      void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.tag == "Player"){
                  Debug.Log("You found an" + ItemName);
                  playerInventory.InventoryAdd(ItemName);
                  //playerInventory.removeObjectFromLevel(ItemName);
                  //Destroy(gameObject);
            }
      }
}