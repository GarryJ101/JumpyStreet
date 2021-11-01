using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by Josiah

/// <summary>
/// Creates (an) obsticle(s) inside of a single chunk
/// </summary>

public class ObstacleGeneration : MonoBehaviour
{
    enum ObstacleToGenerate
    { 
        Tree,
        Lilypad,
        Car 
    }

    [SerializeField] GameObject[] obstacles; //array for multiple obstacles
    [SerializeField] float obstacleHeight = 1.25f; //height of the obstacles off the ground    
    [SerializeField] int maxMultipleAmount = 3; //the max amount of obstacles in one chunk    
    [SerializeField] ObstacleToGenerate obstacle = ObstacleToGenerate.Tree;

    bool isTree = false; //if the obstacle is a tree and needs to randomly rotate
    bool isLilyPad = false; //if the obstacles need to form a path
    bool isCar = false; //if there needs to be multiple objects in one chunk

    [HideInInspector] public bool isSingle = false;

    TerrainGenerator generator;

    float carTimer;
    float heightOffset;

    // Start is called before the first frame update
    void Start()
    {        
        generator = FindObjectOfType<TerrainGenerator>();
        heightOffset = obstacleHeight + generator.floorHeight;

        switch (obstacle)
        {
            case ObstacleToGenerate.Tree:
                isTree = true;
                break;

            case ObstacleToGenerate.Lilypad:
                isLilyPad = true;
                break;

            case ObstacleToGenerate.Car:
                isCar = true;
                break;
        }

        if (isSingle && isTree) //if a grass chunk is singlular, there won't be objects spawned
        {
            return;
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
                if (generator.lilypadStart)
                {
                    Generate(generator.pathXValue + 1);
                    Generate(generator.pathXValue - 1);
                    generator.lilypadStart = false;
                }               
            }            
        }
        if (!isLilyPad) //sets the generator's lily pad path to a random X coord
        {           
            generator.pathXValue = Random.Range(-10, 11);
            generator.lilypadStart = true;
        }
    }

    private void Update()
    {
        if (isCar)
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


    }

    void Generate(int objPos) //objPos = xPosition of the obstacle to spawn
    {       
        //print(generator.pathXValue);
        int objRange = Random.Range(0, obstacles.Length); //picks which object to spawn in the array
        GameObject ObstIns = Instantiate(obstacles[objRange]) as GameObject;
        ObstIns.transform.position = new Vector3(objPos, heightOffset, this.transform.position.z);
        ObstIns.transform.parent = transform;

        if(isTree) //randomly rotates and removes if in lily pad path
        {
            if (objPos == generator.pathXValue)
            {
                print("tree in lily pad path, removing");
                Destroy(ObstIns); //destroys if in lily pad path
            }
            ObstIns.transform.Rotate(0, 0, Random.Range(0, 180));            
        }
        if (!generator.isStart && objPos == 0)
        { //prevents objects spawning on player at start
            Destroy(ObstIns);
        }
    }

    void GenerateCars() //like generate but is at a fixed x position
    {
        isCar = true;
        int objRange = Random.Range(0, obstacles.Length); //picks which object to spawn in the array
        GameObject ObstIns = Instantiate(obstacles[objRange]) as GameObject;
        ObstIns.transform.position = new Vector3(12, heightOffset, this.transform.position.z);
    }

}
