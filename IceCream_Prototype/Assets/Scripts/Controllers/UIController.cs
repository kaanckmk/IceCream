using System.Collections;
using System.Collections.Generic;
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
        }

        private void OnDisable()
        { 
            Actions.OnGameFinished -= ActivateFinishUI;
            Actions.OnTargetCreated -= SetTargetImage;
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

        public void SetAccuracyText()
        {
            Debug.Log(_finishPanel.transform.Find("Accuracy").name);   //gameObject.GetComponent<TextMeshPro>().text = "Accuracy is:  %";// + _creamGenerator.GetPercentage();
        }

        public void SetTargetImage()
        {
            _targetIceCreamPanel.transform.Find("Image").GetComponent<Image>().sprite = 
                Resources.Load<Sprite>("LevelTargetImages/" +_levelManager.currentLevel + ".png" );
        }
    
    }
    
}
