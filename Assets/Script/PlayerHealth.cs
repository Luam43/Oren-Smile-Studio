using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public Slider slider;
    private PlayerRespawn playerRespawn;
    public int currentHealth;
    public int maxHealth;




    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
        playerRespawn = GameObject.Find("Player").GetComponent<PlayerRespawn>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        slider.value = health;

        if (health <= 0)
        {
            playerRespawn.RespawnNow();
        }
    }
    // Method to change health
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Health changed by " + amount + ". Current health: " + currentHealth);
    }
}