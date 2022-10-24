using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Inventory : MonoBehaviour
{
    private InventoryA inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private Player player;
    
    // grab all ui references 
    private void Awake() {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }
    
    public void SetPlayer(Player player) {
        this.player = player;
    }
    
    // sets inventory to ui inventory
    public void SetInventory(InventoryA inventory) {
        this.inventory = inventory;
        // if item list has changed, refresh items UI
        inventory.OnItemListChanged += Inventory_OnItemListChanged; 
        RefreshInventoryItems();
    }
    
    // if inventory item list changed event triggered, refresh inventory UI
    private void Inventory_OnItemListChanged(object sender, System.EventArgs e) {
        RefreshInventoryItems();
    }
    
    // sets inventory UI
    private void RefreshInventoryItems() {
        // destroy the transforms of previous inventory except the template
        foreach (Transform child in itemSlotContainer) {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        
        float x = -145f;
        float y = 0f;
        float itemSlotCellSize = 50f;
        
        // loops through inventory list
        foreach (Item item in inventory.GetItemList()) {
            // gets the Rect Transform of the itemSlotTemplate
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
             
            // set click functions on item
            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
                // use item 
            };
            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () => {
                // drop item
                inventory.RemoveItem(item);
                // Debug.Log("item dropped count: " + item.amount);
                ItemWorld.DropItem(player.GetPosition(), item);
            };
            
            // set position
            itemSlotRectTransform.anchoredPosition = new Vector2(x, y);
            
            // set image
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            
            // set item count
            Text amountText = itemSlotRectTransform.Find("amountText").GetComponent<UnityEngine.UI.Text>();
            if (item.amount > 1) {
                amountText.text = item.amount.ToString();
            } else {
                amountText.text = "";
            }
            
            x = x + itemSlotCellSize;
        }
    }
}
