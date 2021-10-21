using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BezierSolution;
using Microsoft.Unity.VisualStudio.Editor;
using Image = UnityEngine.UI.Image;
using com.flamingo.icecream.managers;

public class CreamGenerator : MonoBehaviour
{
    
    [SerializeField] private GameObject _creamPrefab;
    [SerializeField] private Transform _creamParent;
    [SerializeField] private Transform _creamPumperPrefab;
    [SerializeField] private BezierSpline _spline;
    [SerializeField] private MachineMovement _machineMovement;
    //to check match
    [SerializeField] private TargetIceCreamController _targetIceCreamController;

    
    private List<CreamColor> _colors;
    private List<int> _accuracy = new List<int>();
    private float _percentage=0;
    private int _scorepoint=0;
    
    private void OnEnable()
    {
        Actions.OnButtonHolding += GenerateCream;
        Actions.OnGameFinished += StopCreamGeneration;
        Actions.OnGameFinished += CheckAccuracy;
    }

    private void OnDisable()
    { 
        Actions.OnButtonHolding -= GenerateCream;
        Actions.OnGameFinished -= StopCreamGeneration;
        Actions.OnGameFinished -= CheckAccuracy;
    }

    public void GenerateCream(GameObject button)
    {
        
        var cream = Instantiate(_creamPrefab, _creamPumperPrefab.position, transform.rotation,_creamParent);
        cream.GetComponent<Renderer>().material.SetTexture("_MainTex",button.GetComponent<Image>().sprite.texture);
        cream.transform.DOMove((_spline.GetPoint(_machineMovement.NormalizedT)), 1f);

        
        //Debug.Log(_machineMovement.NormalizedT);
        
        
        /*
         As a first aproach: joint system is tried to connect cream segments with each other. Not an expected result!
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
        foreach (Transform child in _creamParent) {
            Destroy(child.gameObject);
        }
    }

    public void CheckAccuracy()
    {
        List<int> targetAccuracy = _targetIceCreamController.accuracyIDs;
        
        Debug.Log(targetAccuracy.Count + "    " + _accuracy.Count);
        
        for (int i = 0; i < targetAccuracy.Count; i++)
        {
            if (_accuracy[i] == targetAccuracy[i])
            {
                _scorepoint++;
            }
            else
            {
                _scorepoint--;
            }
        }
        _percentage = Mathf.Floor((_scorepoint * 100) / targetAccuracy.Count);
    }

    public float GetPercentage()
    {
        return _percentage;
    }
}
