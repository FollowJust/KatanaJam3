using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomelessEnemyObject : WalkingEnemyObjectBase
{
    public float maxActiveDistance = 10.0f;

    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0];
        animationController = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (DistanceToPlayer() < maxActiveDistance)
        {
            Debug.Log("Move fucker");
            base.Move();
        }
        else
        {
            base.Idle();
        }
    }
}
