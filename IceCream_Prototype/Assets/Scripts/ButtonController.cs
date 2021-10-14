using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController: MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    
    private bool _isHolding;
    
    
    private void Update()
    {
        if (_isHolding)
        {
            Actions.OnButtonHolding?.Invoke();
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Actions.OnButtonPressed?.Invoke(this.gameObject);
        _isHolding = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Actions.OnButtonReleased?.Invoke(this.gameObject);
        _isHolding = false;
    }

}
