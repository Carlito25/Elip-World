using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Animator transitionAnim;
    [SerializeField] private GameObject nextLevelPopup;
    private int nextSceneLoad;

    private void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2f);     
        
        // AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level 1");

        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            Debug.Log("Game is Done");
        }
        else
        {
            SceneManager.LoadScene(nextSceneLoad);
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }
        
    }

    
    public void nextLevel()
    {
        nextLevelPopup.SetActive(false);
        StartCoroutine(LoadScene());
        Actions.onEnabledMovePlayer?.Invoke();
        CountdownTimer.isTimeIsUp = false;

    }


    

    

}
