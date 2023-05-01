using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(currentTeleporter!=null) {
                transform.position = currentTeleporter.GetComponent<teleportDoors>().GetDestination().position;
                transform.rotation = currentTeleporter.GetComponent<teleportDoors>().GetDestination().rotation;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter")) {
            currentTeleporter = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter")) {
        if(collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
