using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneManager : MonoBehaviour
{
    public Color[] colors;
    public List<PumperStick> pumperSticks=new List<PumperStick>();
    
    public GameObject buttonprefab;
    public GameObject pumperStickPrefab;
    
    [SerializeField] private GameObject _creamPumperParent;
    [SerializeField] private GameObject _buttonsPanel;
    

    private float _magicValueForAllignment = 2.8f;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            GameObject button =  Instantiate(buttonprefab,_buttonsPanel.transform);
            button.name = "Button" + colors[i].colorName;
            button.GetComponent<Button>().image.sprite = colors[i].colorTexture;
            
            GameObject pumperStick = Instantiate(pumperStickPrefab, _creamPumperParent.transform);
            pumperStick.GetComponent<Renderer>().material.SetTexture("_MainTex",colors[i].colorTexture.texture);
            pumperStick.name = "Pumper" + colors[i].colorName;
            
            //horizontal layout allignment of pumper sticks
            float x = (_magicValueForAllignment / (colors.Length + 1)) * (i+1);
            pumperStick.transform.localPosition =
                new Vector3(pumperStick.transform.localPosition.x - x,
                    pumperStick.transform.localPosition.y,
                    pumperStick.transform.localPosition.z);

            pumperSticks.Add(new PumperStick(pumperStick,button));
        }
    }

}
