using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObject : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioSource canSoundEffect;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fireball")
        {
            canSoundEffect.Play();
            //anim.SetTrigger("dead");
            //objectDeactivate();
            //CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
            anim.SetTrigger("fuelTankExplode");
        }
    }

    public void objectDeactivate()
    {
        gameObject.SetActive(false);
        //Actions.onSetEnemySpeed.Invoke(0f);
    }
}
