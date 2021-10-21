using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public static class Actions
{    
    
    public static Action<GameObject> OnButtonPressed;
    public static Action<GameObject> OnButtonReleased;
    public static Action<GameObject> OnButtonHolding;


    public static Action OnGameFinished;
    public static Action OnNewLevelStarted;
    public static Action OnTargetCreated;


}
