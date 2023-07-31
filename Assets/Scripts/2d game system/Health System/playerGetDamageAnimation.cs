using UnityEngine;
using EZCameraShake;

public class playerGetDamageAnimation : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Trap" || collision.tag == "Enemy")
        {
            anim.SetTrigger("getDamage");
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        }
    }

    
}
