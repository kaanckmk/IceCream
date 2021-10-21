using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.flamingo.icecream.controllers
{
    public class ProgressBarController : MonoBehaviour
    {
        [SerializeField] private Image _progressBar;
        [SerializeField] private MachineMovement _machineMovement;
    
        private void OnEnable()
        {
            Actions.OnButtonHolding += UpdateProgressBar;
        }

        private void OnDisable()
        {
            Actions.OnButtonHolding -= UpdateProgressBar;
        }

        public void UpdateProgressBar(GameObject a)
        {
            _progressBar.fillAmount = _machineMovement.NormalizedT;
        }
    }
    
}
