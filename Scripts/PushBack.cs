using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBack : MonoBehaviour
{
    public Vector3 movePlayer;
    public Clock clock1;
    public Clock clock2;
    public Clock clock3;
    public Clock clock4;
    public Clock clock5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (clock1.isCorrect &&  clock2.isCorrect && clock3.isCorrect && clock4.isCorrect && clock5.isCorrect) {
            } else
            other.transform.position += movePlayer;
        }
    }
}
