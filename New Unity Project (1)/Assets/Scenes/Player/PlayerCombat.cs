using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public float attackrange = 0.5f;
    public Transform attackPoint;

    public LayerMask enemyLayers;
    public LayerMask enemyLayersvoadores;
    public LayerMask Basilisks;
    public LayerMask Boss1Layer;
    public LayerMask Boss3Layer;
    public LayerMask Boss2Layer;
    public int attackDamage = 40;
    public int attackDamageBos = 20;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }

    void Attack()
    {
        // play attack animation
        animator.SetTrigger("Attack");
        // Detect eneies in range


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackrange, enemyLayers);
            // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }



        Collider2D[] hitEnemiesfly = Physics2D.OverlapCircleAll(attackPoint.position, attackrange, enemyLayersvoadores);
        // Damage them
        foreach (Collider2D enemyfly in hitEnemiesfly)
        {
            enemyfly.GetComponent<EnemysFlys>().TakeDamage(attackDamage);
        }



        Collider2D[] hitBak = Physics2D.OverlapCircleAll(attackPoint.position, attackrange, Basilisks);
        // Damage them
        foreach (Collider2D Bak in hitBak)
        {
            Bak.GetComponent<EnemyBak>().TakeDamage(attackDamage);
        }


        Collider2D[] hitBoss1 = Physics2D.OverlapCircleAll(attackPoint.position, attackrange, Boss1Layer);
        // Damage them
        foreach (Collider2D Boss1 in hitBoss1)
        {
            Boss1.GetComponent<Boss1>().TakeDamage(attackDamageBos);
        }

        Collider2D[] hitBoss3 = Physics2D.OverlapCircleAll(attackPoint.position, attackrange, Boss3Layer);
        // Damage them
        foreach (Collider2D Boss3 in hitBoss3)
        {
            Boss3.GetComponent<Boss3>().TakeDamage(attackDamageBos);
        }

        Collider2D[] hitBoss2 = Physics2D.OverlapCircleAll(attackPoint.position, attackrange, Boss2Layer);
        // Damage them
        foreach (Collider2D Boss2 in hitBoss2)
        {
            Boss2.GetComponent<Boss2>().TakeDamage(attackDamageBos);
        }
    }

    void OnDrawGizmosSelected()
    {
//        if (attackPoint == null)
//            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackrange);
    }
}
