using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Statue : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject targetObject1;
    public GameObject targetObject2;
    public GameObject targetObject3;
    public Sprite _sprite;
    public bool _enabled = false;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = null;
        GetComponent<SpecialFlower>().enabled = false;


    }

    // Update is called once per frame
    void Update()
    {

        if (!targetObject.gameObject.activeSelf && !targetObject1.gameObject.activeSelf && !targetObject2.gameObject.activeSelf && !targetObject3.gameObject.activeSelf)
        {
            GetComponent<SpriteRenderer>().sprite = _sprite;
            GetComponent<SpecialFlower>().enabled = true;

        }
    }
}
