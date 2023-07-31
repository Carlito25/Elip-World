using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;

    
    private BoxCollider2D boxCollider;
    private Animator anim;

   private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

   private void Update()
    {

        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed,0,0);

        lifetime += Time.deltaTime;
        if (lifetime > .3) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Cherry") || collision.gameObject.CompareTag("PopupInfo") || collision.gameObject.CompareTag("IntroDialog")
            || collision.gameObject.CompareTag("HealthCollectibles") || collision.gameObject.CompareTag("LaserGun") )
        {
            return;
        } 
        else
        {
            hit = true;
            boxCollider.enabled = false;
            anim.SetTrigger("explode");
        }
    }
    public void setDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        //float localScaleX = transform.localRotation.x;
        if (Mathf.Sign(localScaleX) != _direction)
             localScaleX = -localScaleX;
        
            transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

    }
    private void deactive()
    {
        gameObject.SetActive(false);
    }
}


