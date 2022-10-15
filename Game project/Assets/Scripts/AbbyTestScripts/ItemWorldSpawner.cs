using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public Item item;
    
    // when created, it spawns an item in the world at the position
    // and destroys the spawner
    private void Start() { 
        if (item == null) {
            Debug.Log("item null");
        } else {
            Debug.Log("item not null");
        }
        
        ItemWorld.SpawnItemWorld(transform.position, item);
        Destroy(gameObject);
    }
}
