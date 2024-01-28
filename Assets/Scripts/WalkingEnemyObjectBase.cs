using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingEnemyObjectBase : MonoBehaviour
{
    public NavMeshAgent agent;
    protected GameObject target;
    protected bool active = false;

    protected Animator animationController;

    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0];
        animationController = GetComponentInChildren<Animator>();
    }

    protected void Move()
    {
        if (!target)
        {
            target = GameObject.FindGameObjectsWithTag("Player")[0];
        }
        if (target && agent && agent.isOnNavMesh)
        {
            if (animationController)
            {
                animationController.Play("Run");
            }

            agent.SetDestination(target.transform.position);
        }
    }

    protected void Idle()
    {
        if (animationController)
        {
            animationController.Play("Idle");
        }
    }

    protected float DistanceToPlayer()
    {
        if (!target)
        {
            // Some ridiculously enermous value to fail proximity checks
            return 112313212.0f;
        }

        return Vector3.Distance(transform.position, target.transform.position);
    }
}
