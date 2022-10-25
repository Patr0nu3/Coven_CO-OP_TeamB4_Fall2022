using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteract : MonoBehaviour
{
    public GameObject ShopBoard;
    
    // show shop if player is interacting
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            ShopBoard.SetActive(true);
        }
    }
    
    // hide shope when player leaves
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            ShopBoard.SetActive(false);
        }
    }
}
