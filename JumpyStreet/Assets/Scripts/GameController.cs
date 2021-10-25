using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public GameObject deathScreen;
    [SerializeField] LayerMask layerMask;
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
        RaycastHit hit;
        //casts a ray down
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            Debug.Log(hit.transform.gameObject.tag);
            if(hit.transform.gameObject.CompareTag("Death")) //if player hits water or car
            {
                Bounce.isPlaying = false;
                ui.DisplayGameOver();
            }
        }
    }
}
