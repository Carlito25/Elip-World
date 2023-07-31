using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void goToGameMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameMenu");
    }
}
