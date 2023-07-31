using UnityEngine;

public class playerAttackAnimation : MonoBehaviour
{
    private Animator anim;

    private void OnEnable()
    {
        playerBookWormHealth.onEnemyAttack += getDamage;
    }
    private void OnDisable()
    {
        playerBookWormHealth.onEnemyAttack -= getDamage;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void attackAnimation()
    {
        anim.SetTrigger("attack");
    }
    public void idleAnimation()
    {
        anim.SetTrigger("idle");
    }

    public void getDamage()
    {
        anim.SetTrigger("getDamage");
    }
 
    
}
