using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Brigde : MonoBehaviour
{
    public Clock targetObject;
    public Clock targetObject1;
    public Clock targetObject2;
    public Clock targetObject3;
    public Clock targetObject4;
    public Sprite _sprite;
    public bool _enabled = false;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = null;

    }

    // Update is called once per frame
    void Update()
    {

        if (targetObject.isCorrect && targetObject1.isCorrect && targetObject2.isCorrect && targetObject3.isCorrect && targetObject4.isCorrect)
        {
            GetComponent<SpriteRenderer>().sprite = _sprite;

        }
    }
}
