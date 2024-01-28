using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashObject : MonoBehaviour
{
    private Vector3 projectileDirection;
    public float velocity = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        projectileDirection = Vector3.Normalize(transform.position - transform.parent.position);
        projectileDirection.y = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float step = Time.deltaTime * velocity;
        transform.position += projectileDirection * step;
        transform.rotation = Quaternion.LookRotation(projectileDirection);
    }
}
