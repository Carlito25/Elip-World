using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyKilledCount : MonoBehaviour
{

    [SerializeField] private int enemyKilled = 0;

    [SerializeField] private Text enemyKilledText;

    [SerializeField] private GameObject enemyKilledIsCompleteDialogueFace;

    private void OnEnable()
    {
        Actions.onGetEnemyKilledText += getenemyKilledText;
        Actions.onGetEnemyKilledCount += getenemyKilledCount;
        Actions.onGetEnemyKilledIncrement += enemyKilledIncrement;
        Actions.onCheckEnemyKilledIsCompleted += checkEnemyKilledIfCompleted;
        Actions.onCloseEnemyCompleted += closeEnemyKilledIsCompleteDialogueFace;
    }
    private void OnDisable()
    {
        Actions.onGetEnemyKilledText -= getenemyKilledText;
        Actions.onGetEnemyKilledCount -= getenemyKilledCount;
        Actions.onGetEnemyKilledIncrement -= enemyKilledIncrement;
        Actions.onCheckEnemyKilledIsCompleted -= checkEnemyKilledIfCompleted;
        Actions.onCloseEnemyCompleted -= closeEnemyKilledIsCompleteDialogueFace;

    }
    private Text getenemyKilledText()
    {
        return enemyKilledText;
    }

    private int getenemyKilledCount()
    {
        
        return enemyKilled;
    }
    private int enemyKilledIncrement()
    {
        enemyKilled++;
        return enemyKilled;
    }
    private void checkEnemyKilledIfCompleted()
    {
        if (Actions.onGetEnemyKilledCount?.Invoke() == 5 || Actions.onGetEnemyKilledCount?.Invoke() == 10 || Actions.onGetEnemyKilledCount?.Invoke() == 15 || Actions.onGetEnemyKilledCount?.Invoke() == 20 || Actions.onGetEnemyKilledCount?.Invoke() == 25)
        {
            openEnemyKilledIsCompleteDialogueFace();
        }
    }

    private void openEnemyKilledIsCompleteDialogueFace()
    {
        Actions.onCloseNotifCompleteItem?.Invoke();
        Actions.onCloseLevel3NotifNotCompleteItem?.Invoke();
        enemyKilledIsCompleteDialogueFace.SetActive(true);
        Invoke("closeEnemyKilledIsCompleteDialogueFace", 11f);
    }
    private void closeEnemyKilledIsCompleteDialogueFace()
    {
        enemyKilledIsCompleteDialogueFace.SetActive(false);
    }


}
