using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private GameObject tileSpawnPointsObject;
    [SerializeField] private List<GameObject> allowedObjects;

    private List<Transform> spawnPoints;

    private void Start()
    {
        if (tileSpawnPointsObject == null) { return; }
        if (allowedObjects.Count < 1) { return; };
        foreach (Transform child in tileSpawnPointsObject.GetComponentsInChildren<Transform>())
        {
            spawnPoints.Add(child);
        }

        // !!! Change this code to be variables not static numbers !!!
        SpawnObjects(Random.Range(1, spawnPoints.Count / 2));
    }

    private void SpawnObjects(int count)
    {
        int objCounter = 0;
        while (objCounter < count)
        {
            GameObject randomObject = allowedObjects[Random.Range(0, allowedObjects.Count)];
            Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Count)];
            GameObject newObsticle = Instantiate(randomObject, randomSpot);
            newObsticle.transform.SetParent(transform);
        }
    }
}

