using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BezierSolution;
using Microsoft.Unity.VisualStudio.Editor;
using Image = UnityEngine.UI.Image;

public class CreamGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _creamPrefab;
    [SerializeField] private Transform _creamPumperPrefab;
    [SerializeField] private BezierSpline _spline;
    [SerializeField] MachineMovement _machineMovement;

    private List<GameObject> _creams = new List<GameObject>();
    private float _timer = 0.1f;
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

    public void GenerateCream(GameObject button)
    {
        
        var cream = Instantiate(_creamPrefab, _creamPumperPrefab.position, transform.rotation);
        cream.GetComponent<Renderer>().material.SetTexture("_MainTex",button.GetComponent<Image>().sprite.texture);
        cream.transform.DOMove((_spline.GetPoint(_machineMovement.NormalizedT)), 2f);
        Debug.Log(_machineMovement.NormalizedT);
        
        /*
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
        Actions.OnButtonHolding -= GenerateCream;
    }
}
