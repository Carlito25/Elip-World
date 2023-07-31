using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3DestroyBarrier : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject obstacleOutpost;
    [SerializeField] private GameObject itemIsNotEnoughPanel;
    [SerializeField] private AudioSource barrierDestroySoundEffect;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        Actions.onCloseLevel3NotifNotCompleteItem += closeItemIsNotEnoughPanel;
    }
    private void OnDisable()
    {
        Actions.onCloseLevel3NotifNotCompleteItem -= closeItemIsNotEnoughPanel;
    }
    private void obstacleOutpostAnimation()
    {
        anim.SetTrigger("destroy");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int cherries = Actions.onGetCollectibles.Invoke();

            if (cherries == 5 && Actions.onGetEnemyKilledCount.Invoke() == 5)
            {
                obstacleOutpostAnimation();
                barrierDestroySoundEffect.Play();
                Invoke("delayDestroy", .5f);
             

            }
            else if (cherries == 10 && Actions.onGetEnemyKilledCount.Invoke() == 10)
            {
                obstacleOutpostAnimation();
                barrierDestroySoundEffect.Play();
                Invoke("delayDestroy", .5f);
            }
            else if (cherries == 15 && Actions.onGetEnemyKilledCount.Invoke() == 15)
            {
                obstacleOutpostAnimation();
                barrierDestroySoundEffect.Play();
                Invoke("delayDestroy", .5f);

            }
            else if (cherries == 20 && Actions.onGetEnemyKilledCount.Invoke() == 20)
            {
                obstacleOutpostAnimation();
                barrierDestroySoundEffect.Play();
                Invoke("delayDestroy", .5f);

            }
            else if (cherries == 25 && Actions.onGetEnemyKilledCount.Invoke() == 25)
            {
                obstacleOutpostAnimation();
                barrierDestroySoundEffect.Play();
                Invoke("delayDestroy", .5f);

            }
            else
            {
                openItemIsNotEnoughPanel();
            }
        }
    }

    private void openItemIsNotEnoughPanel()
    {
        Actions.onCloseEnemyCompleted?.Invoke();
        Actions.onCloseNotifCompleteItem?.Invoke();
        itemIsNotEnoughPanel.SetActive(true);
        Invoke("closeItemIsNotEnoughPanel", 13f);
    }
    private void closeItemIsNotEnoughPanel()
    {
        itemIsNotEnoughPanel.SetActive(false);
    }
    private void delayDestroy()
    {
        destroyObstacleOutpost(obstacleOutpost);
        
    }
    private void destroyObstacleOutpost(GameObject ObstacleOutpost)
    {
        ObstacleOutpost.SetActive(false);
       
    }
}
