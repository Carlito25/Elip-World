using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playVoiceRecord : MonoBehaviour
{
    [SerializeField] private GameObject voiceRecPanel;

    public void activateVoiceRec()
    {
        Actions.onCloseNotifNotCompleteItem?.Invoke();
        Actions.onCloseLevel3NotifNotCompleteItem?.Invoke();
        Actions.onCloseEnemyCompleted?.Invoke();
        Actions.onCloseNotifAudio?.Invoke();
        voiceRecPanel.SetActive(true);
        // Actions.onFreezePosition?.Invoke();
   
    }

    public void deactivateVoiceRec()
    {
        voiceRecPanel.SetActive(false);
        Debug.Log("deactive notif");
       // Actions.onEnabledMovePlayer?.Invoke();
    }



}
