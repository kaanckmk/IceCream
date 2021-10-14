using System;
using System.Collections;
using System.Collections.Generic;
using BezierSolution;
using UnityEngine;

public class MachineMovement : BezierWalkerWithSpeed
{
    /*
    private float _angle =0;
    private float _speed = (2 * Mathf.PI) / 3; //2*PI in degress is 360, so you get 3 seconds to complete a circle
    private float _radius= 0.007f;
    private float _timer = 3f;
    */

    private float _initialHeight;
    private bool _isActive;
    private void OnEnable()
    {
        Actions.OnButtonHolding += MoveAroundCurve;
        Actions.OnButtonReleased += StopMovement;
    }

    private void OnDisable()
    {
        Actions.OnButtonHolding -= MoveAroundCurve;
        Actions.OnButtonReleased -= StopMovement;
    }

    private void Awake()
    {
        _initialHeight = transform.position.y;
        _isActive = false;
    }

    protected override void Update()
    {
        UpdateHeightPosition();

        if (_isActive)
        {
            base.Update();
            UpdateHeightPosition();
        }
        else
        {
            return;
        }

        if (NormalizedT == 1)
        {
            Actions.OnGameFinished?.Invoke();
        }
    }
    private void UpdateHeightPosition()
    {
        transform.position = new Vector3(transform.position.x, _initialHeight, transform.position.z);
    }
    private void MoveAroundCurve(GameObject a)
    {
        _isActive = true;
    }

    private void StopMovement(GameObject a)
    {
        _isActive = false;
    }
    
    /*public void MoveMachine()
    {
        /*
        _angle += _speed*Time.deltaTime; //if you want to switch direction, use -= instead of +=
        var x = Mathf.Cos(_angle)*_radius + this.gameObject.transform.position.x;
        var z = Mathf.Sin(_angle)*_radius + this.gameObject.transform.position.z;
        
        this.gameObject.transform.position = new Vector3(x, this.gameObject.transform.position.y,z);
        
        //timer to decrease radious
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _radius -= 0.001f;
            _speed += 0.02f;
            _timer = 1f;
        }

        if (_radius <= 0)
        {
            Actions.OnGameFinished?.Invoke();
            _radius = 0;
            Debug.Log("Cream Finished");
        }#1#
    }*/
    
    
}
