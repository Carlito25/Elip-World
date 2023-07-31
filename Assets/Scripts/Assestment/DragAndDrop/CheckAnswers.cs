using UnityEngine;
public class CheckAnswers : MonoBehaviour
{
    [SerializeField] private GameObject firstAnswerSlot, firstChoices, secondAnswerSlot, secondChoices, thirdAnswerSlot, 
    thirdChoices, fourthAnswerSlot, fourthChoices, fifthAnswerSlot, fifthChoices;

    [SerializeField] private GameObject answerChoicesHide;
    [SerializeField] public GameObject wrongPopup;

    RandomQuestions randomQuestions;
    [SerializeField] GameObject currentQuestion;
    [SerializeField] private GameObject warningSign;
    private bool isWarningSignDeactivate;

    private void Awake()
    {
        randomQuestions = GameObject.Find("Canvas").GetComponent<RandomQuestions>();  
    }

    private bool onGetWarningSignDeactivate()
    {
        return isWarningSignDeactivate;
    }

    private void OnEnable()
    {
       Actions.onGetWarningSign += onGetWarningSignDeactivate;
    }
    private void OnDisable()
    {
        Actions.onGetWarningSign -= onGetWarningSignDeactivate;
    }

    public void checkAnswers()
    {
        if (firstAnswerSlot.transform.position == firstChoices.transform.position && secondAnswerSlot.transform.position == secondChoices.transform.position
            && thirdAnswerSlot.transform.position == thirdChoices.transform.position && fourthAnswerSlot.transform.position == fourthChoices.transform.position
            && fifthAnswerSlot.transform.position == fifthChoices.transform.position)
        {
            Actions.onCorrectAnswerSoundEffect?.Invoke();
            randomQuestions.questionsDragAndDrop.RemoveAt(Actions.onGetPreviousQuestion.Invoke());
            currentQuestion.SetActive(false);
            randomQuestions.checkStages();
        }
        else
        {
            Actions.onWrongAnswerSoundEffect?.Invoke();
            wrongPopup.SetActive(true);
            currentQuestion.SetActive(false);
            Actions.onRandomQuestions(randomQuestions.questionsDragAndDrop);  
        }
    }



    public void deactiveWarningSign()
    {
        --disabledCompileButton.numberOfCompile;
        if (firstAnswerSlot.transform.position == firstChoices.transform.position && secondAnswerSlot.transform.position == secondChoices.transform.position
            && thirdAnswerSlot.transform.position == thirdChoices.transform.position && fourthAnswerSlot.transform.position == fourthChoices.transform.position
            && fifthAnswerSlot.transform.position == fifthChoices.transform.position)
        {
            // isWarningSignDeactivate = true;
            warningSign.SetActive(false);
        }
        else
        {
            warningSign.SetActive(true);
        }
    }
    public void closeWrongPopup()
    {
        answerChoicesHide.SetActive(true);
        wrongPopup.SetActive(false);  
    }

}
