using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BirdObject : MonoBehaviour
{
    [SerializeField]
    private float minX = 450, minZ = 450, maxX = 600, maxZ = 700;
    private Vector3 targetPosition;
    [SerializeField]
    private float velocity = 10.0f;
    private float interval;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        targetPosition.x = Random.Range(minX, maxX);
        targetPosition.z = Random.Range(minZ, maxZ);
        interval = Random.Range(0, 100);
        timer = interval;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (TargetReached())
        {
            targetPosition = transform.position;
            targetPosition.x = Random.Range(minX, maxX);
            targetPosition.z = Random.Range(minZ, maxZ);
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            var temp = Random.Range(0, 250);
            if (temp == 7)
            {
                var soundsArray = GetComponents<AudioSource>();
                var rnd = Random.Range(0, soundsArray.Length - 1);
                soundsArray[rnd].volume = 0.005f;
                soundsArray[rnd].priority = 20;
                soundsArray[rnd].maxDistance = 40;
                var clip = soundsArray[rnd].clip;

                AudioSource.PlayClipAtPoint(soundsArray[rnd].clip, transform.position);
                soundsArray[rnd].Play();
            }
        }
    }
    void Move()
    {
        float step = Time.deltaTime * velocity;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }


    bool TargetReached()
    {
        // "==" is approximate equality
        return transform.position == targetPosition;
    }
}
