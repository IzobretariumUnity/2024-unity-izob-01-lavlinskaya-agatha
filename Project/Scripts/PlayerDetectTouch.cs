using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerDetectTouch : MonoBehaviour
{
    private PlayerHealth playerHealth;


    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PullUp"))
        {
            playerHealth.PullUp();
            Destroy(other.gameObject);
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TriggerExample"))
        {
            Debug.Log("Trigger Exit");
        }

    }
    */

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Damage"))
        {
            playerHealth.Damage();
            Destroy(other.gameObject);
        }

    }

}




