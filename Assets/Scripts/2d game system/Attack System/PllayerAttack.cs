using UnityEngine;

public class PllayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private float cooldownTimer = Mathf.Infinity;

    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private Transform firePoint;

    [SerializeField] private AudioSource attackSoundEffect;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if((Input.GetMouseButton(0) || Input.GetKey(KeyCode.G)) && cooldownTimer > attackCooldown && PlayerMovement.onCanAttack() &&  PlayerMovement.isPopupOpenProperty == false)
            attack();
            
        cooldownTimer += Time.deltaTime;
    }

    private void attack()
    {
        attackSoundEffect.Play();
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        fireballs[findFireball()].transform.position = firePoint.position;
       fireballs[findFireball()].GetComponent<ProjectTile>().setDirection(Mathf.Sign(transform.localScale.x));
        
    }
    private int findFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

   
}
