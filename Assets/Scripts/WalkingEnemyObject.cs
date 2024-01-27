using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingEnemyObject : MonoBehaviour
{
    public GameObject target;
    protected bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
        }
    }
}
