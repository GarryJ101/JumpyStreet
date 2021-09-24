using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by Josiah

/// <summary>
/// Creates (an) obsticle(s) inside of a single chunk
/// </summary>
public class ObstacleGeneration : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles; //array for multiple obstacles
    [SerializeField] float obstacleHeight = 1.25f; //height of the obstacles off the ground
    [SerializeField] bool isMultiple; //if there needs to be multiple objects in one chunk
    [SerializeField] int maxMultipleAmount = 3; //the max amount of obstacles in one chunk
    [SerializeField] bool isRotating = false; //if the obstacle randomly rotates
    [SerializeField] bool isLilyPad; //if the obstacles need to form a path (TODO)

    TerrainGenerator generator;

    // Start is called before the first frame update
    void Start()
    {
        if(!isMultiple)
        {
            GenerateCars();
        }
        else
        {   //random size of how many obstacles in one chunk
            int obstAmount = Random.Range(1, maxMultipleAmount++); 
            for (int i = 0; i < obstAmount; i++)
            {
                Generate(Random.Range(-10, 11));
            }
            if(isLilyPad)
            {
                generator = FindObjectOfType<TerrainGenerator>();
                Generate(generator.pathXValue);
                //Generate(0);
            }
        }
        
    }

    private void Update()
    {
        if (!isMultiple)
        {
            //generates cars at random times
        }
    }

    void Generate(int objPos) //objPos = xPosition of the obstacle to spawn
    {
        int objRange = Random.Range(0, obstacles.Length); //picks which object to spawn in the array
        GameObject ObstIns = Instantiate(obstacles[objRange]) as GameObject;
        ObstIns.transform.position = new Vector3(objPos, obstacleHeight, this.transform.position.z);
        if(isRotating) //randomly rotates if it needs to (mostly for trees)
        {
            ObstIns.transform.Rotate(0, 0, Random.Range(0, 180));
        }
    }

    void GenerateCars() //like generate but simpler
    {
        int objRange = Random.Range(0, obstacles.Length); //picks which object to spawn in the array
        GameObject ObstIns = Instantiate(obstacles[objRange]) as GameObject;
        ObstIns.transform.position = new Vector3(10, obstacleHeight, this.transform.position.z);
    }
   
}
