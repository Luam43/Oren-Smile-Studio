using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public Slider slider;
    private PlayerRespawn playerRespawn;

    // Start is called before the first frame update
    void Start()
    {
        
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
        playerRespawn = GameObject.Find("Player").GetComponent<PlayerRespawn>();
    }

    public void TakeDamage(int damage)
    {
        ChangeHealth(-damage);
        if (currentHealth <= 0)
        {
            playerRespawn.RespawnNow();
        }
    }

    // Method to change health
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        slider.value = currentHealth;
        Debug.Log("Health changed by " + amount + ". Current health: " + currentHealth);
    }
}