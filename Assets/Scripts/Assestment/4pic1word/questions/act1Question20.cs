using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class act1Question20 : MonoBehaviour
{
    [SerializeField] private Text[] correctLeterLabel;

    [SerializeField] private Text[] buttonTextChoices;

    [SerializeField] private Button[] buttonChoices;

    [SerializeField] private GameObject currentQuestion;

    [SerializeField] private GameObject wrongPopup;


    List<char> AnswerBreak = new List<char> { 'l', 'o', 'o', 'p', 's' };

    private char letterCorrect;

    private char[] wrongLetters = new char[2];
    private char[] correctLetters = new char[5];

    private void Start()
    {
        breakWrongLetters();
        breakCorrectLetters();
        buttonClicked();
    }
    private void buttonClicked()
    {
        buttonChoices[0].onClick.AddListener(() => btnCorrectChoices(correctLetters[0]));
        buttonChoices[2].onClick.AddListener(() => btnCorrectChoices(correctLetters[1]));
        buttonChoices[6].onClick.AddListener(() => btnCorrectChoices(correctLetters[2]));
        buttonChoices[5].onClick.AddListener(() => btnCorrectChoices(correctLetters[3]));
        buttonChoices[4].onClick.AddListener(() => btnCorrectChoices(correctLetters[4]));

        buttonChoices[3].onClick.AddListener(() => btnWrongChoices(wrongLetters[0]));
        buttonChoices[1].onClick.AddListener(() => btnWrongChoices(wrongLetters[1]));
    }
    private void breakCorrectLetters()
    {
        for (int i = 0; i < correctLetters.Length; i++)
        {
            correctLetters[i] = Actions.onRandomCorrectLettersGenerator.Invoke(AnswerBreak, letterCorrect);
        }
        buttonTextChoices[0].text = correctLetters[0].ToString();
        buttonTextChoices[2].text = correctLetters[1].ToString();
        buttonTextChoices[6].text = correctLetters[2].ToString();
        buttonTextChoices[5].text = correctLetters[3].ToString();
        buttonTextChoices[4].text = correctLetters[4].ToString();

    }
    private void breakWrongLetters()
    {
        for (int i = 0; i < wrongLetters.Length; i++)
        {
            wrongLetters[i] = Actions.onRandomLettersGenerator.Invoke();
        }
        buttonTextChoices[3].text = wrongLetters[0].ToString();
        buttonTextChoices[1].text = wrongLetters[1].ToString();
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
        else if (correctLeterLabel[3].text == "")
        {
            correctLeterLabel[3].text = CollectLetters.ToString();
        }
        else if (correctLeterLabel[4].text == "")
        {
            correctLeterLabel[4].text = CollectLetters.ToString();
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
        else if (correctLeterLabel[3].text == "")
        {
            correctLeterLabel[3].text = WrongLetters.ToString();

        }
        else if (correctLeterLabel[4].text == "")
        {
            correctLeterLabel[4].text = WrongLetters.ToString();

        }
    }
    public void buttonClear()
    {
        correctLeterLabel[0].text = "";
        correctLeterLabel[1].text = "";
        correctLeterLabel[2].text = "";
        correctLeterLabel[3].text = "";
        correctLeterLabel[4].text = "";
    }
    public bool checkAnswerBreak()
    {
        return correctLeterLabel[0].text == "l" && correctLeterLabel[1].text == "o" && correctLeterLabel[2].text == "o" && correctLeterLabel[3].text == "p" && correctLeterLabel[4].text == "s";
    }
    public void buttonOk()
    {
        Actions.onCheckAnswer4P1W(currentQuestion, wrongPopup, checkAnswerBreak);
        buttonClear();
    }
    public void tryAgainButton()
    {
        wrongPopup.SetActive(false);
        buttonClear();
    }
}
