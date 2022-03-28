//References
//1. https://www.youtube.com/watch?v=YHSanceczXY
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Player 1")]
    public GameObject p1Paddle;
    public GameObject p1Goal;

    [Header("Player 2")]
    public GameObject p2Paddle;
    public GameObject p2Goal;

    [Header("Score UI")]
    public GameObject p1Text;
    public GameObject p2Text;

    private float p1Score;
    private float p2Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void P1Scored()
    {
        p1Score++;
        p1Text.GetComponent<Text>().text = p1Score.ToString();
        ball.GetComponent<Ball>().Reset();
    }
    public void P2Scored()
    {
        p2Score++;
        p2Text.GetComponent<Text>().text = p2Score.ToString();
        ball.GetComponent<Ball>().Reset();
    }
}
