using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    

    [SerializeField] private int collectibles = 0;

    [SerializeField] private Text collectiblesText;

    private string collectiblesGoalText = "/5";

    [SerializeField] private AudioSource CollectSoundEffect;

    [SerializeField] private GameObject itemIsCompleteDialogue;

    [SerializeField] private GameObject itemIsCompleteDialogueFace;

    [SerializeField] private float notifExitSeconds;

    private void OnEnable()
    {
        Actions.onGetCollectibles += getCherries;
        Actions.onChangeCollectibleGoal += changeCollectibleGoal;
        Actions.onCloseNotifAudio += closeDialogueFace;

        Actions.onCloseNotifCompleteItem += closeDialogueFace;
    }
    private void OnDisable()
    {
        Actions.onGetCollectibles -= getCherries;
        Actions.onChangeCollectibleGoal -= changeCollectibleGoal;
        Actions.onCloseNotifAudio -= closeDialogueFace;

        Actions.onCloseNotifCompleteItem -= closeDialogueFace;
    }
    private int getCherries() 
    {
        return collectibles;
    }
    
      
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Cherry"))
        {
            CollectSoundEffect.Play();
            Destroy(collision.gameObject);

            //collision.gameObject.SetActive(false);
            

            collectibles++;
            checkCollectiblesIfCompleted();
            // changeCollectibleGoal();
            collectiblesText.text = collectibles + collectiblesGoalText;
        }
    }
    private void changeCollectibleGoal()
    { 
        if (collectibles >= 5 && collectibles <= 9)
        {
            collectiblesGoalText = "/10";
            collectiblesText.text = collectibles + collectiblesGoalText;

        }
        else if (collectibles >= 10 && collectibles <= 14)
        {
            collectiblesGoalText = "/15";
            collectiblesText.text = collectibles + collectiblesGoalText;
        }
        else if (collectibles >= 15 && collectibles <= 19)
        {
            collectiblesGoalText = "/20";
            collectiblesText.text = collectibles + collectiblesGoalText;
        }
        else if (collectibles >= 20 && collectibles <=24)
        {
            collectiblesGoalText = "/25";
            collectiblesText.text = collectibles + collectiblesGoalText;
        }
    }
    private void checkCollectiblesIfCompleted()
    {
        if (collectibles == 5)
        {

            // Actions.onFreezePosition?.Invoke();
            Actions.onCloseLevel3NotifNotCompleteItem?.Invoke();
            Actions.onCloseEnemyCompleted?.Invoke();

            itemIsCompleteDialogue.SetActive(true);
            Actions.onCloseNotifNotCompleteItem?.Invoke();
            Invoke("closeDialogue", notifExitSeconds);
        }
        else if (collectibles == 10 || collectibles == 15 || collectibles == 20 || collectibles == 25)
        {
            Actions.onCloseNotifNotCompleteItem?.Invoke();
            Actions.onCloseLevel3NotifNotCompleteItem?.Invoke();
            Actions.onCloseEnemyCompleted?.Invoke();

            itemIsCompleteDialogueFace.SetActive(true);
            Invoke("closeDialogueFace", notifExitSeconds);
        } 
    }

    public void closeDialogue()
    {
        itemIsCompleteDialogue.SetActive(false);
        Actions.onEnabledMovePlayer?.Invoke();
    }
    public void closeDialogueFace()
    {
        itemIsCompleteDialogueFace.SetActive(false);
        //Actions.onEnabledMovePlayer?.Invoke();
    }


}
