using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myChar;
    // Start is called before the first frame update
    private Animator myAnim;
    public GameObject isInteractive;
    public GameObject isInteractive1;
    [SerializeField]
    private float speed;
    void Start()
    {
        myChar = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteractive.activeSelf || isInteractive1.activeSelf)
        {
            Stop();
            return;
        }
        myChar.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.deltaTime;
        myAnim.SetFloat("moveX", myChar.velocity.x);
        myAnim.SetFloat("moveY", myChar.velocity.y);
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("lastX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastY", Input.GetAxisRaw("Vertical"));

        }

    }
    public void Respawn()
    {
        myChar.velocity = Vector3.zero;
        myAnim.SetFloat("moveX", myChar.velocity.x);
        myAnim.SetFloat("moveY", myChar.velocity.y);
        myAnim.SetFloat("lastX", Input.GetAxisRaw("Horizontal"));
        myAnim.SetFloat("lastY", Input.GetAxisRaw("Vertical"));
    }
    public void Stop()
    {
        myChar.velocity = Vector3.zero;
        myAnim.SetFloat("moveX", myChar.velocity.x);
        myAnim.SetFloat("moveY", myChar.velocity.y);
        myAnim.SetFloat("lastX", 0.1f);
        myAnim.SetFloat("lastY", -0.1f);
    }

}
