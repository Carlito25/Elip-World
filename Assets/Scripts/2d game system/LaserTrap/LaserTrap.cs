using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private AudioSource Laser;

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered; //when the trap gets triggered
    private bool active; //when the trap is active and can hurt the player

    private Health player;
    private bool load = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        if (!triggered)
    //            StartCoroutine(ActivateFiretrap());



    //        player = collision.GetComponent<Health>();
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    player = null;
    //}

    //private void FixedUpdate()
    //{
    //    if (active && player != null)
    //    {
    //        Laser.Play();
    //        player.TakeDamage(damage);
    //    }
    //}
    private void Update()
    {
        StartCoroutine(ActivateFiretrap());
    }


    private IEnumerator ActivateFiretrap()
    {
        //turn the sprite red to notify the player and trigger the trap
        triggered = true;
        spriteRend.color = Color.red;

        //Wait for delay, activate trap, turn on animation, return color back to normal
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white; //turn the sprite back to its initial color
        active = true;
        anim.SetBool("activated", true);

        //Wait until X seconds, deactivate trap and reset all variables and animator
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
