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
    public int offset; //offset if the player goes backwards

    bool firstInput;
    public bool justJump;
    public static bool isPlaying;

    TerrainGenerator generator;
    UIController ui;

    private void Start()
    {
        generator = FindObjectOfType<TerrainGenerator>();
        ui = FindObjectOfType<UIController>();
    }

    void Update()
    {
        if(!isPlaying)
        {
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
            endPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
        if (Input.GetButtonDown("left") && gameObject.transform.position == endPos)
        {
            endPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }
        if (Input.GetButtonDown("up") && gameObject.transform.position == endPos)
        {
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);

            if (offset == 0)
            {
                if (generator.terrainOffset < 30) //generates only if there are less than 30 chunks ahead
                {
                   generator.GenerateTerrain(Random.Range(1, 4), Random.Range(1, 6));
                }
                generator.terrainOffset--;
                ui.ScorePoints();
            }
            else
            {
                offset--;
            }
        }
        if (Input.GetButtonDown("down") && gameObject.transform.position == endPos)
        {
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            offset++;
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
        
    }
}
