using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ruin : MonoBehaviour
{
    public GameObject targetObject;
    public Sprite _sprite;
    public bool _enabled = false;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = null;

    }

    // Update is called once per frame
    void Update()
    {
        _enabled = targetObject.gameObject.activeSelf; 
        if (!targetObject.gameObject.activeSelf)
        {
            GetComponent<SpriteRenderer>().sprite = _sprite;

        }
    }
}
