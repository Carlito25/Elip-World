using UnityEngine;

public class trapsOrENemeyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] protected AudioSource DeathSoundEffect;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            
            DeathSoundEffect.Play();
        }
    }
}
