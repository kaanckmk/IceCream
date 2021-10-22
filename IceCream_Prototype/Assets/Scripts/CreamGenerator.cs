using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BezierSolution;
using Microsoft.Unity.VisualStudio.Editor;
using Image = UnityEngine.UI.Image;
using com.flamingo.icecream.managers;
using UnityEditor.Experimental;

public class CreamGenerator : MonoBehaviour
{
    
    [SerializeField] private GameObject _creamPrefab;
    [SerializeField] private Transform _creamParent;
    [SerializeField] private Transform _creamPumperPrefab;
    [SerializeField] private BezierSpline _spline;
    
    [SerializeField] private MachineMovement _machineMovement;
    //to check match
    [SerializeField] private TargetIceCreamController _targetIceCreamController;
    

    private int _creamCounter = 0;
    private float _percentage;
    private int _scorepoint=0;
    private List<int> _colorPercentage;
    private int _colorCounter = 0;
    private float _nextPercentage = 0;
    
    public void Initialize()
    {
        _creamCounter = 0;
        _colorCounter = 0;
        _scorepoint = 0;
        _nextPercentage = 0;
        _percentage = 0;
        _colorPercentage = _targetIceCreamController.GetPercentages();
    }
    private void OnEnable()
    {
        Actions.OnButtonHolding += GenerateCream;
        Actions.OnGameFinished += StopCreamGeneration;
    }

    private void OnDisable()
    { 
        Actions.OnButtonHolding -= GenerateCream;
        Actions.OnGameFinished -= StopCreamGeneration;
    }

    void Start()
    {
        Initialize();
    }

    public void GenerateCream(GameObject button)
    {
        
        var cream = Instantiate(_creamPrefab, _creamPumperPrefab.position, transform.rotation,_creamParent);
        cream.GetComponent<Renderer>().material.SetTexture("_MainTex",button.GetComponent<Image>().sprite.texture);
        cream.transform.DOMove((_spline.GetPoint(_machineMovement.NormalizedT)), 1f);
        _creamCounter++;
        CheckAccuracy(button);
        
        //Debug.Log(_machineMovement.NormalizedT);
        
        
        /* As a first aproach: joint system is tried to connect cream segments with each other. Not an expected result!
         
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            GameObject creamSegment = Instantiate(_creamPrefab, _creamPumperPrefab);
            _creams.Add(creamSegment);
            if (_creams.Count > 1)
            {
                _creams[_creams.Count - 2].GetComponent<SpringJoint>().connectedBody =
                    _creams[_creams.Count - 1].GetComponent<Rigidbody>();
            }

            _timer = 0.1f;
        }*/
    }

    public void StopCreamGeneration()
    {
        Initialize();
        
        foreach (Transform child in _creamParent) {
            Destroy(child.gameObject);
        }
    }

    public void CheckAccuracy(GameObject button)
    {
        var id = button.transform.GetSiblingIndex();

        if (_machineMovement.NormalizedT < 1)
        {
            if (_colorCounter == 0)
            {
                _nextPercentage = _colorPercentage[_colorCounter] / 10f;
            }
            else
            {
                _nextPercentage = 0;
                
                for (int i = 0; i <= _colorCounter; i++)
                {
                    _nextPercentage += _colorPercentage[i] / 10f;
                }
            }
        
            if (_colorCounter < _colorPercentage.Count)
            {
                if (id == _colorCounter)
                {
                    _scorepoint++;
                }
                else
                {
                    _scorepoint--;
                }
                if (_machineMovement.NormalizedT >= _nextPercentage)
                {
                    _colorCounter++;
                }
            }
            
        }
        
        _percentage = Mathf.Floor((_scorepoint * 100) / _creamCounter);
    }



    public float GetAccuracy()
    {
        return _percentage;
    }
}
