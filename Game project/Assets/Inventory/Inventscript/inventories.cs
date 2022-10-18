using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory",
                 menuName = "Inventory/inventories")]

public class inventories : ScriptableObject
{
    public List<items> itemList = new List<items>();
}
