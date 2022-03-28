using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAiDefault : MonoBehaviour
{
    public float ball_pos;

    public float speed;
    public float correctInputUp;
    public float correctInputDown;


    private void Start()
    {
        speed = GameObject.Find("Ball").GetComponent<Ball>().currentSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        ball_pos = GameObject.Find("Ball").transform.position.y;
        speed = GameObject.Find("Ball").GetComponent<Ball>().currentSpeed;

        if (transform.position.y < ball_pos)
        {
            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        }

        else if (transform.position.y > ball_pos)
        {
            transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
        }

    }
}
