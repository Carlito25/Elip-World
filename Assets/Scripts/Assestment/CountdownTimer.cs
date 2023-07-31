using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
   private float currentTime = 0f;
    [SerializeField] private float startingTime;

    public static bool isTimeIsUp = false;
    [SerializeField] Text countdownText;
    [SerializeField] GameObject timeIsUpPanel;

  

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <=0)
        {
            currentTime = 0;
            
            timeIsUpPanel.SetActive(true);
            isTimeIsUp = true;
        }
    }

    public void LeaveAssestment()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Actions.onEnabledMovePlayer?.Invoke();
        
    }

}
