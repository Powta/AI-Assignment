//References
//1. https://www.youtube.com/watch?v=YHSanceczXY
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRb;
    public Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        myRb.velocity = new Vector2(speed * x, speed * y);

    }

    public void Reset()
    {
        myRb.velocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Paddle")
        {
            myRb.velocity = new Vector2(myRb.velocity.x * 1.1f, myRb.velocity.y * 1.1f);
        }
    }
}
