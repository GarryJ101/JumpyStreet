using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by Garrett (mostly) & Josiah

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private GameObject grassTile;
    [SerializeField] private GameObject roadTile;
    [SerializeField] private GameObject waterTile;

    int secondRand;
    int disPlayer = 12;

    Vector3 intPos = new Vector3(0, 0, 0);

    private void Update()
    {
        if (Input.GetButtonDown ("Jump"))
        {
            GenerateTerrain(Random.Range(1, 4));
        }
    }

    void GenerateTerrain(int terrain) //generates terrain, input is which terrain
    { //terrain replaces firstRand for more flexability
        if (terrain == 1)
        {
            secondRand = Random.Range(1, 6);

            for (int i = 0; i < secondRand; i++) //Determines how many chuncks for this material
            {
                intPos = new Vector3(0, 0, disPlayer);
                disPlayer += 1;
                GameObject GrassIns = Instantiate(grassTile) as GameObject;
                GrassIns.transform.position = intPos;
            }
        }
        if (terrain == 2)
        {
            secondRand = Random.Range(1, 6);

            for (int i = 0; i < secondRand; i++)
            {
                intPos = new Vector3(0, 0, disPlayer);
                disPlayer += 1;
                GameObject RoadIns = Instantiate(roadTile) as GameObject;
                RoadIns.transform.position = intPos;
            }
        }
        if (terrain == 3)
        {
            secondRand = Random.Range(1, 6);

            for (int i = 0; i < secondRand; i++)
            {
                intPos = new Vector3(0, 0, disPlayer);
                disPlayer += 1;
                GameObject WaterIns = Instantiate(waterTile) as GameObject;
                WaterIns.transform.position = intPos;
            }
        }
    }
}
