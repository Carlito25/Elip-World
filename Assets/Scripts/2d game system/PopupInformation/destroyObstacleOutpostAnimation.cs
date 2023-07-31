using UnityEngine;

public class destroyObstacleOutpostAnimation : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject obstacleOutpost, outpost;
    [SerializeField] private GameObject itemIsNotEnoughPanel;
    [SerializeField] private AudioSource barrierDestroySoundEffect;

    void Start()
    {
        anim = GetComponent<Animator>();
    }  
    private void obstacleOutpostAnimation()
    {
        anim.SetTrigger("destroy");
    }
    private void OnEnable()
    {
        Actions.onCloseNotifAudio += closeItemIsNotEnoughPanel;
        Actions.onCloseNotifNotCompleteItem += closeItemIsNotEnoughPanel;
    }
    private void OnDisable()
    {
        Actions.onCloseNotifAudio -= closeItemIsNotEnoughPanel;
        Actions.onCloseNotifNotCompleteItem -= closeItemIsNotEnoughPanel;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int cherries = Actions.onGetCollectibles.Invoke();

            if (cherries == 5)
            {
               obstacleOutpostAnimation();
               barrierDestroySoundEffect.Play();
               Invoke("delayDestroy", .5f);

            }
             else if (cherries == 10)
            {
                obstacleOutpostAnimation();
                barrierDestroySoundEffect.Play();
                Invoke("delayDestroy", .5f);
            }
            else if (cherries == 15 )
            {
                obstacleOutpostAnimation();
                barrierDestroySoundEffect.Play();
                Invoke("delayDestroy", .5f);

            }
            else if (cherries == 20 )
            {
                obstacleOutpostAnimation();
                barrierDestroySoundEffect.Play();
                Invoke("delayDestroy", .5f);

            }
            else if (cherries == 25 )
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
        Actions.onCloseLevel3NotifNotCompleteItem?.Invoke();
        Actions.onCloseNotifCompleteItem?.Invoke();
        itemIsNotEnoughPanel.SetActive(true);
        Invoke("closeItemIsNotEnoughPanel",10f);
    }
    private void closeItemIsNotEnoughPanel()
    {
        itemIsNotEnoughPanel.SetActive(false);
    }
    private void delayDestroy()
    {
        destroyObstacleOutpost(obstacleOutpost, outpost);
    }
    private void destroyObstacleOutpost(GameObject ObstacleOutpost, GameObject Outpost)
    {
        ObstacleOutpost.SetActive(false);
        Outpost.SetActive(true);
    }
   
}
