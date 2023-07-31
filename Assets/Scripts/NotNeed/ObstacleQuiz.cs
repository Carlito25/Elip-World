using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleQuiz : MonoBehaviour
{
    [SerializeField] private AudioSource DeathSoundEffect;
    [SerializeField] private AudioSource quizCorrect;
    [SerializeField] private AudioSource objectDestroy;

    private Health health;

    [SerializeField] GameObject obstaclePopup;
    [SerializeField] GameObject obstaclePopup2;
    [SerializeField] GameObject obstaclePopup3;
    [SerializeField] GameObject obstaclePopup4;

    [SerializeField] InputField  fillInTheBlanks;

    [SerializeField] GameObject wrongAnswer;

    
    [SerializeField] GameObject obstacle;
    [SerializeField]  Text obstacleQuestion;
    

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            obstaclePopup.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            obstaclePopup.SetActive(false);

        }
    }


    public void quitObstacleQuiz ()
    {
        obstaclePopup.SetActive(false);
        obstaclePopup2.SetActive(false);
        obstaclePopup3.SetActive(false);
        obstaclePopup4.SetActive(false);
        wrongAnswer.SetActive(false);
    }
    public void correctAnswer1()
    {
        obstaclePopup.SetActive(false);
        obstaclePopup2.SetActive(true);
        quizCorrect.Play();
    }
    public void correctAnswer2()
    {
        obstaclePopup2.SetActive(false);
        obstaclePopup3.SetActive(true);
        quizCorrect.Play();
    }
    public void correctAnswer3()
    {
        obstaclePopup3.SetActive(false);
        obstaclePopup4.SetActive(true);
        quizCorrect.Play();
    }
    public void WrongAnswer()
    {
        obstaclePopup.SetActive(false);
        obstaclePopup2.SetActive(false);
        obstaclePopup3.SetActive(false);
        obstaclePopup4.SetActive(false);
        wrongAnswer.SetActive(true);
        DeathSoundEffect.Play();
    }

    public void destroyObject()
    {
        quizCorrect.Play();
        obstaclePopup3.SetActive(false);
        Destroy(GameObject.FindWithTag("Obstacle"), 1f);
        Invoke("destroyObjectSound", 1f);
    }
    public void destroyObjectSound()
    {
        objectDestroy.Play();
    }

    public void fillintheBlanks()
    { 
        if (fillInTheBlanks.text == "int firstNum = 90;")
        {
            obstaclePopup4.SetActive(false);
            destroyObject();
        }
        else
        {
            WrongAnswer();
            GetComponent<Health>().TakeDamage(1);
        }
    }

}
