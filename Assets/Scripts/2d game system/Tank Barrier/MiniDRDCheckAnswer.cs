using UnityEngine;

public class MiniDRDCheckAnswer : MonoBehaviour
{
    private Animator anim;

   
    [SerializeField]
    private GameObject firstAnswerSlot, firstChoices, secondAnswerSlot, secondChoices, thirdAnswerSlot,
    thirdChoices;
    [SerializeField] private GameObject answerChoicesHide;
    [SerializeField] public GameObject wrongPopup;

    RandomQuestions randomQuestions;
    [SerializeField] GameObject currentQuestion;
   [SerializeField] GameObject itemBarrier;

    itemBarrierQuiz1 itemBarrierQuiz1;
    [SerializeField] private AudioSource barrierDestroySoundEffect; 
    private void Awake()
    { 
        itemBarrierQuiz1 = GameObject.Find("Canvas").GetComponent<itemBarrierQuiz1>();
        anim = GetComponent<Animator>();
    }

    public void checkAnswers()
    {
        if (firstAnswerSlot.transform.position == firstChoices.transform.position && secondAnswerSlot.transform.position == secondChoices.transform.position
            && thirdAnswerSlot.transform.position == thirdChoices.transform.position)
        {
            Actions.onCorrectAnswerSoundEffect?.Invoke();
            currentQuestion.SetActive(false);
            anim.SetTrigger("destroy");
            barrierDestroySoundEffect.Play();
            Actions.onEnabledMovePlayer();
            Invoke("destroyObstacleOutpost", 1f);
        }
        else
        {
            Actions.onWrongAnswerSoundEffect?.Invoke();
            wrongPopup.SetActive(true);
            currentQuestion.SetActive(true);
        }
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