using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAiNeural : MonoBehaviour
{

    public float ball_pos;




    // Update is called once per frame
    void Update()
    {
        ball_pos = GameObject.Find("Ball").transform.position.y;

        if(transform.position.y < ball_pos)
        {
            transform.position += new Vector3(0f, 5 * 1 * Time.deltaTime, 0f);
        }

        else if (transform.position.y > ball_pos)
        {
            transform.position -= new Vector3(0f,5 * 1 * Time.deltaTime , 0f);
        }

    }
}
