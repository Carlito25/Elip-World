using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class act1Question19 : MonoBehaviour
{

    [SerializeField] private Text[] correctLeterLabel;

    [SerializeField] private Button[] buttonChoices;

    [SerializeField] private Text[] buttonTextChoices;

    [SerializeField] GameObject wrongPopup;

    private char[] wrongLetters = new char[4];

    List<char> AnswerCase = new List<char> { 'o', 'n', 'e'};

    private char letterCorrect;

    private char[] correctLetters = new char[3];

    [SerializeField] GameObject currentQuestion;

    void Start()
    {
        caseWrongLetters();
        caseCorrectLetters();
        buttonClicked();
    }

    private void buttonClicked()
    {
        buttonChoices[0].onClick.AddListener(() => btnCorrectChoices(correctLetters[0]));
        buttonChoices[2].onClick.AddListener(() => btnCorrectChoices(correctLetters[1]));
        buttonChoices[6].onClick.AddListener(() => btnCorrectChoices(correctLetters[2]));

        buttonChoices[3].onClick.AddListener(() => btnWrongChoices(wrongLetters[0]));
        buttonChoices[4].onClick.AddListener(() => btnWrongChoices(wrongLetters[1]));
        buttonChoices[5].onClick.AddListener(() => btnWrongChoices(wrongLetters[2]));
        buttonChoices[1].onClick.AddListener(() => btnWrongChoices(wrongLetters[3]));
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
        buttonTextChoices[1].text = wrongLetters[3].ToString();
    }

    public void btnCorrectChoices(char CollectLetters)
    {

        if (correctLeterLabel[0].text == "")
        {
            correctLeterLabel[0].text = CollectLetters.ToString();

        }
        else if (correctLeterLabel[1].text == "")
        {
            correctLeterLabel[1].text = CollectLetters.ToString();

        }
        else if (correctLeterLabel[2].text == "")
        {
            correctLeterLabel[2].text = CollectLetters.ToString();

        }
       
    }
    public void btnWrongChoices(char WrongLetters)
    {
        if (correctLeterLabel[0].text == "")
        {
            correctLeterLabel[0].text = WrongLetters.ToString();

        }
        else if (correctLeterLabel[1].text == "")
        {
            correctLeterLabel[1].text = WrongLetters.ToString();

        }
        else if (correctLeterLabel[2].text == "")
        {
            correctLeterLabel[2].text = WrongLetters.ToString();

        }
    }

    public void buttonClear()
    {
        correctLeterLabel[0].text = "";
        correctLeterLabel[1].text = "";
        correctLeterLabel[2].text = ""; 

    }

    public bool checkAnswersCase()
    {
        return correctLeterLabel[0].text == "o" && correctLeterLabel[1].text == "n" && correctLeterLabel[2].text == "e";
    }

    public void buttonOk()
    {
        Actions.onCheckAnswer4P1W?.Invoke(currentQuestion, wrongPopup, checkAnswersCase);
        buttonClear();
    }
    public void tryAgainButton()
    {
        wrongPopup.SetActive(false);
        buttonClear();
    }
}


