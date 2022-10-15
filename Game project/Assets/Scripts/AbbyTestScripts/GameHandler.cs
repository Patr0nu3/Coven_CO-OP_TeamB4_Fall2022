using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    // private GameObject player;
    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] private Player player;
    
    public static GameHandler gameHandler;
    private InventoryA inventory;

    private void Awake()
    {
        // maintains GameHandler across scenes
        if (gameHandler != null) {
            Destroy(gameObject);
            return;
        }
        gameHandler = this;
        DontDestroyOnLoad(gameObject);
        
        // create Inventory
        inventory = new InventoryA();
        uiInventory.SetInventory(inventory); 
        player.SetInventory(inventory);
        
        ItemWorld.SpawnItemWorld(new Vector3(5, 5), new Item { itemType = Item.ItemType.RedMushroom, amount = 1});
    }
}
