using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    float angle =0;
    private float speed = (2 * Mathf.PI) / 3; //2*PI in degress is 360, so you get 5 seconds to complete a circle
    float radius=3;
    private float timer = 3f;
    public GameObject cube;

    
    void Start()
    {
        Debug.Log(cube.transform.GetSiblingIndex());
    }
    
    void Update()
    {
        angle += speed*Time.deltaTime; //if you want to switch direction, use -= instead of +=
        var x = Mathf.Cos(angle)*radius;
        var y = Mathf.Sin(angle)*radius;
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            radius -= 0.1f;
            timer = 3f;
        }

    }
}
