using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class enemyShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    public Transform player;
    public LayerMask layerMask;

    public float fireRate;
    float nextFire;
    float distance;
    float shootingDistance = 6f;
    float chaseSpeed = 1.5f;

    audioManager audioManager;
    public int numRays = 12;
    void Awake()
    {
        audioManager = FindObjectOfType<audioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("enemy start working");
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < numRays; i++)
        {
            Debug.Log("in for loop");
            float angle = i * Mathf.PI * 2f / numRays;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)); // or new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) if you want to cast in 3D
            
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 20f, layerMask);

            Debug.Log("ray hit created");
            //Debug.DrawRay(transform.position, direction * 20f, Color.yellow);
           
                Debug.Log("ray hit condition working");
                if (hit.collider != null)
                {
                    Debug.Log("something is hitting");

                    if (hit.collider.tag == "Player")
                    {
                        Debug.Log("hit player");

                        enemyBehaviour.isMoving = false;
                        Vector3 dir = (player.position - transform.position).normalized;
                        transform.position += dir * chaseSpeed * Time.deltaTime;
                        Fire();
                        Debug.Log("firee");
                    }
                    else
                    {
                        enemyBehaviour.isMoving = true;
                        Debug.Log("12344566778");
                    }
                }
                else
                {
                    Debug.Log("collider not hit");
                }

            
            
           

            }
        

    }
    void Fire()
    {
        distance = Vector2.Distance(transform.position, player.position);
        if (Time.time > nextFire && distance <= shootingDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

            Debug.Log("bullet firing");

            Instantiate(bullet, transform.position, rotation);
            Debug.Log("bullet instantiated");
            nextFire = Time.time + fireRate;
            audioManager.PlayMySound("shoot");
        }

    }

}
