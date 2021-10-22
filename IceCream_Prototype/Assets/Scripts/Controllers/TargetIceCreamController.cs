using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;
using com.flamingo.icecream.managers;

public class TargetIceCreamController : BezierWalkerWithSpeed
{

    public List<int> accuracyIDs= new List<int>();
        
    private List<CreamColor> _colors;
    private int _numberOfColors;
    private int _counter = 0;
    private float _nextPercentage = 0f;
    private List<int> _percentagesOfColors = new List<int>();
    private bool _isActive = true;
    
    private int _fullPercent = 10;
    
    [SerializeField] private GameObject _targetCreamPrefab;
    [SerializeField] private Transform _targetCreamParent;
    [SerializeField] private BezierSpline _spline;
    [SerializeField] private LevelManager _levelManager;

    private void OnEnable()
    {
        Actions.OnGameFinished += Activate;
    }

    private void OnDisable()
    {
        Actions.OnGameFinished -= Activate;
    }

    public void Initialize()
    {
        
        _colors = _levelManager.GetColorsOfLevel();
        _numberOfColors = _colors.Count;
        SetPercentages();
        
        accuracyIDs.Clear();
        _counter = 0;
        NormalizedT = 0;
        
        foreach (Transform child in _targetCreamParent) {
            Destroy(child.gameObject);
        }
        
    }
    
    void Start()
    {
        _colors = _levelManager.GetColorsOfLevel();
        _numberOfColors = _colors.Count;
        SetPercentages();
    }

    protected override void Update()
    {
        if (_isActive)
        {
            base.Update();
            GenerateTargetCream();
        }
        else
        {
            return;
        }
        
    }

    
    public void GenerateTargetCream()
    {
        if (NormalizedT < 1)
        {
            if (_counter == 0)
            {
                _nextPercentage = _percentagesOfColors[_counter] / 10f;
            }
            else
            {
                _nextPercentage = 0;
                
                for (int i = 0; i <= _counter; i++)
                {
                    _nextPercentage += _percentagesOfColors[i] / 10f;
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
        else
        {
            _isActive = false;
        }
    }

    public void Activate()
    {
        Initialize();
        GenerateTargetCream();
        _isActive = true;
    }

    
    //set percentages of different color creams
    public void SetPercentages()
    {

        _percentagesOfColors.Clear();
        
        for (int i = 0; i < _numberOfColors; i++)
        {
            _percentagesOfColors.Add(0);
        }
        for (int i = 0; i <_fullPercent; i++) {
 
            // Increment any random element from the list by 1
            _percentagesOfColors[Random.Range(0,_percentagesOfColors.Count )]++;
        }
        
        /*
        for (int i = 0; i < _percentagesOfColors.Count; i++)
        {
            Debug.Log(_percentagesOfColors[i]);
        }*/
    }

    public List<int> GetPercentages()
    {
        return _percentagesOfColors;
    }
}
