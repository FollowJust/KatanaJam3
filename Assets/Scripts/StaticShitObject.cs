using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticShitObject : MonoBehaviour
{
    private float timer = 15.0f
        ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }        
    }
}
