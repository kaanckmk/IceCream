using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using com.flamingo.icecream.managers;

namespace com.flamingo.icecream.controllers
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject _buttonPanel;        
        [SerializeField] private GameObject _targetIceCreamPanel;
        
        [SerializeField] private GameObject _finishPanel;

        [SerializeField] private CreamGenerator _creamGenerator;
        [SerializeField] private LevelManager _levelManager;
    
        private void OnEnable()
        {
            Actions.OnGameFinished += ActivateFinishUI;
            Actions.OnTargetCreated += SetTargetImage;
            Actions.OnNewLevelStarted += ActivateGameUI;
        }

        private void OnDisable()
        { 
            Actions.OnGameFinished -= ActivateFinishUI;
            Actions.OnTargetCreated -= SetTargetImage;
            Actions.OnNewLevelStarted -= ActivateGameUI;
        }

        void Start()
        {
            _buttonPanel.SetActive(true);
            _targetIceCreamPanel.SetActive(true);
        }
        public void ActivateFinishUI()
        {
            _buttonPanel.SetActive(false);
            _targetIceCreamPanel.SetActive(false);
            _finishPanel.SetActive(true);
            SetAccuracyText();
        }

        public void ActivateGameUI()
        {
            _buttonPanel.SetActive(true);
            _targetIceCreamPanel.SetActive(true);
            _finishPanel.SetActive(false);
        }

        public void SetAccuracyText()
        {
            _finishPanel.transform.Find("Accuracy").gameObject.GetComponent<TMP_Text>().text = 
                "Accuracy is:  %" + _creamGenerator.GetAccuracy();
        }

        public void SetTargetImage()
        {
            
            Texture2D targetTexture = new Texture2D(2,2);
            targetTexture = Resources.Load (string.Format("LevelTargetImages/{0}",
                _levelManager.currentLevel)) as Texture2D;

            _targetIceCreamPanel.transform.Find("RawImage").GetComponent<RawImage>().texture = targetTexture;

        }
        /*
        public static Texture2D LoadPNG(string filePath) {
     
            Texture2D tex = null;
            byte[] fileData;
     
            if (File.Exists(filePath)) {
                fileData = File.ReadAllBytes(filePath);
                tex = new Texture2D(2, 2);
                tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
            }
            return tex;
        }*/
    
    }
    
}
