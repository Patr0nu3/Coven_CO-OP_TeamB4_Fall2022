using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public Item item;
    
    // when created, it spawns an item in the world at the position
    // and destroys the spawner
    private void Start() {         
        item.amount = 1;
        ItemWorld.SpawnItemWorld(transform.position, item);
        Destroy(gameObject);
    }
}
