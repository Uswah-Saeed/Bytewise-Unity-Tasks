using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monstor : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    [SerializeField]
    private Rigidbody2D rb;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }









}
