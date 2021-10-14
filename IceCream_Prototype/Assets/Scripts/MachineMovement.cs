using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineMovement : MonoBehaviour
{
    
    private float _angle =0;
    private float _speed = (2 * Mathf.PI) / 3; //2*PI in degress is 360, so you get 3 seconds to complete a circle
    private float _radius= 0.007f;
    private float _timer = 3f;
    private void OnEnable()
    {
        Actions.OnButtonHolding += MoveMachine;
    }

    private void OnDisable()
    { 
        Actions.OnButtonHolding -= MoveMachine;
    }

    public void MoveMachine()
    {
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
        }
    }
    
    
}
