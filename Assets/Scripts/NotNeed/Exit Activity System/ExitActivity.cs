using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitActivity : MonoBehaviour
{
    private PopupInfo exitActivity;

    private void Awake()
    {
        exitActivity = GetComponent<PopupInfo>();
    }

    public void backToCheckpoint()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        
    }
}
