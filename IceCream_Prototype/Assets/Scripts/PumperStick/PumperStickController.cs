using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace com.flamingo.icecream.pumperstick
{
    public class PumperStickController : MonoBehaviour
    {
        private SceneManager _sceneManager;

        private void OnEnable()
        {
            Actions.OnButtonPressed += PressPumperStick;
            Actions.OnButtonReleased += ReleasePumperStick;

        }

        private void OnDisable()
        {
            Actions.OnButtonPressed -= PressPumperStick;
            Actions.OnButtonReleased -= ReleasePumperStick;
        }

        void Start()
        {
            _sceneManager = FindObjectOfType<SceneManager>();

        }

        public void PressPumperStick(GameObject button)
        {
            foreach (var pumperStick in _sceneManager.pumperSticks)
            {
                if (button.name == pumperStick.button.name)
                {
                    pumperStick.pumperStick.transform.DORotate(Vector3.right * 45f, 1f);
                }
            }
        }

        public void ReleasePumperStick(GameObject button)
        {
        
            foreach (var pumperStick in _sceneManager.pumperSticks)
            {
                if (button.name == pumperStick.button.name)
                {
                    pumperStick.pumperStick.transform.DORotate(Vector3.zero, 1f);
                }
            }
        
        }
    
    
    }
    
}
