using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorOpen : MonoBehaviour
{
    public GameObject closeDoor;
    public static bool win = false;
    public GameObject openDoor;
   

    private void Start()
    {
        openDoor.SetActive(false);
    }

    void LateUpdate()
    {
        open();
    }
    void open()
    {
        if (win)
        {
            openDoor.GetComponent<Renderer>().material.color = new Color(0, 204, 0);
            openDoor.SetActive(true);
            closeDoor.SetActive(false);
            
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);
        }
    }
    
}
