using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bookWorm : MonoBehaviour
{
    //activity1code act1Code; // for randomize questions

    [SerializeField] Text [] correctLetersLabel;

    [SerializeField] Button [] buttonChoices;

    [SerializeField] Text [] buttonTextChoices;

    [SerializeField] GameObject currentQuestion;
  

    //[SerializeField] GameObject wrongPopup;

    private char[] correctLetters =  new char[4];
    private char[] wrongLetters = new char[12];

    List<char> AnswerCase = new List<char> { 'c', 'a', 's', 'e' };

    private char letterCorrect;

    void Awake()
    {
        //act1Code = GameObject.Find("Canvas").GetComponent<activity1code>(); // code for randomize the questions
    }
    void Start()
    {
        caseWrongLetters();
        caseCorrectLetters();
        buttonClicked();
    }
    private void caseWrongLetters()
    {
        for (int i = 0; i < wrongLetters.Length; i++)
        {
            wrongLetters[i] = Actions.onRandomLettersGenerator.Invoke();      
        }

        buttonTextChoices[3].text = wrongLetters[0].ToString();
        buttonTextChoices[4].text = wrongLetters[1].ToString();
        buttonTextChoices[5].text = wrongLetters[2].ToString();
        buttonTextChoices[7].text = wrongLetters[3].ToString();
        buttonTextChoices[8].text = wrongLetters[4].ToString();
        buttonTextChoices[9].text = wrongLetters[5].ToString();
        buttonTextChoices[10].text = wrongLetters[6].ToString();
        buttonTextChoices[11].text = wrongLetters[7].ToString();
        buttonTextChoices[12].text = wrongLetters[8].ToString();
        buttonTextChoices[13].text = wrongLetters[9].ToString();
        buttonTextChoices[14].text = wrongLetters[10].ToString();
        buttonTextChoices[15].text = wrongLetters[11].ToString();
    }

    private void caseCorrectLetters()
    {
        for (int i = 0; i < correctLetters.Length; i++)
        {
            correctLetters[i] = Actions.onRandomCorrectLettersGenerator.Invoke(AnswerCase, letterCorrect);
        }

        buttonTextChoices[0].text = correctLetters[0].ToString(); 
        buttonTextChoices[2].text = correctLetters[1].ToString();
        buttonTextChoices[6].text = correctLetters[2].ToString();
        buttonTextChoices[1].text = correctLetters[3].ToString();
    }

    public void buttonClicked()
    {
        buttonChoices[0].onClick.AddListener(() => btnCorrectChoices(correctLetters[0]));
        buttonChoices[2].onClick.AddListener(() => btnCorrectChoices(correctLetters[1]));
        buttonChoices[6].onClick.AddListener(() => btnCorrectChoices(correctLetters[2]));
        buttonChoices[1].onClick.AddListener(() => btnCorrectChoices(correctLetters[3]));

        buttonChoices[3].onClick.AddListener(() => btnWrongChoices(wrongLetters[0]));
        buttonChoices[4].onClick.AddListener(() => btnWrongChoices(wrongLetters[1]));
        buttonChoices[5].onClick.AddListener(() => btnWrongChoices(wrongLetters[2]));
        buttonChoices[7].onClick.AddListener(() => btnWrongChoices(wrongLetters[3]));

        buttonChoices[8].onClick.AddListener(() => btnWrongChoices(wrongLetters[4]));
        buttonChoices[9].onClick.AddListener(() => btnWrongChoices(wrongLetters[5]));
        buttonChoices[10].onClick.AddListener(() => btnWrongChoices(wrongLetters[6]));
        buttonChoices[11].onClick.AddListener(() => btnWrongChoices(wrongLetters[7]));

        buttonChoices[12].onClick.AddListener(() => btnWrongChoices(wrongLetters[8]));
        buttonChoices[13].onClick.AddListener(() => btnWrongChoices(wrongLetters[9]));
        buttonChoices[14].onClick.AddListener(() => btnWrongChoices(wrongLetters[10]));
        buttonChoices[15].onClick.AddListener(() => btnWrongChoices(wrongLetters[11]));

    }

    public void btnCorrectChoices(char CollectLetters)
    {

        if (correctLetersLabel[0].text == "")
        {
            correctLetersLabel[0].text = CollectLetters.ToString();

        }
        else if (correctLetersLabel[1].text == "")
        {
            correctLetersLabel[1].text = CollectLetters.ToString();

        }
        else if (correctLetersLabel[2].text == "")
        {
            correctLetersLabel[2].text = CollectLetters.ToString();

        }
        else if (correctLetersLabel[3].text == "")
        {
            correctLetersLabel[3].text = CollectLetters.ToString();

        }
    }
    public void btnWrongChoices(char WrongLetters)
    {
        if (correctLetersLabel[0].text == "")
        {
            correctLetersLabel[0].text = WrongLetters.ToString();

        }
        else if (correctLetersLabel[1].text == "")
        {
            correctLetersLabel[1].text = WrongLetters.ToString();

        }
        else if (correctLetersLabel[2].text == "")
        {
            correctLetersLabel[2].text = WrongLetters.ToString();

        }
        else if (correctLetersLabel[3].text == "")
        {
            correctLetersLabel[3].text = WrongLetters.ToString();

        }
    }

    public void buttonClearLabel()
    {
        correctLetersLabel[0].text = "";
        correctLetersLabel[1].text = "";
        correctLetersLabel[2].text = "";
        correctLetersLabel[3].text = "";
    }
    
    public bool checkAnswerCase()
    {
        return correctLetersLabel[0].text == "c" && correctLetersLabel[1].text == "a" && correctLetersLabel[2].text == "s" && correctLetersLabel[3].text == "e";
    }

    public bool checkAnswerIfEmpty()
    {
        return string.IsNullOrEmpty(correctLetersLabel[0].text) && string.IsNullOrEmpty(correctLetersLabel[1].text)
            && string.IsNullOrEmpty(correctLetersLabel[2].text) && string.IsNullOrEmpty(correctLetersLabel[3].text);
    }
    public void checkAnswer()
    {
        Actions.onCheckAnswerBW?.Invoke(currentQuestion, checkAnswerCase, checkAnswerIfEmpty, buttonClearLabel);
        buttonClearLabel();
    }
    public void tryAgainButton()
    {
        //wrongPopup.SetActive(false);
        buttonClearLabel();
    }
}




