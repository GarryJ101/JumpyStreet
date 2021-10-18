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
    [SerializeField] bool isLilyPad; //if the obstacles need to form a path
    //Future me: have a limit that destroys this gameobject when the player goes to far, have a limit, to save on resources
    [SerializeField] int lifespan = 30; //this sets how many chunks the player moves away until this chunk dissapears
    TerrainGenerator generator;
    float carTimer;
    float heightOffset;
    Bounce controller;

    // Start is called before the first frame update
    void Start()
    {
        generator = FindObjectOfType<TerrainGenerator>();
        controller = FindObjectOfType<Bounce>();
        heightOffset = obstacleHeight + generator.floorHeight;

        if (!isMultiple)
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
                Generate(generator.pathXValue);
            }
        }


    }

    private void Update()
    {
        if (!isMultiple)
        {
            carTimer += Time.deltaTime;
            if (carTimer >= 1f) //happens every second
            {
                carTimer = carTimer % 1f;
                int spawnChance = Random.Range(0, 4); //1/4 chance to spawn object again
                if(spawnChance == 0)
                {
                    GenerateCars();
                }
            }
        }

        /*if (Input.GetButtonDown("up") && controller.offset == 0) //TODO
        {
            DeteriorateLifespan();
            print("aaa");
        }*/
    }

    void Generate(int objPos) //objPos = xPosition of the obstacle to spawn
    {        
        int objRange = Random.Range(0, obstacles.Length); //picks which object to spawn in the array
        GameObject ObstIns = Instantiate(obstacles[objRange]) as GameObject;
        ObstIns.transform.position = new Vector3(objPos, heightOffset, this.transform.position.z);
        //ObstIns.transform.SetParent(transform, true);
        //Vector3 scale = ObstIns.transform.localScale;
        ObstIns.transform.parent = transform;
        //ObstIns.transform.localScale = scale;
        if(isRotating) //randomly rotates if it needs to (mostly for trees)
        {
            ObstIns.transform.Rotate(0, 0, Random.Range(0, 180));
            if (objPos == generator.pathXValue) //i mean this IS exclusive to trees
            {
                print("tree in lily pad path, removing"); //not working
                Destroy(ObstIns); //destroys if in lilly pad path
            }
        }
        if (generator.isStart && objPos == generator.playerController.gameObject.transform.position.x)
        { //prevents objects spawning on player at start
            Destroy(ObstIns);
        }
    }

    void GenerateCars() //like generate but is at a fixed x position
    {
        int objRange = Random.Range(0, obstacles.Length); //picks which object to spawn in the array
        GameObject ObstIns = Instantiate(obstacles[objRange]) as GameObject;
        ObstIns.transform.position = new Vector3(12, heightOffset, this.transform.position.z);
    }
   
    void DeteriorateLifespan() //lowers lifespan and destroys GO if dead (not to its own objects tho)
    {
        if(lifespan >= 1)
        {
            lifespan--;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
