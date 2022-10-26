using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSubmitBtns: MonoBehaviour
{
    public inventories playerInventory;
    // [SerializeField] InventoryManager inventoryManager;
    public Game_Handler gameHandler;
    public GameObject ShopUI;
    
    [SerializeField] Text shopText;
    [SerializeField] Text playerCoins;
    
    public void MushroomSubmit() {
        Debug.Log("mushroom submit");
        
        SellItem("Mushroom");
    }
    
    public void FlowerSubmit() {
        Debug.Log("flower submit");
        
        SellItem("Flower");
    }
    
    public void BerriesSubmit() {
        Debug.Log("berries submit");
        
        SellItem("Berries");
    }
    
    public void StarfishSubmit() {
        Debug.Log("starfish submit");
        
        SellItem("Starfish");
    }
    
    public void JellyfishSubmit() {
        Debug.Log("jellyfish submit");
        
        SellItem("Jellyfish");
    }
    
    public void HealthPotionSubmit() {
        Debug.Log("healthpotion submit");
        
        SellItem("Health Potion");
    }
    
    public void GreenPotionSubmit() {
        Debug.Log("greenpotion submit");
        
        SellItem("Damage Potion");
    }
    
    public void BluePotionSubmit() {
        Debug.Log("bluepotion submit");
        
        SellItem("Strength Potion");
    }
    
    public void HideShop() {
        Debug.Log("hide shop");
        // add button to hide shop
        ShopUI.SetActive(false);
    }
    
    private void SellItem(string itemName) {
        Debug.Log("checking for " + itemName);
        
        bool itemSold = false;
        
        // temp sets amount of each item to 1
        for (int i = 0; i < playerInventory.itemList.Count; i++) {
            Debug.Log(playerInventory.itemList[i].itemName);
            // playerInventory.itemList[i].itemHeld = 1;
        }
        
        // search for the item in the list
        for (int i = 0; i < playerInventory.itemList.Count; i++) {
            if ((playerInventory.itemList[i].itemName == itemName) &&
                 playerInventory.itemList[i].itemHeld > 0) {
                Debug.Log("in loop " + i);
                // remove it from the inventory
                playerInventory.itemList[i].itemHeld--;
                
                // state that you sold it
                shopText.text = "You sold 1 " + itemName + " and got " + playerInventory.itemList[i].itemPrice + " Coins!";
                
                // add price of item to coins
                gameHandler.updateCoins(playerInventory.itemList[i].itemPrice);
                
                // update coins UI
                // int currCoins = int.Parse(playerCoins.text) + playerInventory.itemList[i].itemPrice;
                
                playerCoins.text = gameHandler.getCoins().ToString() + "/ 1000";
                
                // set itemSold to true
                itemSold = true;
                
                // refresh inventory UI
                InventoryManager.RefreshItem();
                
                break;
            }
        }
        
        if (!itemSold) {
            shopText.text = "Sorry! You don't have that item.";
        }
        
    }
}
