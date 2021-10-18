using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    public int offset = 15;
    int disPlayer = 0;

    Vector3 intPos = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MoveForward()
    {
        offset--;
        if(offset <= 0)
        {
            intPos = new Vector3(0, -0.1f, disPlayer);
            disPlayer++;
            this.transform.position = intPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
