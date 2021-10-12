using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreamPumperManager : MonoBehaviour
{
    
    private List<Transform> _creamPumpers = new List<Transform>();
    

    void Awake()
    {
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform pumper in this.transform)
        {
            _creamPumpers.Add(pumper);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateCreamPumper()
    {
        
    }
}
