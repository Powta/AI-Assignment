//References
//1. https://www.youtube.com/watch?v=YHSanceczXY
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRb;
    private float movement;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = GameObject.Find("Ball").GetComponent<Ball>().currentSpeed;
        movement = Input.GetAxisRaw("Vertical");
        myRb.velocity = new Vector2(myRb.velocity.x, movement * speed);
    }
}
