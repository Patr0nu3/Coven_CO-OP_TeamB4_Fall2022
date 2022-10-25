using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, 
                        IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTrans;
    private CanvasGroup canvasGroup;

    // [SerializeField] private Canvas canvas;

    private void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("anc: x:" + rectTrans.anchoredPosition.x);
        rectTrans.anchoredPosition += eventData.delta / 1.15f; // / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }
}
