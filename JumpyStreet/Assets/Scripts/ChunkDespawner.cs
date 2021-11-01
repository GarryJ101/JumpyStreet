using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkDespawner : MonoBehaviour
{
    [SerializeField] GameObject parent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Despawn")
        {
            Destroy(parent.gameObject);
            //print("Destroyed:" + this.gameObject.name);
        }
    }

}
