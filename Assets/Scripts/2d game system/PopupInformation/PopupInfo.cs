using UnityEngine;
using UnityEngine.UI;

public class PopupInfo : MonoBehaviour
{
    [SerializeField] private GameObject checkpointText;
    public static int numberOfCheckPoint;
    [SerializeField] private Button PauseButton;

    [SerializeField] private GameObject PopupInformationPanel;
    [SerializeField] private GameObject firstInfo;
    [SerializeField] private GameObject secondInfo;
    [SerializeField] private GameObject thirdInfo;
    [SerializeField] private GameObject fourthInfo;
    [SerializeField] private GameObject fifthInfo;

    [SerializeField] private GameObject firstInformation;
    [SerializeField] private GameObject secondInformation;
    [SerializeField] private GameObject thirdInformation;
    [SerializeField] private GameObject fourthInformation;
    [SerializeField] private GameObject fifthInformation;


    [SerializeField] private GameObject exitButton;

    private int checkPoint1IsCollide;
    private int checkPoint2IsCollide;
    private int checkPoint3IsCollide;
    private int checkPoint4IsCollide;
    private int checkPoint5IsCollide;








    [SerializeField] private GameObject firstObstacleOutpost, secondObstacleOutpost, thirdObstacleOutpost,fourthObstacleOutpost, fifthObstacleOutpost;
    [SerializeField] private GameObject firstOutpost, secondOutpost, thirdOutpost, fourthOutpost, fifthOutpost;

    
    private bool outpostIsTrigger;

    private Transform currentCheckpoint;
    private Health playerHealth;
    [SerializeField] private GameObject deadPopup;
    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        numberOfCheckPoint = 3;

        checkPoint1IsCollide  = 1;
        checkPoint2IsCollide = 1;
        checkPoint3IsCollide = 1;
        checkPoint4IsCollide = 1;
        checkPoint5IsCollide = 1;
    }



    private void OnEnable()
    {
        Actions.onGetCurrentCheckpoint += getCurrentCheckpoint;
        Actions.onGetOutpostIsTrigger += getOutpostIsTrigger;
        Actions.onQuitPopup += quitPopup;
    }
    private void OnDisable()
    {
        Actions.onGetCurrentCheckpoint -= getCurrentCheckpoint;
        Actions.onGetOutpostIsTrigger -= getOutpostIsTrigger;
        Actions.onQuitPopup -= quitPopup;
    }
    private Transform getCurrentCheckpoint()
    {
        return currentCheckpoint;
    }
    private bool getOutpostIsTrigger()
    {
        return outpostIsTrigger;
    }
    public void Respawn()
    {
            Actions.MainMenuButtonSoundEffect?.Invoke();
            PauseButton.interactable = true;
            transform.position = currentCheckpoint.position;
            playerHealth.Respawn(); //need to call the respawn function in health class to freeze the rotation and position, reset health and to run the transition to idle.
            deadPopup.SetActive(false);
            GetComponent<Collider2D>().enabled = true;
            --numberOfCheckPoint;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PopupInfo"))
        {
            currentCheckpoint = collision.transform;
            

            int cherries = Actions.onGetCollectibles.Invoke();

            if (cherries >= 5 && cherries <= 9)
            {
                Actions.onChangeCollectibleGoal?.Invoke();
                firstInfo.SetActive(true);         
                outpostIsTrigger = true;
                Actions.onChangeKilledCountGoal?.Invoke();

                if (checkPoint1IsCollide == 1)
                {
                    firstInformation.SetActive(true);
                    PopupInformationPanel.SetActive(true);
                    //exitButton.SetActive(true);
                    checkPoint1IsCollide = 2;
                    Actions.onFreezePosition?.Invoke();
                    activateCheckpointText();
                }
                else
                {
                    Actions.onEnabledMovePlayer();
                }

                

                



            }
            else if (cherries >= 10 && cherries <= 14)
            {
                Actions.onChangeCollectibleGoal?.Invoke();
                firstInfo.SetActive(true);
                secondInfo.SetActive(true);

                if (checkPoint2IsCollide == 1)
                {
                    secondInformation.SetActive(true);
                    PopupInformationPanel.SetActive(true);
                   // exitButton.SetActive(true);
                    Actions.onFreezePosition?.Invoke();
                    checkPoint2IsCollide = 2;
                    activateCheckpointText();
                }
                else
                {
                    Actions.onEnabledMovePlayer();
                }
               
                outpostIsTrigger = true;
                Actions.onChangeKilledCountGoal?.Invoke();

                

                

            }
            else if (cherries >= 15 && cherries <= 19)
            {
                Actions.onChangeCollectibleGoal?.Invoke();
                firstInfo.SetActive(true);
                secondInfo.SetActive(true);
                thirdInfo.SetActive(true);
           
                outpostIsTrigger = true;
                Actions.onChangeKilledCountGoal?.Invoke();

                if (checkPoint3IsCollide == 1)
                {
                    thirdInformation.SetActive(true);
                    PopupInformationPanel.SetActive(true);
                  // exitButton.SetActive(true);
                    Actions.onFreezePosition?.Invoke();
                    checkPoint3IsCollide = 2;
                    activateCheckpointText();
                }
                else
                {
                    Actions.onEnabledMovePlayer();
                }

                



            }
            else if (cherries >= 20 && cherries <= 24)
            {
                Actions.onChangeCollectibleGoal?.Invoke();
                firstInfo.SetActive(true);
                secondInfo.SetActive(true);
                thirdInfo.SetActive(true);
                fourthInfo.SetActive(true);
              
                outpostIsTrigger = true;
                Actions.onChangeKilledCountGoal?.Invoke();

                if (checkPoint4IsCollide == 1)
                {
                    fourthInformation.SetActive(true);
                    PopupInformationPanel.SetActive(true);
                    //exitButton.SetActive(true);
                    Actions.onFreezePosition?.Invoke();
                    checkPoint4IsCollide = 2;
                    activateCheckpointText();
                }
                else
                {
                    Actions.onEnabledMovePlayer();
                }

                

            }
            else if (cherries == 25)
            {
                Actions.onChangeCollectibleGoal?.Invoke();
                firstInfo.SetActive(true);
                secondInfo.SetActive(true);
                thirdInfo.SetActive(true);
                fourthInfo.SetActive(true);
                fifthInfo.SetActive(true);
                
                outpostIsTrigger = true;
                Actions.onChangeKilledCountGoal?.Invoke();

                if (checkPoint5IsCollide == 1)
                {
                    fifthInformation.SetActive(true);
                    PopupInformationPanel.SetActive(true);
                    //exitButton.SetActive(true);
                    Actions.onFreezePosition?.Invoke();
                    checkPoint5IsCollide = 2;
                    activateCheckpointText();
                }
                else
                {
                    Actions.onEnabledMovePlayer();
                }

                


            }
            else
            {
                //Popup Incomplete items
            }
           
        }
    }

    private void activateCheckpointText()
    {
        checkpointText.SetActive(true);
        Invoke("deactivivateCheckpointText", 2.5f);
    } 
    private void deactivivateCheckpointText()
    {
        checkpointText.SetActive(false);    
    }
  
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PopupInfo"))
        {
            //removeInfoButton();
            outpostIsTrigger = false;

            
            firstInformation.SetActive(false);
            secondInformation.SetActive(false);
            thirdInformation.SetActive(false);
            fourthInformation.SetActive(false);
            fifthInformation.SetActive(false);
            PopupInformationPanel.SetActive(false);
            Actions.onEnabledMovePlayer();
        }
    }
    public void quitPopup()
    {
        Actions.MainMenuButtonSoundEffect?.Invoke();
        PopupInformationPanel.SetActive(false);
        firstInformation.SetActive(false);
        secondInformation.SetActive(false);
        thirdInformation.SetActive(false);
        fourthInformation.SetActive(false);
        fifthInformation.SetActive(false);
        

        //firstInfo.SetActive(false);
        //secondInfo.SetActive(false);
        //thirdInfo.SetActive(false);
        //fourthInfo.SetActive(false);
        //fifthInfo.SetActive(false);

        Actions.onEnabledMovePlayer();
    }
    //public void removeInfoButton()
    //{
    //    PopupInformationPanel.SetActive(false);
    //    firstInfo.SetActive(false);
    //    secondInfo.SetActive(false);
    //    thirdInfo.SetActive(false);     
    //    fourthInfo.SetActive(false);     
    //    fifthInfo.SetActive(false);     
    //}
}
