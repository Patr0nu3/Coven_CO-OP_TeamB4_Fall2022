using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    // private GameObject player;
    [SerializeField] private UI_Inventory uiInventory;
    
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
    }
}
