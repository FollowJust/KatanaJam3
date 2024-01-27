using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObject : MonoBehaviour
{
    public Vector3 startPosition, targetPosition;

    public float velocity = 10.0f;

    void Start()
    {
        
    }

    Vector3 getStep()
    {
        return Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
