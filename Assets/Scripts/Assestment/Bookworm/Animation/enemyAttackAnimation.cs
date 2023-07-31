using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttackAnimation : MonoBehaviour
{
    private Animator anim;

    private void OnEnable()
    {
        playerBookWormHealth.onEnemyAttack += attackAnimation;
        playerBookWormHealth.onEnemyAttack += enemyIdleAnimation;
    }
    private void OnDisable()
    {
        playerBookWormHealth.onEnemyAttack -= attackAnimation;
        playerBookWormHealth.onEnemyAttack -= enemyIdleAnimation;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void attackAnimation()
    {
        anim.SetTrigger("attack");
    }
    public void enemyIdleAnimation()
    {
        anim.SetTrigger("idle");
    }

    public void enemyGetDamage()
    {
        anim.SetTrigger("getDamage");
    }

    public void enemyDead()
    {
        anim.SetTrigger("dead");
    }
}
