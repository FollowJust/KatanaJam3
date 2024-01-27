using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleObject : MonoBehaviour
{
    public GameObject splashPrefab;
    private GameObject splashGameObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CarObject>())
        {
            Debug.Log("BIG SPLASH!");
            splashGameObject = Instantiate(splashPrefab, other.transform.position, other.transform.rotation);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (splashGameObject)
        {
            Destroy(splashGameObject);
            splashGameObject = null;
        }
    }
}
