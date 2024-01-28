using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PukeEnemyObject : WalkingEnemyObjectBase
{
    public GameObject pukePrefab;
    public float pukeCooldown = 10.0f;

    private float timeAfterLastPuke = 0.0f;

    void Start()
    {
        animationController = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // base.Move();
        base.Idle();
        // Puke();
    }

    void Puke()
    {
        if (timeAfterLastPuke > 0.001f)
        {
            timeAfterLastPuke -= Time.deltaTime * pukeCooldown;
            return;
        }

        GameObject pukeProjectile = Instantiate(pukePrefab, transform.position + (target.transform.position - transform.position) * 0.1f, transform.rotation, transform);
        Destroy(pukeProjectile, 2.0f);

        timeAfterLastPuke = pukeCooldown;
    }
}
