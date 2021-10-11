using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public GameObject deathScreen;
    UIController ui;
    // Start is called before the first frame update
    void Start()
    {
        Bounce.isPlaying = true;

        ui = FindObjectOfType<UIController>();
        Bounce.FindObjectOfType<Bounce>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Death"))
        {
            Bounce.isPlaying = false;
            
            ui.DisplayGameOver();
            
        }
    }
}
