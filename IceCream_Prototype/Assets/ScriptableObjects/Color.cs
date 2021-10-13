using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Color", menuName = "Color")] 
public class Color : ScriptableObject
{
    public Sprite colorTexture;
    public string colorName;
}
