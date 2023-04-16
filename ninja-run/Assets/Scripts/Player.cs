using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce = 12f;
    public float jumpForce = 12f;
    private float movementX;
    private float movementY;
    public bool isFacingRight = true;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private bool isGrounded = true;
    private string ENEMY_TAG = "Enemy";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
       // Flip();
        AnimatePlayer();
        

    }
    private void FixedUpdate()
    {
        PlayerJump();
    }
    void PlayerMovement()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
       
       
       
       
    }
    private void AnimatePlayer()
    {
        if (movementX > 0) {
            animator.SetBool("isMove", true);
            spriteRenderer.flipX = true;
        }
        else if(movementX < 0)
        {
            animator.SetBool("isMove", true);
            spriteRenderer.flipX = false;
        }
        else
        {
            animator.SetBool("isMove", false);
            spriteRenderer.flipX = false;
        }
    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump")  || Input.GetMouseButtonDown(0))
        {
            if (isGrounded)
            {
                isGrounded = false;
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                animator.SetBool("isJump", true);
            }
        }
        else
        {
            animator.SetBool("isJump", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

}
   
