using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
   
    public static Func <bool> onCanAttack;
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;
    private SpriteRenderer sr;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;


    private enum MovementState { idle, running, jumping, falling/*, attack*/ }

    [SerializeField] private AudioSource jumpSoundEffect;
 

    private static bool isPopupOpen;
    public static bool isPopupOpenProperty
    {
        get { return isPopupOpen; }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // movement forward and backward function, Vector2(x,y)
       
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        // jump function, Vector3(x,y)
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSoundEffect.Play();
        }

        //cooldownTimer += Time.deltaTime;

        UpdateAnimationState();
    }

    private void OnEnable()
    {
        Actions.onFreezePosition += freezePosition;
        Actions.onEnabledMovePlayer += enabledMovePlayer;

        onCanAttack += canAttack;
    }
    private void OnDisable()
    {
        Actions.onFreezePosition -= freezePosition;
        Actions.onEnabledMovePlayer -= enabledMovePlayer;

        onCanAttack -= canAttack;
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            transform.localScale = Vector3.one;
            //transform.localRotation = Quaternion.Euler(0,0, 0f);
            //sr.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            transform.localScale = new Vector3(-1, 1, 1);
           // transform.localRotation = Quaternion.Euler(0, 180f, 0f);
            //sr.flipX = true;
           

        }
        else
        {
            state = MovementState.idle;
        }


        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    

    public void freezePosition()
    {
        //rb.constraints = RigidbodyConstraints2D.FreezePosition;
        Time.timeScale = 0f;
        isPopupOpen = true;
    }
 
    public void enabledMovePlayer()
    {
        Time.timeScale = 1f;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        isPopupOpen = false;
    }

    public bool canAttack()
    {
        return IsGrounded();
    }

}
