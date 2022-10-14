using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private InventoryA inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    
    // grab all ui references 
    private void Awake() {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }
    
    // sets inventory to ui inventory
    public void SetInventory(InventoryA inventory) {
        this.inventory = inventory;
        RefreshInventoryItems();
    }
    
    private void RefreshInventoryItems() {
        float x = -145f;
        float y = 0f;
        float itemSlotCellSize = 50f;
        
        // loops through inventory list
        foreach (Item item in inventory.GetItemList()) {
            // gets the Rect Transform of the itemSlotTemplate
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            
            // set position
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x, y);
            
            // set image
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            
            
            x = x + itemSlotCellSize;
        }
    }
}
