using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomelessEnemyObject : WalkingEnemyObjectBase
{
    void Start()
    {
        animationController = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Maybe add stamina for him?
        base.Move();
        //base.Idle();
    }
}
