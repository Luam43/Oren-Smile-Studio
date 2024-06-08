using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 1;
    public Rigidbody2D enemyRb;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int amount, bool facingRight, float KBforce)
    {
        if (facingRight)
        {
            enemyRb.AddForce(Vector2.right * KBforce, ForceMode2D.Impulse);
        }
        else
        {
            enemyRb.AddForce(Vector2.left * KBforce, ForceMode2D.Impulse);
        }

        enemyHealth -= amount;
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
