using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefabs;

    [SerializeField]
    private int countEnemies;

    //walk, fly, drive
    //[SerializeField]
    //private Collider spawnAreas;

    [SerializeField]
    private Camera mainCamera;

    private List<GameObject> existingEnemys = new List<GameObject>();

    private Dictionary<string, Bounds> dictObjBounds;
    // Start is called before the first frame update
    void Start()
    {
        dictObjBounds = new Dictionary<string, Bounds>();
        foreach (var enemy in enemyPrefabs)
        {
            var enemySpawned = Instantiate(enemy, new Vector3(0, 0, 0), Quaternion.identity);
            var enemyBounds = enemySpawned.GetComponent<Collider>().bounds;
            dictObjBounds.Add(enemy.name, enemyBounds);
            Destroy(enemySpawned);
        }
        for (int i = 0; i < countEnemies; i++)
        {
            spawnEnemys(enemyPrefabs);
        }
    }

    private void spawnEnemys(GameObject[] enemys)
    {
        foreach (GameObject enemy in enemys)
        {
            bool isIntersects = false;

            //var asd = this.GameObject<NavMeshAgent>
            Collider collider = this.GetComponent<Collider>();
            Bounds bounds = collider.bounds;
            Vector3 spawnPosition;
            int i = 0;
            do
            {
                isIntersects = false;
                float x = Random.Range(bounds.min.x, bounds.max.x);
                float y = Random.Range(bounds.min.y, bounds.max.y);
                float z = Random.Range(bounds.min.z, bounds.max.z);
                if (enemy.CompareTag("EnemyWalk") || enemy.CompareTag("EnemyDrive") || enemy.CompareTag("DirtyObject"))
                {
                    y = bounds.min.y;/* + (dictObjBounds[enemy.name].size.y) / 2*/;
                }
                spawnPosition = new Vector3(x, y, z);
                Bounds boundsNew = new Bounds(spawnPosition, dictObjBounds[enemy.name].size);
                foreach (GameObject existingEnemy in existingEnemys)
                {
                    Bounds boundsExist = existingEnemy.GetComponent<Collider>().bounds;
                    boundsExist.size *= 2.5f;
                    if (boundsExist.Intersects(boundsNew))
                    {
                        isIntersects = true;
                        break;
                    }
                }
                i++;
                if (i >= 100) break;
            } while (isIntersects);
            if (!isIntersects)
            {
                GameObject inst = Instantiate(enemy, spawnPosition, Quaternion.identity);
                existingEnemys.Add(inst);
            }
        }
    }



    //private IEnumerator spawnEnemys(float interval, GameObject[] enemys)
    //{
    //    yield return new WaitForSeconds(interval);

    //    var enemy = enemys[Random.Range(0, enemys.Length - 1)];

    //    Bounds bounds = spawnArea.bounds;
    //    bool isVisible;
    //    Vector3 spawnPosition;

    //    do
    //    {
    //        float x = Random.Range(bounds.min.x, bounds.max.x);
    //        float y = Random.Range(bounds.min.y, bounds.max.y);
    //        float z = Random.Range(bounds.min.z, bounds.max.z);
    //        spawnPosition = new Vector3(x, y, z);
    //        Vector3 viewportPos = mainCamera.WorldToScreenPoint(spawnPosition);
    //        //Vector3 viewportPos = mainCamera.WorldToViewportPoint(spawnPosition);
    //        isVisible = viewportPos.z > 0 && viewportPos.x > 0 && viewportPos.x < 1 && viewportPos.y > 0 && viewportPos.y < 1;

    //    } while (isVisible);

    //    Instantiate(enemy, spawnPosition, Quaternion.identity);
    //    StartCoroutine(spawnEnemys(interval, enemys));
    //}

    // Update is called once per frame
    void Update()
    {

    }
}
