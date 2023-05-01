using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem particleSystem = default;

    public static float fill = 5f;
    public healthController health;

    private float movementX;
    private float movementY;

    public float moveForce = 12f;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem.Stop();

    Debug.Log("player alive");
    }

    // Update is called once per frame
    void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(movementX, movementY, 0f) * Time.deltaTime * moveForce;
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Debug.Log("collisionn");
            health.SetHealth(fill);
            fill -= 1f;
            particleSystem.Play();
        }
    }
}
