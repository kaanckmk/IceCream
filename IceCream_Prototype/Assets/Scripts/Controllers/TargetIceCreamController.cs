using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;
using com.flamingo.icecream.managers;

public class TargetIceCreamController : BezierWalkerWithSpeed
{

    public List<int> accuracyIDs;
    public List<int> percentagesOfColors;
        
    private List<CreamColor> _colors;
    private int _numberOfColors;
    private int _counter;
    private float _nextPercentage;
    
    [SerializeField] private GameObject _targetCreamPrefab;
    [SerializeField] private Transform _targetCreamParent;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private BezierSpline _spline;


    void Start()
    {
        accuracyIDs = new List<int>();
        percentagesOfColors = new List<int>();
        _colors = _levelManager.GetColorsOfLevel();
        _numberOfColors = _colors.Count;
        SetPercentages();
        _nextPercentage = 0f;
        _counter = 0;
    }

    protected override void Update()
    {
        base.Update();
        GenerateTargetCream();
    }

    
    public void GenerateTargetCream()
    {
        if (NormalizedT < 1)
        {
            if (_counter == 0)
            {
                _nextPercentage = percentagesOfColors[_counter] / 10f;
            }
            else
            {
                _nextPercentage = 0;
                
                for (int i = 0; i <= _counter; i++)
                {
                    _nextPercentage += percentagesOfColors[i] / 10f;
                }
            }
        
            if (_counter < _numberOfColors)
            {
                
                var targetCream = Instantiate(_targetCreamPrefab, _spline.GetPoint(NormalizedT),
                    transform.rotation, _targetCreamParent);
                targetCream.GetComponent<Renderer>().material.SetTexture("_MainTex",_colors[_counter].colorTexture.texture);
                targetCream.layer = 6;
                accuracyIDs.Add(_counter);
                
                if (NormalizedT >= _nextPercentage)
                {
                    _counter++;
                }
            }
            
        }
        
        
    }

    //set percentages of different color creams
    public void SetPercentages()
    {
        int fullPercent = 10;

        for (int i = 0; i < _numberOfColors; i++)
        {
            percentagesOfColors.Add(0);
        }
        for (int i = 0; i <fullPercent; i++) {
 
            // Increment any random element from the list by 1
            percentagesOfColors[Random.Range(0,percentagesOfColors.Count )]++;
        }
        
        /*
        for (int i = 0; i < percentagesOfColors.Count; i++)
        {
            Debug.Log(percentagesOfColors[i]);
        }*/
    }
}
