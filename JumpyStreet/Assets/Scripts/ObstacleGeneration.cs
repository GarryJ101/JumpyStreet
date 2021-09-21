using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles; //array for multiple obstacles
    [SerializeField] float obstacleHeight = 1.25f; //height of the obstacles off the ground
    [SerializeField] bool isMultiple; //if there needs to be multiple objects in one chunk
    [SerializeField] int maxMultipleAmount = 3; //the max amount of obstacles in one chunk
    [SerializeField] bool isPath; //if the obstacles need to form a path (TODO)

    int lastObj; //the x pos of the last object

    // Start is called before the first frame update
    void Start()
    {
        if(!isMultiple)
        {
            Generate();
        }
        else
        {
            int obstAmount = Random.Range(1, maxMultipleAmount++);
            for (int i = 0; i < obstAmount; i++)
            {
                Generate();
            }
        }
        
    }

    void Generate()
    {
        int objRange = Random.Range(0, obstacles.Length);
        int objPos = Random.Range(-10, 11); //random position for the obstacle
        /*if(isPath) //if it's a path, follow the last chunk x position? (might not work)
        {
            //work in progress
            //objPos = lastObj?
        }*/
        GameObject ObstIns = Instantiate(obstacles[objRange]) as GameObject;
        ObstIns.transform.position = new Vector3(objPos, obstacleHeight, this.transform.position.z);
        lastObj = objPos;
    }
   
}
