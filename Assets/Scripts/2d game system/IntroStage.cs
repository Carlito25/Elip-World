using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroStage : MonoBehaviour
{
    [SerializeField] private GameObject IntroStagePanel;

    private void Start()
    {
        Actions.onFreezePosition?.Invoke();
    }
    public void closeIntroStage()
    {
        Actions.MainMenuButtonSoundEffect?.Invoke();
        IntroStagePanel.SetActive(false);
        Actions.onEnabledMovePlayer?.Invoke();
    }

}
