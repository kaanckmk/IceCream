using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace com.flamingo.icecream.managers
{
    public class LevelManager : MonoBehaviour
    {
        
        public int currentLevel=1;

        //general color pool
        [SerializeField] private List<CreamColor> _allColors;
        [SerializeField]  private TMP_Text _levelText;
        
        private int _currentColorNumber;
        private List<CreamColor> _currentLevelColors = new List<CreamColor>();
        
        
        private void OnEnable()
        {
            Actions.OnGameFinished += IncreaseLevel;
        }

        private void OnDisable()
        { 
            Actions.OnGameFinished -= IncreaseLevel;
        }

        void Awake()
        {
            SetColorsOfLevel();
        }
        
        public List<CreamColor> SetColorsOfLevel()
        {
            //color number in a game will be incrased in every 3 level. 
            //starting number of colors is 2 for the first levels
            _currentColorNumber = (int)Mathf.Floor(currentLevel / 3) + 2;
            List<CreamColor> tmp = new List<CreamColor>();
            for (int i = 0; i < _allColors.Count; i++)
            {
                tmp.Add(_allColors[i]);
            }
            
            //initialization of current level colors.
            InitializeNewLevelColors();
            
            for (int i = 0; i < _currentColorNumber; i++)
            {
                int tmpIndex = Random.Range(0, tmp.Count);
                _currentLevelColors.Add(tmp[tmpIndex]);
                tmp.RemoveAt(tmpIndex);
            }
            return _currentLevelColors;
        }

        public List<CreamColor> GetColorsOfLevel()
        {
            
            List<CreamColor> tmp = new List<CreamColor>();
            tmp.Clear();
            for (int i = 0; i < _currentLevelColors.Count; i++)
            {
                tmp.Add(_currentLevelColors[i]);
            }
            return tmp;
        }

        public void IncreaseLevel()
        {
            SetColorsOfLevel();
            currentLevel += 1;
            _levelText.text = "Level " + currentLevel;
        }

        public void InitializeNewLevelColors()
        {
            _currentLevelColors.Clear();
        }
    }
}