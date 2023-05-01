using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class collectibles : MonoBehaviour
{
    audioManager audioManager;
    public int counter = 0;
    public static int total;
    void Awake()
    {
        total++;
        audioManager = FindObjectOfType<audioManager>();
    }


    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("checkingggg " + ++counter);
            audioManager.PlayMySound("collect");
            collectible_count.GetInstance().addScore(1);
            Destroy(gameObject);

        }
    }
    
    
}
