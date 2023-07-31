using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class act1Question15 : MonoBehaviour
{

    [SerializeField] private Text[] correctLeterLabel;

    [SerializeField] private Button[] buttonChoices;

    [SerializeField] private Text[] buttonTextChoices;

    [SerializeField] GameObject Question2;

    [SerializeField] GameObject wrongPopup;

    private char wrongLetters;
    private char[] correctLetters = new char[6];

    List<char> AnswerSwitch = new List<char> { 'r', 'e', 'p', 'e', 'a', 't' };

    private char letterCorrect;

    void Start()
    {
        switchWrongLetters();
        switchCorrectLetters();
        buttonClicked();
    }

    private void buttonClicked()
    {
        buttonChoices[0].onClick.AddListener(() => btnCorrectChoices(correctLetters[0]));
        buttonChoices[2].onClick.AddListener(() => btnCorrectChoices(correctLetters[1]));
        buttonChoices[4].onClick.AddListener(() => btnCorrectChoices(correctLetters[2]));
        buttonChoices[5].onClick.AddListener(() => btnCorrectChoices(correctLetters[3]));
        buttonChoices[6].onClick.AddListener(() => btnWrongChoices(correctLetters[4]));
        buttonChoices[1].onClick.AddListener(() => btnWrongChoices(correctLetters[5]));

        buttonChoices[3].onClick.AddListener(() => btnWrongChoices(wrongLetters));
    }

    private void switchCorrectLetters()
    {
        for (int i = 0; i < correctLetters.Length; i++)
        {
            correctLetters[i] = Actions.onRandomCorrectLettersGenerator.Invoke(AnswerSwitch, letterCorrect);
        }

        buttonTextChoices[0].text = correctLetters[0].ToString();
        buttonTextChoices[2].text = correctLetters[1].ToString();
        buttonTextChoices[4].text = correctLetters[2].ToString();
        buttonTextChoices[5].text = correctLetters[3].ToString();
        buttonTextChoices[6].text = correctLetters[4].ToString();
        buttonTextChoices[1].text = correctLetters[5].ToString();

    }

    private void switchWrongLetters()
    {
        wrongLetters = Actions.onRandomLettersGenerator.Invoke();
        buttonTextChoices[3].text = wrongLetters.ToString();
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
        else if (correctLeterLabel[5].text == "")
        {
            correctLeterLabel[5].text = CollectLetters.ToString();
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
        else if (correctLeterLabel[5].text == "")
        {
            correctLeterLabel[5].text = WrongLetters.ToString();

        }
    }

    public void buttonClear()
    {
        correctLeterLabel[0].text = "";
        correctLeterLabel[1].text = "";
        correctLeterLabel[2].text = "";
        correctLeterLabel[3].text = "";
        correctLeterLabel[4].text = "";
        correctLeterLabel[5].text = "";
    }

    public bool checkAnswerSwitch()
    {
        return correctLeterLabel[0].text == "r" && correctLeterLabel[1].text == "e" && correctLeterLabel[2].text == "p" && correctLeterLabel[3].text == "e" && correctLeterLabel[4].text == "a" && correctLeterLabel[5].text == "t";
    }

    public void buttonOk()
    {
        Actions.onCheckAnswer4P1W?.Invoke(Question2, wrongPopup, checkAnswerSwitch);
        buttonClear();
    }
    public void tryAgainButton()
    {
        wrongPopup.SetActive(false);
        buttonClear();
    }
}

