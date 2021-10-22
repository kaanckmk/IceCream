using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FinishButtonController : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Actions.OnNewLevelStarted?.Invoke();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
    }
}
