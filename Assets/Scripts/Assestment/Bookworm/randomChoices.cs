using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomChoices : MonoBehaviour
{

    [SerializeField] Text firstButtonText, secondButtonText, thirdButtonText, fourthButtonText, fifthButtonText, sixthButtonText, seventhButtonText;

    [SerializeField] private char  wrongLetters1, wrongLetters2, wrongLetters3, wrongLetters4, wrongLetters5, wrongLetters6, wrongLetters7;

   

    public char getRandomLetters()
    {
        return (char)Random.Range('a', 'z');
    }
    private void Start()
    {
        wrongLetters1 = getRandomLetters();
        wrongLetters2 = getRandomLetters();
        wrongLetters3 = getRandomLetters();
        wrongLetters4 = getRandomLetters();
        wrongLetters5 = getRandomLetters();
        wrongLetters6 = getRandomLetters();
        wrongLetters7 = getRandomLetters();



        firstButtonText.text = wrongLetters1.ToString();
        secondButtonText.text = wrongLetters2.ToString();
        thirdButtonText.text = wrongLetters3.ToString();
        fourthButtonText.text =  wrongLetters4.ToString();
        fifthButtonText.text =  wrongLetters5.ToString();
        sixthButtonText.text =  wrongLetters6.ToString();
        seventhButtonText.text = wrongLetters7.ToString();
    }
}
