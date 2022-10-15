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
            
            // set position
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x, y);
            
            // set image
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            
            // set item count
            Text amountText = itemSlotRectTransform.Find("amountText").GetComponent<UnityEngine.UI.Text>();
            Debug.Log(amountText);
            if (item.amount > 1) {
                amountText.text = item.amount.ToString();
            } else {
                amountText.text = "";
            }
            
            x = x + itemSlotCellSize;
        }
    }
}
