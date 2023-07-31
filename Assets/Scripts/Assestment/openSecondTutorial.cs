using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openSecondTutorial : MonoBehaviour
{
    [SerializeField] private GameObject secondTutorialPanel;

    public void OpenSecondTutorialPanel()
    {
        Actions.MainMenuButtonSoundEffect?.Invoke();
        secondTutorialPanel.SetActive(true);
    }
}
