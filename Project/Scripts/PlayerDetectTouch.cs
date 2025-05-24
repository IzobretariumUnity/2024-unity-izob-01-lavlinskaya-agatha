using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (other.gameObject.CompareTag("LoadNextLevel"))
        {
            SceneManager.LoadScene("Circle Move 2");
        }

        if (other.gameObject.CompareTag("LoadNextLevel2"))
        {
            SceneManager.LoadScene("Circle Move 3");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Damage"))
        {
            playerHealth.Damage();
            Destroy(other.gameObject);
        }

    }

}




