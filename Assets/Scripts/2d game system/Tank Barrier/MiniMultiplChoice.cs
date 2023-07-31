
using UnityEngine;

public class MiniMultiplChoice : MonoBehaviour
{
    [SerializeField] public GameObject wrongPopup;
    [SerializeField] GameObject currentQuestion;
    [SerializeField] GameObject itemBarrier;
    [SerializeField] private AudioSource barrierDestroySoundEffect;

    Health health;

    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        health = GameObject.Find("Player").GetComponent<Health>();
    }
    public void correctAnswer()
    {
        Actions.onCorrectAnswerSoundEffect?.Invoke();
        currentQuestion.SetActive(false);
        barrierDestroySoundEffect.Play();
        anim.SetTrigger("destroy");
        Invoke("destroyObstacleOutpost", 1f);
        Actions.onEnabledMovePlayer();
    }

    public void wrongAnswer()
    {
        wrongPopup.SetActive(true);
        health.TakeDamage(1);
        currentQuestion.SetActive(false);
        Actions.onEnabledMovePlayer();
    }

    private void destroyObstacleOutpost()
    {
        itemBarrier.SetActive(false);
    }
    public void tryAgainButton()
    {
        wrongPopup.SetActive(false);
    }
}

