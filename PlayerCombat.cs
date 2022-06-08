using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerCombat : MonoBehaviour
{
    PhotonView view;
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;


    void Start()
    {
        view = GetComponent<PhotonView>();
    }



    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {

            if (Time.time >= nextAttackTime)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
            void Attack()
            {
                animator.SetTrigger("Attack");

                Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

                foreach (Collider enemy in hitEnemies)
                {
                    enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                }
            }

            void OnDrawGizmosSelected()
            {
                if (attackPoint == null)
                    return;

                Gizmos.DrawWireSphere(attackPoint.position, attackRange);
            }
        }
    }
       
}
