using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneManager : MonoBehaviour
{
    public Color[] colors;
    public List<ButtonStruct> buttons = new List<ButtonStruct>();
    public List<PumperStickStruct> pumperSticks = new List<PumperStickStruct>();
 
    [SerializeField] private GameObject _creamPumperParent;
    [SerializeField] private GameObject _buttonsPanel;
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private GameObject _creamPumperStickPrefab;

    private float _magicValueForAllignment = 2.8f;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            
            //instantiate buttons
            ButtonStruct tmpButton = new ButtonStruct();
            tmpButton.button =  Instantiate(_buttonPrefab, _buttonsPanel.transform);
            tmpButton.buttonID = colors[i].colorID;
            tmpButton.button.name = "Button" + colors[i].name; 
            tmpButton.button.GetComponent<Button>().image.sprite = colors[i].colorTexture;
            buttons.Add(tmpButton);
            
            //instantiate pumper sticks and add it to list
            PumperStickStruct tmpPumperStick = new PumperStickStruct();
            tmpPumperStick.pumperStick  = Instantiate(_creamPumperStickPrefab, _creamPumperParent.transform);
            tmpPumperStick.pumperStick.GetComponent<Renderer>().material.SetTexture("_MainTex",colors[i].colorTexture.texture);
            tmpPumperStick.pumperStick.name = "Pumper" + colors[i].name;
            tmpPumperStick.pumperStickID = colors[i].colorID;
            pumperSticks.Add(tmpPumperStick);
            
            //horizontal layout allignment of pumper sticks
            float x = (_magicValueForAllignment / (colors.Length + 1)) * (i+1);
            tmpPumperStick.pumperStick.transform.localPosition =
                new Vector3(tmpPumperStick.pumperStick.transform.localPosition.x - x,
                    tmpPumperStick.pumperStick.transform.localPosition.y,
                    tmpPumperStick.pumperStick.transform.localPosition.z);

        }
    }

}
