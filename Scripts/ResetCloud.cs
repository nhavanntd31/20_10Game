using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCloud : MonoBehaviour
{
    private RespawnCloud[] clouds;

    private void Start()
    {
        // Find all objects with the RespawnCloud script and store them in the clouds array
        clouds = FindObjectsOfType<RespawnCloud>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var c in clouds)
        {
            c.GetComponent<BoxCollider2D>().enabled = true;
        }
        Debug.Log("Reset");
    }
}
