using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class checkStages : MonoBehaviour
{
    randomGenerator RandomGenerator;

    private void Awake()
    {
        RandomGenerator = GameObject.Find("Canvas").GetComponent<randomGenerator>();
    }
    
    public void nextStage(int currentStages, int maximumStages, List<GameObject> questionsList, Text Stages)
    {
        if (currentStages == maximumStages) //maximum question is 2
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            addStages(currentStages,Stages);
            RandomGenerator.getRandomQuestion(questionsList);
        }
    }
    public void addStages(int currentStages, Text stages)
    {
        currentStages++;
        stages.text = currentStages.ToString() + "/5";
    }
}
