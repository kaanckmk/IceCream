using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumperStickManager : MonoBehaviour
{
    public SceneManager sceneManager;
    public ButtonManager buttonManager;
    private void OnEnable()
    {
        Actions.OnButtonPressed += PressPumperStick;
        
    }

    private void OnDisable()
    {
        Actions.OnButtonPressed -= PressPumperStick;
    }

    void Start()
    {
        sceneManager = FindObjectOfType<SceneManager>(); 
        buttonManager = FindObjectOfType<ButtonManager>();
    }

    public void PressPumperStick()
    {
        
        foreach (var pumperStick in sceneManager.pumperSticks)
        {
            if (pumperStick.pumperStickID == buttonManager.GetButtonID())
            {
                Debug.Log(pumperStick.pumperStickID);
                pumperStick.pumperStick.transform.Rotate (Vector3.down * 50 * Time.deltaTime, Space.Self);
            }
        }
    }
}
