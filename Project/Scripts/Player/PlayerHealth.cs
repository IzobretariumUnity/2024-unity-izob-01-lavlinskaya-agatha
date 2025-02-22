using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;

    private int currentHealth;

    private PlayerHealthUI healthUI;

    private void Start()
    {
        currentHealth = maxHealth;

        healthUI = GetComponent<PlayerHealthUI>();
        healthUI.Init(maxHealth, currentHealth);
    }

    public void Damage()
    {
        ChangeHealth(false);
    }

    public void PullUp()
    {
        ChangeHealth(true);
    }

    private void ChangeHealth(bool isPullUp)
    {
        if(isPullUp)
        {
            currentHealth += 1;
        }
        else
        {
            currentHealth -= 1;
        }

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthUI.UpdateUI(currentHealth);

        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
