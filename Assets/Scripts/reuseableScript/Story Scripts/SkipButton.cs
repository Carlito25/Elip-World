
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{
    public void skipStory()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Actions.onEnabledMovePlayer?.Invoke();
    }
}
