using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject settingUI;
    [SerializeField] private GameObject tutorialUI;
    [SerializeField] private AudioSource clickSoundEffect;
    [SerializeField] private AudioSource inventorySoundEffect;
    [SerializeField] private AudioSource informationsSoundEffect;


    private void OnEnable()
    {
        Actions.MainMenuButtonSoundEffect += ClickSoundEffect;
        Actions.InventorySoundEffect += InventorySoundEffect;
        Actions.informationsSoundEffect += InformationsSoundEffect;
    }
    private void OnDisable()
    {
        Actions.MainMenuButtonSoundEffect -= ClickSoundEffect;
        Actions.InventorySoundEffect -= InventorySoundEffect;
        Actions.informationsSoundEffect -= InformationsSoundEffect;
    }

    public void CompleteLevel()
    {
        Actions.MainMenuButtonSoundEffect?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Actions.onEnabledMovePlayer?.Invoke();
        CountdownTimer.isTimeIsUp = false;
    }

    public void goToLevel2()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level 2");
    }

    public void goToLevel3()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level 3");
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void resetProgress()
    {
        PlayerPrefs.DeleteAll();
    }
    public void quitButton()
    {
        Application.Quit();
    }

    public void gotoMainMenuCanvas()
    {
        mainMenuUI.SetActive(true);
        settingUI.SetActive(false);
        tutorialUI.SetActive(false);
    }
    public void gotoTutorialCanvas()
    {
        mainMenuUI.SetActive(false);
        tutorialUI.SetActive(true);
    }
    public void gotoSettings()
    {
        mainMenuUI.SetActive(false);
        settingUI.SetActive(true);
    }
    public void ClickSoundEffect()
    {
        clickSoundEffect.Play();
    }
    public void InventorySoundEffect()
    {
        inventorySoundEffect.Play();
    }
    public void InformationsSoundEffect()
    {
        informationsSoundEffect.Play();
    }




}
