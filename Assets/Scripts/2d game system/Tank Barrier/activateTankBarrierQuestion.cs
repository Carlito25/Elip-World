using UnityEngine;

public class activateTankBarrierQuestion : MonoBehaviour
{
    

    [SerializeField] private GameObject barrierQuestionPanel;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            barrierQuestionPanel.SetActive(true);
            Actions.onFreezePosition?.Invoke();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           // RandomGenerator.getRandomQuestion(itemBarrierQuiz1.questions4Pic1Word);
            //
        }
    }

    public void quitQuestion()
    {
        barrierQuestionPanel.SetActive(false);
        Actions.onEnabledMovePlayer();
    }

    

   
}

