using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPoop : MonoBehaviour
{
    [SerializeField]
    private GameObject Poop;

    float timer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            int rnd = Random.Range(0, 100);
            if (rnd <= 10)
            {
                var position = transform.position;
                position.y -= 2;
                //position.y -= transform.localScale.y;
                Instantiate(Poop, position, Quaternion.identity);
            }
            timer = 0.5f;
        }
    }
}
