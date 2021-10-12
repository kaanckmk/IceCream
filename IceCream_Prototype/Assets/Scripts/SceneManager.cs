using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneManager : MonoBehaviour
{
    public Color[] colors;
    public List<GameObject> buttons = new List<GameObject>();

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
            buttons.Add(Instantiate(_buttonPrefab, _buttonsPanel.transform));
            buttons[i].name = "Button" + colors[i].name; 
            buttons[i].GetComponent<Button>().image.sprite = colors[i].colorTexture;
            
            //instantiate pumper sticks
            GameObject pumperStick = Instantiate(_creamPumperStickPrefab, _creamPumperParent.transform);
            pumperStick.GetComponent<Renderer>().material.SetTexture("_MainTex",colors[i].colorTexture.texture);
            
            pumperStick.name = "Pumper" + colors[i].name;
            
            //horizontal layout allignment of pumper sticks
            float x = (_magicValueForAllignment / (colors.Length + 1)) * (i+1);
            pumperStick.transform.localPosition =
                new Vector3(pumperStick.transform.localPosition.x - x, pumperStick.transform.localPosition.y, pumperStick.transform.localPosition.z);

        }
    }

}
