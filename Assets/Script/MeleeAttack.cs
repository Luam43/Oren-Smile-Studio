using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    
    public float attackDelay;
    public Transform weaponTransform;
    public float weaponRange;
    public int weaponDamage;
    public LayerMask enemyLayer;

    public float KBforce;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Attack());
        }
        
    }

    IEnumerator Attack()
    {

        Collider2D enemy = Physics2D.OverlapCircle(weaponTransform.position, weaponRange, enemyLayer);
        yield return new WaitForSeconds(attackDelay);
        bool facingRight = (transform.position.x < enemy.transform.position.x);
        enemy.GetComponent<EnemyHealth>().TakeDamage(weaponDamage, facingRight, KBforce);
    }
}
