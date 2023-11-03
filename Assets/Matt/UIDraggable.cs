using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIDraggable : MonoBehaviour, IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    private bool isDragging = false;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // On pointer down, enable dragging.
        isDragging = true;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // While dragging, move the object based on the mouse position.
        Vector2 localPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localPosition))
        {
            rectTransform.localPosition = localPosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // On pointer up, disable dragging.
        isDragging = false;
        canvasGroup.blocksRaycasts = true;
    }
}
