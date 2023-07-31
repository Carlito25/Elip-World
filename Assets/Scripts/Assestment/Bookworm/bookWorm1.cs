using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class bookWorm1 : MonoBehaviour
{
    //activity1code act1Code;
    randomGenerator RandomGenerator;
    playerBookWormHealth BookWormHealth;
    EnemyHealth enemyHealth;

    [SerializeField] Text letterB;
    [SerializeField] Text letterR;
    [SerializeField] Text letterE;
    [SerializeField] Text letterA;
    [SerializeField] Text letterK;

    [SerializeField] Button firstButton;
    [SerializeField] Button secondButton;
    [SerializeField] Button thirdButton;
    [SerializeField] Button fourthButton;
    [SerializeField] Button fifthButton;
    [SerializeField] Button sixthButton;
    [SerializeField] Button seventhButton;

    [SerializeField] Text firstButtonText;
    [SerializeField] Text secondButtonText;
    [SerializeField] Text thirdButtonText;
    [SerializeField] Text fourthButtonText;
    [SerializeField] Text fifthButtonText;
    [SerializeField] Text sixthButtonText;
    [SerializeField] Text seventhButtonText;

    //[SerializeField] GameObject wrongPopup;

    //private bool isCorrect = true;

  
    private char wrongLetters2;
    private char wrongLetters3;

    List<char> AnswerBreak = new List<char> { 'b', 'r', 'e', 'a', 'k' };

    private char letterCorrect;

    private char correctLetters1;
    private char correctLetters2;
    private char correctLetters3;
    private char correctLetters4;
    private char correctLetters5;
    

    [SerializeField] GameObject currentQuestion;
    void Awake()
    {
        //act1Code = GameObject.Find("Canvas").GetComponent<activity1code>();
        RandomGenerator = GameObject.Find("Canvas").GetComponent<randomGenerator>();
        BookWormHealth = GameObject.Find("Main Camera").GetComponent<playerBookWormHealth>();
        enemyHealth = GameObject.Find("Main Camera").GetComponent<EnemyHealth>();
    }
    void Start()
    {
        breakCorrectLetters();
        breakWrongLetters();
        buttonClicked();
    }

    public void btnCorrectChoices(char CollectLetters)
    {

        if (letterB.text == "")
        {
            letterB.text = CollectLetters.ToString();

        }
        else if (letterR.text == "")
        {
            letterR.text = CollectLetters.ToString();

        }
        else if (letterE.text == "")
        {
            letterE.text = CollectLetters.ToString();

        }
        else if (letterA.text == "")
        {
            letterA.text = CollectLetters.ToString();

        }
        else if (letterK.text == "")
        {
            letterK.text = CollectLetters.ToString();

        }
    }
    public void btnWrongChoices(char WrongLetters)
    {
        if (letterB.text == "")
        {
            letterB.text = WrongLetters.ToString();

        }
        else if (letterR.text == "")
        {
            letterR.text = WrongLetters.ToString();

        }
        else if (letterE.text == "")
        {
            letterE.text = WrongLetters.ToString();

        }
        else if (letterA.text == "")
        {
            letterA.text = WrongLetters.ToString();

        }
        else if (letterK.text == "")
        {
            letterK.text = WrongLetters.ToString();

        }
    }

    public void buttonClearLabel()
    {
        letterB.text = "";
        letterR.text = "";
        letterE.text = "";
        letterA.text = "";
        letterK.text = "";
    }
    public void checkAnswer()
    {
        if (letterB.text == "b" && letterR.text == "r" && letterE.text == "e" && letterA.text == "a" && letterK.text == "k")
        {
            //currentQuestion.SetActive(false);
            //act1Code.checkStages();
            Debug.Log("correct");
           // enemyHealth.bookwormEnemyTakeDamage(1f);
        }
        else
        {
            //wrongPopup.SetActive(true);
            buttonClearLabel();
            //BookWormHealth.bookwormTakeDamage(.5f);
        }
    }
    public void tryAgainButton()
    {
        //wrongPopup.SetActive(false);
        buttonClearLabel();
    }
    private void breakCorrectLetters()
    {
        correctLetters1 = RandomGenerator.getRandomCorrectLetters(AnswerBreak, letterCorrect);
        correctLetters2 = RandomGenerator.getRandomCorrectLetters(AnswerBreak, letterCorrect);
        correctLetters3 = RandomGenerator.getRandomCorrectLetters(AnswerBreak, letterCorrect);
        correctLetters4 = RandomGenerator.getRandomCorrectLetters(AnswerBreak, letterCorrect);
        correctLetters5 = RandomGenerator.getRandomCorrectLetters(AnswerBreak, letterCorrect);

        firstButtonText.text = correctLetters1.ToString(); //buttonB
        thirdButtonText.text = correctLetters2.ToString();//buttonE
        seventhButtonText.text = correctLetters3.ToString();//buttonA
        secondButtonText.text = correctLetters4.ToString();
        fourthButtonText.text = correctLetters5.ToString();//buttonD
    }

    private void buttonClicked()
    {
        firstButton.onClick.AddListener(() => btnCorrectChoices(correctLetters1));
        thirdButton.onClick.AddListener(() => btnCorrectChoices(correctLetters2));
        seventhButton.onClick.AddListener(() => btnCorrectChoices(correctLetters3));
        secondButton.onClick.AddListener(() => btnCorrectChoices(correctLetters4));
        fourthButton.onClick.AddListener(() => btnWrongChoices(correctLetters5));

        fifthButton.onClick.AddListener(() => btnWrongChoices(wrongLetters2));
        sixthButton.onClick.AddListener(() => btnWrongChoices(wrongLetters3));
    }

    private void breakWrongLetters()
    {
        wrongLetters2 = RandomGenerator.getRandomLetters();
        wrongLetters3 = RandomGenerator.getRandomLetters();

        fifthButtonText.text = wrongLetters2.ToString();
        sixthButtonText.text = wrongLetters3.ToString();
    }
}



