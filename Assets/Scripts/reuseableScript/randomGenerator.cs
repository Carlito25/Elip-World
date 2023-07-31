using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class randomGenerator : MonoBehaviour
{
    private int previousQuestion;
   
    private void OnEnable()
    {
        Actions.onRandomLettersGenerator += getRandomLetters;
        Actions.onRandomCorrectLettersGenerator += getRandomCorrectLetters;

        Actions.onRandomQuestions += getRandomQuestion;

        Actions.onGetPreviousQuestion += getpreviousQuestion;
    }
    private void OnDisable()
    {
        Actions.onRandomLettersGenerator -= getRandomLetters;
        Actions.onRandomCorrectLettersGenerator -= getRandomCorrectLetters;

        Actions.onRandomQuestions -= getRandomQuestion;
        Actions.onGetPreviousQuestion -= getpreviousQuestion;
    }

    public char getRandomLetters()
    {
        return (char)Random.Range('a', 'z');
    }

    public char getRandomCorrectLetters(List<char> correctLetterList, char lettercorrect)
    {
        int randomLettersIndex = Random.Range(0, correctLetterList.Count);
        lettercorrect = correctLetterList[randomLettersIndex];
        correctLetterList.RemoveAt(randomLettersIndex);
        return (char)lettercorrect;
    }
    public void getRandomQuestion(List<GameObject> questionsList)
    {
        int randomQuestionIndex = Random.Range(0, questionsList.Count);
        questionsList[randomQuestionIndex].SetActive(true);
        previousQuestion = randomQuestionIndex;
    }
    private int getpreviousQuestion()
    {
        return previousQuestion;
    }
 

}
