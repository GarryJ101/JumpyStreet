using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by Josiah

public class CarGenerator : MonoBehaviour
{
    //reference for future me: https://www.youtube.com/watch?v=E7gmylDS1C4

    //maybe after 5 seconds?

    Rigidbody rb;
    Vector2 screenBounds;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-10, 0, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        /* 
        if (transform.position.x < screenBounds.x * 2) //We might want to change this to something else?
        {
            Destroy(this.gameObject);
        }*/
    }

}
