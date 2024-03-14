using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCloud : MonoBehaviour
{
    [SerializeField] public GameObject Cloud;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BoxCollider2D res = Cloud.GetComponent<BoxCollider2D>();
            if (res != null) { 
                res.enabled = false;
                Debug.Log("Ok");
            }
            else Debug.Log("fail to get");
        }
    }
}