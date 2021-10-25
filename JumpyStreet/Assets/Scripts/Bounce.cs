using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    float lerpTime;
    float currentLerpTime;

    float perc = 1;
    Vector3 startPos;
    Vector3 endPos;
    public int offset; //offset when the player goes backwards
    [SerializeField] LayerMask layerMask;

    bool firstInput;
    public bool justJump;
    public static bool isPlaying;

    TerrainGenerator generator;
    UIController ui;
    BarrierController barrier;

    private void Start()
    {
        generator = FindObjectOfType<TerrainGenerator>();
        ui = FindObjectOfType<UIController>();
        barrier = FindObjectOfType<BarrierController>();
    }

    void Update()
    {
        RaycastHit hit;

        if (!isPlaying)
        {
            justJump = false;
            return;
        }
        if(Input.GetButtonDown("up") || Input.GetButtonDown("down") || Input.GetButtonDown("left") || Input.GetButtonDown("right"))
        {
            if(perc == 1)
            {
                lerpTime = 1;
                currentLerpTime = 0;
                firstInput = true;
                justJump = true;
            }
            if (!generator.isStart)
            {
                generator.isStart = true;
            }
        }
        startPos = gameObject.transform.position;

        if(Input.GetButtonDown("right") && gameObject.transform.position == endPos)
        {
            //if player is next to an object
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1f, layerMask))
            {               
                Debug.Log("Hit on right");
            }
            else
            {            
                endPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            }           
        }
        if (Input.GetButtonDown("left") && gameObject.transform.position == endPos)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 1f, layerMask))
            {              
                Debug.Log("Hit on left");
            }
            else
            {
                endPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            }            
        }
        if (Input.GetButtonDown("up") && gameObject.transform.position == endPos)
        {
            //if player is in front of an obstacle
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1f, layerMask))
            {              
                Debug.Log("Hit in front");
            }
            else //if player is not in front of an obstacle
            {
                endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                if (offset == 0) //new progress
                {
                    generator.GenerateTerrain(Random.Range(1, 4), Random.Range(1, 6));
                    generator.terrainOffset--;
                    ui.ScorePoints();
                    barrier.MoveForward();
                }
                else //removes offset
                {
                    offset--;
                }
            }
        }
        if (Input.GetButtonDown("down") && gameObject.transform.position == endPos)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 1f, layerMask))
            {                
                Debug.Log("Hit in back");
            }
            else
            {
                endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                offset++;
                barrier.offset++;
            }
            
        }
        if(firstInput == true)
        {
            currentLerpTime += Time.deltaTime * 5;
            perc = currentLerpTime / lerpTime;
            gameObject.transform.position = Vector3.Lerp(startPos, endPos, perc);
            if(perc > 0.8f)
            {
                perc = 1;
            }
            if (Mathf.Round(perc) == 1)
            {
                justJump = false;

                
            }
        }

        //This draws the rays in the editor
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1f, layerMask))
        {//forward
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 1f, layerMask))
        {//left
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 1000, Color.white);
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1f, layerMask))
        {//right
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.white);
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 1f, layerMask))
        {//back
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * 1000, Color.white);
        }
    }
}
