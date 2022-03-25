using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isP1Goal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Ball")
        {
            if (!isP1Goal)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().P1Scored();
                
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().P2Scored();
            }
        }
    }
}
