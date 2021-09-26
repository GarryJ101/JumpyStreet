using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by Josiah

/// <summary>
/// Moves the attached object from right to left and destroys itself after [secondsAlive] seconds
/// </summary>

public class CarGenerator : MonoBehaviour
{
    //reference for future me: https://www.youtube.com/watch?v=E7gmylDS1C4

    [SerializeField] int secondsAlive; //time limit before the object gets destroyed
    [SerializeField] int startingVelocity = -10; //speed of the object at the start

    Rigidbody rb;
    Vector2 screenBounds;
    float timer;


    // Start is called before the first frame update
    void Start()
    {
        int speed = startingVelocity + Random.Range(-2, 2); //adds some slight variation to the startingVelocity
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(speed, 0, 0);

        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //gets screen bounds
    }

    // Update is called once per frame
    void Update()
    {
        /* 
        if (transform.position.x < screenBounds.x * 2)
        {
            Destroy(this.gameObject); //destroy if out of screen bounds
        }*/
        //This doesn't work, leaving up in case we want to do something with it


        timer += Time.deltaTime;
        if (timer >= 1f) //happens every second
        {
            timer = timer % 1f;
            secondsAlive--;
            if(secondsAlive == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
