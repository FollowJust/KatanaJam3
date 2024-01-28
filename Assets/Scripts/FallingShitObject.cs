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
            print("triggered");
            Vector3 position = this.transform.position;
            //Quaternion rotation = Quaternion.FromToRotation(Vector3.up, other.transform.eulerAngles);
            Destroy(gameObject);
            Instantiate(flatShitPrefab, position, Quaternion.identity);
        }
    }
}
