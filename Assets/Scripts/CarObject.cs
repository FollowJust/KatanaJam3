using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObject : MonoBehaviour
{
    public Vector3 sourcePosition, targetPosition;
    public float velocity = 10.0f;

    public CarObject(Vector3 start, Vector3 target)
    {
        sourcePosition = start;
        targetPosition = target + (target - start); 
    }

    void Start()
    {
        transform.position = sourcePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (TargetReached())
        {

        }
    }

    void Move()
    {
        float step = Time.deltaTime * velocity;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hit = other.gameObject;
        
    }


    bool TargetReached()
    {
        // "==" is approximate equality
        return transform.position == targetPosition;
    }
}
