using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject popUpToNextLevel;
    [SerializeField] private GameObject TutorialPanel;


    private bool levelCompleted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            Actions.onFreezePosition?.Invoke();
            popUpToNextLevel.SetActive(true);
            //    finishSound.Play();
            //    levelCompleted = true;
            //    Invoke("CompleteLevel", 2f);
        }
    }
    

    public void nextLevel()
    {
        Invoke("CompleteLevel", 2f);
    }
    private void CompleteLevel()
    {
        Actions.MainMenuButtonSoundEffect?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void noButtonNextLevelPopup() 
    {
        Actions.MainMenuButtonSoundEffect?.Invoke();
        popUpToNextLevel.SetActive(false);
        Actions.onEnabledMovePlayer();
    }

    public void openTutorial()
    {
        Actions.MainMenuButtonSoundEffect?.Invoke();
        TutorialPanel.SetActive(true);
    }
}
