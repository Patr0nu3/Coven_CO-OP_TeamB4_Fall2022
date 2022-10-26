using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public inventories myBag;
    public GameObject slotGrid;
    public slot slotPrefab;
    public Text itemInfo;
    // public GameObject emptySlot;
    // public List<GameObject> slots = new List<GameObject>();

    void Awake()
    {
        if (instance != null) {
            Destroy(this);
        }
        instance = this;

        transform.GetChild(2).gameObject.SetActive(false);

        foreach (var item in instance.myBag.itemList) {
            item.itemHeld = 1;
        }
        instance.myBag.itemList.Clear();
    }

    //void Start(){
    //    myBag.SetActive(false);
    //}

    // void Update()
    // {
    //     RefreshItem();
    // }

    private void OnEnable() {
        RefreshItem();
        instance.itemInfo.text = "";
    }

    private void OnDisable()
    {
        RefreshItem();
    }

    public static void UpdateItemInfo(string itemInfo)
    {
        instance.itemInfo.text = itemInfo;
    }

    public static void CreateNewItem(items item)
    {
        // create item using prefab
        slot newItem = Instantiate(instance.slotPrefab, 
                                   instance.slotGrid.transform.position,
                                   Quaternion.identity);
        
        // add item as the child of the slots
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);

        // transfer data
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
    }

    public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++) {
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        for (int j = 0; j < instance.myBag.itemList.Count; j++) {
            Debug.Log("j is " + j.ToString());
            Debug.Log("currItem is " + instance.myBag.itemList[j].itemName);
            if (instance.myBag.itemList[j].itemHeld > 0) {
                Debug.Log("success:  " + instance.myBag.itemList[j].itemName);
                CreateNewItem(instance.myBag.itemList[j]);
            }
        }
    }
}
