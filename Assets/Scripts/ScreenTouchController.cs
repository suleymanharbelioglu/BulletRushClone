using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScreenTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private Image pivotImage;
    private Vector2 _touchPosition;
    public Vector2 Direction {get; private set;}  // making private type
    public void OnPointerDown(PointerEventData eventData)
    {
        _touchPosition = eventData.position ; // taking mose pos on first click
        pivotImage.enabled  = true;
        pivotImage.transform.position = _touchPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Direction = Vector3.zero;
        pivotImage.enabled = false;
        
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        var delta = eventData.position - _touchPosition;
        Direction = delta.normalized;   // giving value beween -1 and 1
        
    }
}
