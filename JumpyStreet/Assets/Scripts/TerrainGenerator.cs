using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by Garrett & Josiah

/// <summary>
/// Generates the terrain, selects a random chunk and instantiates it (sometimes having multiple chunks)
/// </summary>

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private GameObject grassTile;
    [SerializeField] private GameObject roadTile;
    [SerializeField] private GameObject waterTile;
    public int pathXValue; //changes the xvalue of the path for lily pads
    int disPlayer = 12;


    Vector3 intPos = new Vector3(0, 0, 0);

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GenerateTerrain(1,5);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown ("Jump"))
        {
            GenerateTerrain(Random.Range(1, 4), Random.Range(1, 6));
        }
    }

    void GenerateTerrain(int terrain, int chunks) //generates terrain, input is which terrain
    { //terrain replaces firstRand, chunks replaces secondRand for more flexability
        if (terrain == 1) //grass
        {
            pathXValue = Random.Range(-10, 11);

            for (int i = 0; i < chunks; i++) //Determines how many chuncks for this material
            {
                intPos = new Vector3(0, 0, disPlayer);
                disPlayer += 1;
                GameObject GrassIns = Instantiate(grassTile) as GameObject;
                GrassIns.transform.position = intPos;
            }
        }
        if (terrain == 2) //road
        {
            pathXValue = Random.Range(-10, 11);

            for (int i = 0; i < chunks; i++)
            {
                intPos = new Vector3(0, 0, disPlayer);
                disPlayer += 1;
                GameObject RoadIns = Instantiate(roadTile) as GameObject;
                RoadIns.transform.position = intPos;
            }
        }
        if (terrain == 3) //water
        {
            //pathXValue = Random.Range(-10, 11);

            for (int i = 0; i < chunks; i++)
            {
                intPos = new Vector3(0, 0, disPlayer);
                disPlayer += 1;
                GameObject WaterIns = Instantiate(waterTile) as GameObject;
                WaterIns.transform.position = intPos;
            }
        }
    }
}
