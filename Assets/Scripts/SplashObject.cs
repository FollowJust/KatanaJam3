using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashObject : MonoBehaviour
{
    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ParticleSystem>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<ParticleSystem>().IsAlive())
        {
            Debug.Log("destroying myself");
            Destroy(this.gameObject);
        }
    }
}
