using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObject : WalkingEnemyObjectBase
{
    public float maxActiveDistance = 100.0f;
    // public Vector3 sourcePosition, targetPosition;
    // public float velocity = 10.0f;
    // public float soundCooldown = 100000.0f;
    // private float timeAfterSound = 0.0f;
    // public AudioClip engineSoundClip;

    void Start()
    {
        // transform.position = sourcePosition;
        target = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        // Move();

        // if (TargetReached())
        // {
        //     transform.position = sourcePosition;
        // }

        if (DistanceToPlayer() < maxActiveDistance)
        {
            base.Move();
        }
    }

    // void Move()
    // {
    //     float step = Time.deltaTime * velocity;
    //     transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    //     transform.rotation = Quaternion.LookRotation(targetPosition);

    //     if (engineSoundClip)
    //     {
    //         if (timeAfterSound > 0.001f)
    //         {
    //             // timeAfterSound -= Time.deltaTime * soundCooldown * 0.05f;
    //         }
    //         else
    //         {
    //             // AudioSource.PlayClipAtPoint(engineSoundClip, transform.position);
    //             timeAfterSound = soundCooldown;
    //         }
    //     }
    // }


    // bool TargetReached()
    // {
    //     // "==" is approximate equality
    //     return transform.position == targetPosition;
    // }
}
