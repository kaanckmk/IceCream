using System.Collections;
using System.Collections.Generic;
using com.flamingo.icecream.pumperstick;
using UnityEngine;
using UnityEngine.UI;

namespace com.flamingo.icecream.managers
{
    public class SceneManager : MonoBehaviour
    {
        public List<PumperStick> pumperSticks=new List<PumperStick>();
    
        public GameObject buttonprefab;
        public GameObject pumperStickPrefab;
    
        [SerializeField] private Transform _creamPumperParent;
        [SerializeField] private Transform _buttonsPanel;
        
        [SerializeField] private LevelManager _levelManager;
        
        private List<CreamColor> _colors;
        private float _magicValueForAllignment = 2.8f;

        private void OnEnable()
        {
            Actions.OnGameFinished += CreateNewScene;
        }

        private void OnDisable()
        { 
            Actions.OnGameFinished -= CreateNewScene;
        }

        void Start()
        {
            Actions.OnNewLevelStarted?.Invoke();
            CreateNewScene();
        }
        public void CreateNewScene()
        {
            InitializeScene();
            
            _colors = _levelManager.GetColorsOfLevel();
            
            for (int i = 0; i < _colors.Count; i++)
            {
                GameObject button =  Instantiate(buttonprefab,_buttonsPanel);
                button.name = "Button" + _colors[i].colorName;
                button.GetComponent<Button>().image.sprite = _colors[i].colorTexture;
            
                GameObject pumperStick = Instantiate(pumperStickPrefab, _creamPumperParent);
                pumperStick.GetComponent<Renderer>().material.SetTexture("_MainTex",_colors[i].colorTexture.texture);
                pumperStick.name = "Pumper" + _colors[i].colorName;
            
                //horizontal layout allignment of pumper sticks
                float x = (_magicValueForAllignment / (_colors.Count + 1)) * (i+1);
                pumperStick.transform.localPosition =
                    new Vector3(pumperStick.transform.localPosition.x - x,
                        pumperStick.transform.localPosition.y,
                        pumperStick.transform.localPosition.z);

                pumperSticks.Add(new PumperStick(pumperStick,button));
            }
        }

        public void InitializeScene()
        {
            //initializitaion of scene
            pumperSticks.Clear();
            foreach (Transform child in _creamPumperParent) {
               Destroy(child.gameObject);
            }
            foreach (Transform child in _buttonsPanel) {
                Destroy(child.gameObject);
            }
            
            
        }

    }
    
}

