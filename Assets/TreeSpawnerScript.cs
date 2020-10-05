using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawnerScript : MonoBehaviour
{

    public GameObject treePrefab;
    public Transform[] spawnPoints;

    public float minDelay = .1f;
    public float maxDelay = 1f;

    void Start()
    {
        StartCoroutine(SpawnTrees());
    }

    IEnumerator SpawnTrees()
    {
        while(true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject spawnedTree = Instantiate(treePrefab, spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedTree, 5f);


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
