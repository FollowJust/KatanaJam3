using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObject : MonoBehaviour
{
    public Vector3 sourcePosition, targetPosition;
    public float velocity = 10.0f;
    public float soundCooldown = 100000.0f;
    private float timeAfterSound = 0.0f;
    public AudioClip engineSoundClip;

    public CarObject(Vector3 start, Vector3 target)
    {
        sourcePosition = start;
        targetPosition = target + (target - start) * 0.1f; 
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
            transform.position = sourcePosition;
        }
    }

    void Move()
    {
        float step = Time.deltaTime * velocity;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        transform.rotation = Quaternion.LookRotation(targetPosition);

        if (engineSoundClip)
        {
            if (timeAfterSound > 0.001f)
            {
                // timeAfterSound -= Time.deltaTime * soundCooldown * 0.05f;
            }
            else
            {
                // AudioSource.PlayClipAtPoint(engineSoundClip, transform.position);
                timeAfterSound = soundCooldown;
            }
        }
    }


    bool TargetReached()
    {
        // "==" is approximate equality
        return transform.position == targetPosition;
    }
}
