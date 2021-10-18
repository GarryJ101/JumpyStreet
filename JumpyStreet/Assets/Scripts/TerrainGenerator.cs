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
    public float floorHeight = -0.85f; //the height offset for the floor
    public int pathXValue; //changes the xvalue of the path for lily pads
    int disPlayer = 0; //tiles chunks right after the first
    public int terrainOffset = 0; //so that it only generates when player is actually close

    Vector3 intPos = new Vector3(0, 0, 0); //position of the chunk to generate
    public bool isStart = false; //if player pressed a button yet

    public GameController playerController; //made here so that it's only called once

    private void Start()
    {
        playerController = FindObjectOfType<GameController>();
        GenerateTerrain(1, 5);     
    }
    //input moved to Bounce
    public void GenerateTerrain(int terrain, int chunks) //generates terrain, input is which terrain
    { //terrain replaces firstRand, chunks replaces secondRand for more flexibility
        if (terrain == 1) //grass
        {
            for (int i = 0; i < chunks; i++) //Determines how many chuncks for this material
            {
                intPos = new Vector3(0, floorHeight, disPlayer);
                disPlayer += 1;
                GameObject GrassIns = Instantiate(grassTile) as GameObject;
                GrassIns.transform.position = intPos;
                terrainOffset++;
            }
            pathXValue = Random.Range(-10, 11);
        }
        if (terrain == 2) //road
        {           
            for (int i = 0; i < chunks; i++)
            {
                intPos = new Vector3(0, floorHeight, disPlayer);
                disPlayer += 1;
                GameObject RoadIns = Instantiate(roadTile) as GameObject;
                RoadIns.transform.position = intPos;
                terrainOffset++;
            }
            pathXValue = Random.Range(-10, 11);
        }
        if (terrain == 3) //water
        {
            //pathXValue = Random.Range(-10, 11);

            for (int i = 0; i < chunks; i++)
            {
                intPos = new Vector3(0, floorHeight - 0.15f, disPlayer);
                disPlayer += 1;
                GameObject WaterIns = Instantiate(waterTile) as GameObject;
                WaterIns.transform.position = intPos;
                terrainOffset++;
            }
        }
        //print("Terrain offset: " + terrainOffset);
    }
}
