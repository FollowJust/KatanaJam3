using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PukeObject : MonoBehaviour
{
    private Vector3 projectileDirection;

    public float velocity = 1.0f;

    void Start()
    {
        projectileDirection = Vector3.Normalize(transform.position - transform.parent.position);
        projectileDirection.y = 0.0f;
    }

    void Update()
    {
        float step = Time.deltaTime * velocity;
        transform.position += projectileDirection * step;
        transform.rotation = Quaternion.LookRotation(projectileDirection);
    }
}
