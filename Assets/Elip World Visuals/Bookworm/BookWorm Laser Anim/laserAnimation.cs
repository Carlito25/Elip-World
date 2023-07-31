using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserAnimation : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void playerLaserAnimation()
    {
        anim.SetTrigger("laserAttack");
        laserIdleAnimation();
    }
    public void laserIdleAnimation()
    {
        anim.SetTrigger("idle");
    }
}
