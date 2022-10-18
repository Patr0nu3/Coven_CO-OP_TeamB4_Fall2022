using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropItem : MonoBehaviour, IDropHandler
{
    private void OnEnable() {
        deleteCraft();
    }

    private void deleteCraft()
    {
        
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("yeahhhh\n");
        GameObject newOb = GameObject.Instantiate(eventData.pointerDrag.gameObject);
        newOb.transform.position = transform.position;
        newOb.transform.parent = transform;
        Debug.Log("final anc: " + GetComponent<RectTransform>().anchoredPosition.x);

        GetComponent<Craftslot>().GetItem(eventData.pointerDrag.gameObject.GetComponent<slot>().DeliverItem());
    }
}
