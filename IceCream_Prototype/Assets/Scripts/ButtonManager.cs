using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour, IPointerDownHandler
{
    public SceneManager sceneManager;
    public ButtonStruct button;
    
    
    // Start is called before the first frame update
    void Start()
    {
        sceneManager = FindObjectOfType<SceneManager>();
    }
    

    public void OnPointerDown(PointerEventData eventData)
    {
        Actions.OnButtonPressed?.Invoke();
        
        //findout what is the id of pressed button
        button = new ButtonStruct();
        button.button = this.gameObject;
        foreach (var a in sceneManager.buttons)
        {
            if (a.button == button.button)
            {
                button.buttonID = a.buttonID;
            }
        }

        /*
        Debug.Log(button.buttonID);
        Debug.Log(button.button.name);*/
    }

    public int GetButtonID()
    {
        return button.buttonID;
    }
}
