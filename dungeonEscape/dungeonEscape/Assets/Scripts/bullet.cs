using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float moveSpeed = 10f;
    Rigidbody2D rb;

    playerMovement target;
    Vector2 moveDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<playerMovement>();
        moveDirection = (target.transform.position - transform.position);
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        
        float rot = Mathf.Atan2(-moveDirection.y, -moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 270);
Destroy(gameObject, 2f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("bullet hit player");


        }
    }
    
}
