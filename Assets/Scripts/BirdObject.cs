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


    //public BirdObject(Vector3 start, Vector3 target)
    //{
    //    sourcePosition = start;
    //    targetPosition = target + (target - start) * 0.1f;
    //}
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        targetPosition.x = /*transform.position.x * */Random.Range(minX, maxX);
        targetPosition.z = /*transform.position.z * */Random.Range(minZ, maxZ);
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
