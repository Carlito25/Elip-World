using System;
using UnityEngine;

public class checkAnswersBW4P1W : MonoBehaviour
{
    playerBookWormHealth PlayerBookWormHealth;
    EnemyHealth EnemyHealth;
    randomGenerator RandomGenerator;
    SceneTransition SceneTransition;
    questions4P1W Questions4P1W;
    QuestionBW QuestionBW;

    private int nextSceneLoad;

    int currentStages;
    [SerializeField] private AudioSource correctSoundEffects;
    [SerializeField] private AudioSource wrongSoundEffects;
    private void Awake()
    {
        currentStages = 1;

        PlayerBookWormHealth = GameObject.Find("Main Camera").GetComponent<playerBookWormHealth>();
        EnemyHealth = GameObject.Find("Main Camera").GetComponent<EnemyHealth>();
        RandomGenerator = GameObject.Find("Canvas").GetComponent<randomGenerator>();
        SceneTransition = GameObject.Find("SceneManager").GetComponent<SceneTransition>();
        Questions4P1W = GameObject.Find("Canvas").GetComponent<questions4P1W>();
        QuestionBW = GameObject.Find("Canvas").GetComponent<QuestionBW>();

        
    }
  

    private void OnEnable()
    {
        Actions.onCheckAnswerBW += checkAnswerBookworm;
        Actions.onCheckAnswer4P1W += checkAnswerIn4Pic1Word;

        Actions.onCorrectAnswerSoundEffect += CorrectSoundEffect;
        Actions.onWrongAnswerSoundEffect += WrongSoundEffect;
    }
    private void OnDisable()
    {
        Actions.onCheckAnswerBW -= checkAnswerBookworm;
        Actions.onCheckAnswer4P1W -= checkAnswerIn4Pic1Word;

        Actions.onCorrectAnswerSoundEffect -= CorrectSoundEffect;
        Actions.onWrongAnswerSoundEffect -= WrongSoundEffect;
    }


    public void checkAnswerIn4Pic1Word(GameObject currentQuestion, GameObject wrongPopup, Func<bool> checkAnswers)
    {
        if (checkAnswers())
        {
            CorrectSoundEffect();
            Questions4P1W.questions4Pic1Word.RemoveAt(Actions.onGetPreviousQuestion.Invoke());
            currentQuestion.SetActive(false);
            checkStages();
        }
        else
        {
            WrongSoundEffect();
            wrongPopup.SetActive(true);
            currentQuestion.SetActive(false);
            RandomGenerator.getRandomQuestion(Questions4P1W.questions4Pic1Word);
        }
    }
    public void checkStages()
    {
        if (currentStages == 5)
        {
            SceneTransition.nextLevel();
        }
        else
        {
            addStages();
            RandomGenerator.getRandomQuestion(Questions4P1W.questions4Pic1Word);
        }
    }

    public void addStages()
    {
        currentStages++;
        Questions4P1W.stages.text = currentStages.ToString() + "/5";
    }

    public void checkAnswerBookworm(GameObject currentQuestion, Func<bool> checkAnswers, Func<bool> checkAnswersIfEmpty, Action clearLabel)
    {
        if (checkAnswers())
        {
           Actions.BWPlayerAttackSoundEffect?.Invoke();
           QuestionBW.questionsBookworm.RemoveAt(Actions.onGetPreviousQuestion.Invoke());
           currentQuestion.SetActive(false);
           EnemyHealth.bookwormEnemyTakeDamage(1f);
           Debug.Log("1 heart damage");
            Bookworm5label.currentTime = 30;
        }
        else if (checkAnswersIfEmpty())
        {
            Debug.Log("Your answer is blank! You need to answer");
        }

        else
        {
            Actions.BWBossAttackSoundEffect?.Invoke();
            clearLabel();
            currentQuestion.SetActive(false);
            PlayerBookWormHealth.bookwormTakeDamage(.5f);
            Bookworm5label.currentTime = 30;
        }
    }


    private void CorrectSoundEffect()
    {
        correctSoundEffects.Play();
        Debug.Log("correct sound effect will play");
    }
    private void WrongSoundEffect()
    {
        wrongSoundEffects.Play();
        Debug.Log("wrong sound effect will play");
    }
}
