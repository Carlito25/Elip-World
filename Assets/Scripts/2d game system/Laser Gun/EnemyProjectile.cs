using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : trapsOrENemeyDamage
{
    //[SerializeField] private AudioSource Laser;
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;

    public void ActivateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }
    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision); //Execute logic from parent script first
        if (collision.gameObject.CompareTag("Cherry") || collision.gameObject.CompareTag("Fireball"))
        {
            gameObject.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("laserDestroyDelay",.5f);
        }
        else
        {
            gameObject.SetActive(false);
        }    
    }

    private void laserDestroyDelay()
    {
        gameObject.SetActive(false);
    }
}
