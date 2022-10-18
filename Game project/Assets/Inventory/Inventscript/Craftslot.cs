using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craftslot : MonoBehaviour
{
    public int slotNumber;
    public items item;

    public void GetItem(items get) {
        item = get;
    }
}
