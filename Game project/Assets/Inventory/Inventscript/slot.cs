using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slot : MonoBehaviour
{
    public items slotItem;
    public Image slotImage;
    public Text slotNum;

    public GameObject itemInSlot;

    public void ItemOnClicked()
    {
        InventoryManager.UpdateItemInfo(slotItem.itemInfo);
    }

    public items DeliverItem()
    {
        return slotItem;
    }

    // public void SetUpSlot(items item)
    // {
    //     if (item == null) {
    //         itemInSlot.SetActive(false);
    //         return;
    //     }

    //     slotImage.sprite = item.itemImage;
    //     slotNum.text = item.itemHeld.ToString();
    // }
}
