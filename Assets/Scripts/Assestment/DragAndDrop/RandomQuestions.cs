
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomQuestions : MonoBehaviour
{
    SceneTransition SceneTransition;
    public List<GameObject> questionsDragAndDrop = new List<GameObject> { };
    [SerializeField] public Text stages;
    [SerializeField] private AudioSource clickSoundEffect;
    [SerializeField] private AudioSource dropSoundEffect;

    [SerializeField] private AudioSource correctSoundEffects;
    [SerializeField] private AudioSource wrongSoundEffects;

    public int currentStages;

    private void Awake()
    {
        SceneTransition = GameObject.Find("SceneManager").GetComponent<SceneTransition>();
    }
    private void OnEnable()
    {
        Actions.onClickSoundEffect += ClickSoundEffect;
        Actions.onDropSoundEffect += DropSoundEffect;

        Actions.onCorrectAnswerSoundEffect += CorrectSoundEffect;
        Actions.onWrongAnswerSoundEffect += WrongSoundEffect;
    }
    private void OnDisable()
    {
        Actions.onClickSoundEffect -= ClickSoundEffect;
        Actions.onDropSoundEffect -= DropSoundEffect;

        Actions.onCorrectAnswerSoundEffect -= CorrectSoundEffect;
        Actions.onWrongAnswerSoundEffect -= WrongSoundEffect;
    }

    private void Start()
    {
        currentStages = 1;
        Actions.onRandomQuestions?.Invoke(questionsDragAndDrop);
    }

    public void checkStages()
    {
        if (currentStages == 10)
        {
            SceneTransition.nextLevel();
        }
        else
        {
            addStages();
            Actions.onRandomQuestions(questionsDragAndDrop);
        }
    }
    public void addStages()
    {
        currentStages++;
        stages.text = currentStages.ToString() + "/10";
    }
    private void ClickSoundEffect()
    {
        clickSoundEffect.Play();
    }
    private void DropSoundEffect()
    {
        dropSoundEffect.Play();
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
