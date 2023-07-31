using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    public static bool GameIsPaused = false;

    private void Update()
    {
        if (Actions.onGetPlayerHealth?.Invoke() == 0f)
        {
            return;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                if (GameIsPaused)
                {
                    resumeGame();
                }
                else
                {
                    pauseGame();
                }
            }
        }
    }
    public void pauseGame()
    {
        Actions.MainMenuButtonSoundEffect?.Invoke();
        GameIsPaused = true;
        Actions.onFreezePosition?.Invoke();
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

 

    public void resumeGame()
    {
        Actions.MainMenuButtonSoundEffect?.Invoke();
        Actions.onEnabledMovePlayer();
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        GameIsPaused = false;

    }

    public void goToMainMenuScene()
    {
        Actions.MainMenuButtonSoundEffect?.Invoke();
        Time.timeScale = 1f;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameMenu");
        Actions.onEnabledMovePlayer();
        GameIsPaused = false;
    }
    private void delayGoToMainMenuScene()
    {
        Time.timeScale = 1f;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameMenu");
        Actions.onEnabledMovePlayer();
        GameIsPaused = false;
    }
}
