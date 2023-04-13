using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventHandler : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Action<PointerEventData> OnPointerClickAction = null;
    public Action<PointerEventData> OnBeginDragAction = null;
    public Action<PointerEventData> OnDragAction = null;
    public Action<PointerEventData> OnEndDragAction = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnPointerClickAction != null)
        {
            OnPointerClickAction.Invoke(eventData);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnBeginDragAction != null)
        {
            OnBeginDragAction.Invoke(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragAction != null)
        {
            OnDragAction.Invoke(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (OnEndDragAction != null)
        {
            OnEndDragAction.Invoke(eventData);
        }
    }
}
