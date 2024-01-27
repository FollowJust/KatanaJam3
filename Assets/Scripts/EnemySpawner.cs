using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefabs;

    [SerializeField]
    private float spawnInterval;

    public Collider spawnArea;

    public Camera mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemys(spawnInterval, enemyPrefabs));
    }

    private IEnumerator spawnEnemys(float interval, GameObject[] enemys)
    {
        var enemy = enemys[Random.Range(0, enemys.Length-1)];
        yield return new WaitForSeconds(interval);

        Bounds bounds = spawnArea.bounds;
        bool isVisible;
        Vector3 spawnPosition;

        do
        {
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);
            float z = Random.Range(bounds.min.z, bounds.max.z);
            spawnPosition = new Vector3(x, y, z);

            Vector3 viewportPos = mainCamera.WorldToViewportPoint(spawnPosition);
            isVisible = viewportPos.z > 0 && viewportPos.x > 0 && viewportPos.x < 1 && viewportPos.y > 0 && viewportPos.y < 1;

        } while (isVisible);

        Instantiate(enemy, spawnPosition, Quaternion.identity);
        StartCoroutine(spawnEnemys(interval, enemys));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
