using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;
    public int health = 100;
    public int damage = 10;

    private Transform player;
    private Animator anim;
    private bool isAttacking = false;
    private bool isDead = false;

    // Patrol variables
    public Transform[] patrolPoints;
    private int currentPatrolPointIndex;
    private bool isPatrolling = true;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();

        if (patrolPoints.Length > 0)
        {
            transform.position = patrolPoints[0].position;
            currentPatrolPointIndex = 0;
        }
    }

    void Update()
    {
        if (isDead) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && !isAttacking)
        {
            StartCoroutine(Attack());
        }
        else if (!isAttacking)
        {
            if (distanceToPlayer <= attackRange * 2)
            {
                // Stop patrolling and move towards the player
                isPatrolling = false;
                MoveTowardsPlayer();
            }
            else
            {
                // Resume patrolling
                isPatrolling = true;
                Patrol();
            }
        }

        anim.SetBool("isPatrolling", isPatrolling);
    }

    void MoveTowardsPlayer()
    {
        anim.SetBool("isMoving", true);
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        anim.SetBool("isMoving", true);
        Transform targetPatrolPoint = patrolPoints[currentPatrolPointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPatrolPoint.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPatrolPoint.position) < 0.1f)
        {
            currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        anim.SetBool("isAttacking", true);
        anim.SetBool("isMoving", false);

        // Wait for attack animation to finish
        yield return new WaitForSeconds(attackCooldown);

        // Check if the player is still in range
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            // Apply damage to the player
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }

        anim.SetBool("isAttacking", false);
        isAttacking = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        anim.SetBool("isDead", true);
        // Optionally, disable enemy behavior
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false; // Disable this script
    }
}
