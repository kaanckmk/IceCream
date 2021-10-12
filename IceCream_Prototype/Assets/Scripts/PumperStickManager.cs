using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumperStickManager : MonoBehaviour
{
    private void OnEnable()
    {
        Actions.OnButtonPressed += PressPumperStick;
    }

    private void OnDisable()
    {
        Actions.OnButtonPressed -= PressPumperStick;
    }

    public void PressPumperStick()
    {
        
    }
}
