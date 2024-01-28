using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitObject : MonoBehaviour
{

    [SerializeField]
    private GameObject flatShitPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name != "ColliderFly" && this.transform.position.y <= 1.5f)
        {
            var soundsArray = GetComponents<AudioSource>();
            var rnd = Random.Range(0, soundsArray.Length - 1);
            soundsArray[rnd].maxDistance = 5;
            var clip = soundsArray[rnd].clip;

            AudioSource.PlayClipAtPoint(clip, transform.position);

            Vector3 position = this.transform.position;
            //Quaternion rotation = Quaternion.FromToRotation(Vector3.up, other.transform.eulerAngles);
            Destroy(gameObject);
            Instantiate(flatShitPrefab, position, Quaternion.identity);
        }
    }
}
