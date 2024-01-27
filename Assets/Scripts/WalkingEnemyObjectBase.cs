using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingEnemyObjectBase : MonoBehaviour
{
    public NavMeshAgent agent;
    protected GameObject target;
    protected bool active = false;

    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    protected void Move()
    {
        if (!target)
        {
            target = GameObject.FindGameObjectsWithTag("Player")[0];
        }
        if (target && agent && agent.isOnNavMesh)
        {
            agent.SetDestination(target.transform.position);
        }
    }
}
