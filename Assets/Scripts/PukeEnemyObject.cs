using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PukeEnemyObject : WalkingEnemyObjectBase
{
    public GameObject pukePrefab;
    public float pukeCooldown = 10.0f;

    private float timeAfterLastPuke = 0.0f;
    public AudioClip pukeAudioClip;

    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0];
        animationController = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // base.Move();
        base.Idle();
        Puke();
    }

    void Puke()
    {
        if (timeAfterLastPuke > 0.001f)
        {
            timeAfterLastPuke -= Time.deltaTime * pukeCooldown * 0.5f;
            return;
        }

        Vector3 headOffset = new Vector3(0.0f, 1.0f, 0.0f);
        GameObject pukeProjectile = Instantiate(pukePrefab, transform.position + headOffset + (target.transform.position - transform.position) * 0.1f, transform.rotation, transform);
        Destroy(pukeProjectile, 4.0f);

        if (pukeAudioClip)
        {
            AudioSource.PlayClipAtPoint(pukeAudioClip, transform.position);
        }

        timeAfterLastPuke = pukeCooldown;
    }
}
