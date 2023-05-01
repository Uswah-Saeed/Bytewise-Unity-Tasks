using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public float speed;
    public Transform[] locationPoints;
    public Rigidbody2D rb;


    private int randomPoints;
    private float waitTime;
    public float startWaitTime;
    public static bool isMoving = true;
   


    void Start()
    {
        waitTime = startWaitTime;
        randomPoints = Random.Range(0, locationPoints.Length);
  

    }
    void Update()
    {
        enemyMove();

    
    }
    private void enemyMove()
    {
        if (isMoving) {
            transform.position = Vector2.MoveTowards(transform.position, locationPoints[randomPoints].position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, locationPoints[randomPoints].position) < 0.1f)
            {
                if (waitTime <= 0)
                {
                    randomPoints = Random.Range(0, locationPoints.Length);
                    waitTime = startWaitTime;
                }

                else
                {
                    waitTime -= Time.deltaTime;
                }

            }


        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
