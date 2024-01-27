using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonComponent : MonoBehaviour
{
    public GameObject shitPrefab;
    private bool hasShitted = false;

    void Start()
    {
    }

    void Update()
    {
        if (Time.time > 5.0f && !hasShitted)
        {
            Shit();
            hasShitted = true;

            print("Pigeon has shitted");
        }
    }

    public void Shit()
    {
        if (shitPrefab != null) 
        {
            Instantiate(shitPrefab, transform.position + new Vector3(0.0f, -1.0f, 0.0f), new Quaternion());
        }
    }
}
