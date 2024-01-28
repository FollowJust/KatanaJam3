using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleObject : MonoBehaviour
{
    public GameObject splashPrefab;
    public AudioClip splashAudioClip;
    private GameObject splashGameObject;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter Puddle");
        if (other.gameObject.GetComponent<CarObject>())
        {
            Debug.Log("Car on Puddle");
            Vector3 randomSplashDirection = new Vector3(Random.Range(0.0f, 1.0f), 0.0f, Random.Range(0.0f, 1.0f));
            randomSplashDirection = randomSplashDirection * other.transform.position.magnitude * 0.4f;
            randomSplashDirection += other.transform.position;
            randomSplashDirection.y = 0;
            splashGameObject = Instantiate(splashPrefab, randomSplashDirection, transform.rotation, transform);
            if (splashAudioClip)
            {
                AudioSource.PlayClipAtPoint(splashAudioClip, randomSplashDirection);
            }
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
