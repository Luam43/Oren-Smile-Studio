using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    public Slider slider;
    private PlayerRespawn playerRespawn;


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
        
        if(health <= 0)
        {
            playerRespawn.RespawnNow();
        }
    }
}