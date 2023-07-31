using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
   [SerializeField] private float startingHealth;
   [SerializeField] private AudioSource healthSound;
   [SerializeField] private AudioSource deadSoundEffect;
    [SerializeField] private Button pauseButton;

    public float currentHealth { get; private set; }
   
    private Animator anim;
    private Rigidbody2D rb;

    private Vector3 respawnPoint;
    [SerializeField] private GameObject deadPopup;

    [Header ("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    private void OnEnable()
    {
        Actions.onGetPlayerHealth += getCurrentHealth;
    }
    private void OnDisable()
    {
        Actions.onGetPlayerHealth -= getCurrentHealth;
    }

    private float getCurrentHealth()
    {
        return currentHealth;
    }

    void Start()
    {
       
        respawnPoint = transform.position;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
      
        Physics2D.IgnoreLayerCollision(7, 8, false);
        currentHealth = startingHealth;  
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {         
            StartCoroutine(Invunerability());
        }
        else if (currentHealth == 0)
        {
            deadSoundEffect.Play();
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            anim.SetTrigger("death");
            Invoke("ActivedeadPopup", .5f);
            pauseButton.interactable = false;
            GetComponent<Collider2D>().enabled = false;
        }
      
        else
        {
            Debug.Log("else of takedamage");
         
        }
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
        //Invoke("delayIgnoreLayerCollision", 1f);
    }

    private void delayIgnoreLayerCollision()
    {
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    public void addHealth(float _value)
    {
       currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
       healthSound.Play();
    }
    public void Restartlevel()
    {
        Actions.MainMenuButtonSoundEffect?.Invoke();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Actions.onEnabledMovePlayer();
        PauseGame.GameIsPaused = false;

    }
    public void quitButton()
    {
        Actions.MainMenuButtonSoundEffect?.Invoke();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameMenu");
        Time.timeScale = 1f;
    }
    public void ActivedeadPopup()
    {
        deadPopup.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Respawn()
    {
        addHealth(startingHealth);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        anim.SetTrigger("respawnCheckpoint");
        Time.timeScale = 1f;
    }
 }

