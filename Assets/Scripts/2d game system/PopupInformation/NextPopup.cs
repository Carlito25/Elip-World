using UnityEngine;
using UnityEngine.UI;

public class NextPopup : MonoBehaviour
{
	
	private int firstInfoPopupOpen;
	private int secondInfoPopupOpen;
	private int thirdInfoPopupOpen;
	private int fourthInfoPopupOpen;
	private int fifthInfoPopupOpen;

	[SerializeField] private GameObject popupInformationPanel;

	[SerializeField] private GameObject firstInformation;
	[SerializeField] private GameObject secondInformation;
	[SerializeField] private GameObject thirdInformation;

	[SerializeField] private GameObject fourthInformation;
	[SerializeField] private GameObject fifthInformation;
	

	[SerializeField] private Button[] infoButton;

	[SerializeField] private GameObject exitButton;

	[SerializeField] private AudioSource openPopUpSoundEffect;

	private bool isEnabledEscape;
	private bool isEnabledToChangeInfo = true;

	private void Awake()
	{
		firstInfoPopupOpen = 1;
		secondInfoPopupOpen = 1;
		thirdInfoPopupOpen = 1;
		fourthInfoPopupOpen = 1;
		fifthInfoPopupOpen = 1;
	}

    private void onEnable()
    {
		Actions.onPopupCollideAlready += collideAlready;
		Actions.onDisabledInfoButtons += disabledInfoButtons;
    }
	private void OnDisable()
	{
		Actions.onPopupCollideAlready -= collideAlready;
		Actions.onDisabledInfoButtons -= disabledInfoButtons;
	}

	private void Update()
    {
		if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (/*Actions.onGetOutpostIsTrigger?.Invoke() == true &&*/ Actions.onGetCollectibles.Invoke() >= 5 && Actions.onGetCollectibles.Invoke() <= 25 && 
				isEnabledToChangeInfo == true && OpenBag.bagIsOpened == true)
            {
				isEnabledToChangeInfo = false;
				Info1();
			}
        }
		else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
			if (/*Actions.onGetOutpostIsTrigger?.Invoke() == true &&*/ Actions.onGetCollectibles.Invoke() >= 10 && Actions.onGetCollectibles.Invoke() <= 25 && isEnabledToChangeInfo == true
				&& OpenBag.bagIsOpened == true)
			{
				isEnabledToChangeInfo = false;
				Info2();
			}
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			if (/*Actions.onGetOutpostIsTrigger?.Invoke() == true &&*/ Actions.onGetCollectibles.Invoke() >= 15 && Actions.onGetCollectibles.Invoke() <= 25 && isEnabledToChangeInfo == true
				&& OpenBag.bagIsOpened == true)
			{
				isEnabledToChangeInfo = false;
				Info3();
			}
        }
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			if (/*Actions.onGetOutpostIsTrigger?.Invoke() == true &&*/ Actions.onGetCollectibles.Invoke() >= 20 && Actions.onGetCollectibles.Invoke() <= 25 && isEnabledToChangeInfo == true
				&& OpenBag.bagIsOpened == true)
			{
				isEnabledToChangeInfo = false;
				Info4();
			}
        }
		else if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			if (/*Actions.onGetOutpostIsTrigger?.Invoke() == true && */ Actions.onGetCollectibles.Invoke() >= 25 && Actions.onGetCollectibles.Invoke() <= 25 && isEnabledToChangeInfo == true
				&& OpenBag.bagIsOpened == true)
			{
				isEnabledToChangeInfo = false;
				Info5();
			}
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
			if (/*Actions.onGetOutpostIsTrigger?.Invoke() == true &&*/ isEnabledEscape == true)
			{
				isEnabledEscape = false;
				Actions.onQuitPopup?.Invoke();

			}

            if (Actions.onSetIsEnabledEscape?.Invoke() == true)
            {
                Actions.onQuitIntroDialog?.Invoke();
            }
        }
	}

	public void Info1()
	{
		

		popupInformationPanel.SetActive(true);
		firstInformation.SetActive(true);

		secondInformation.SetActive(false);
		thirdInformation.SetActive(false);
		fourthInformation.SetActive(false);
		fifthInformation.SetActive(false);

		exitButton.SetActive(false);

		Actions.onFreezePosition();

		disabledInfoButtons();
		isEnabledEscape = false;

        //Actions.onFirstCollideChecker?.Invoke(); not working

        if (firstInfoPopupOpen == 1)
        {
            
			activeExitButton();
            firstInfoPopupOpen++;
        }
        else
        {
            collideAlready();
        }
    }
	public void Info2()
	{

		popupInformationPanel.SetActive(true);
		secondInformation.SetActive(true);

		firstInformation.SetActive(false);
		thirdInformation.SetActive(false);
		fourthInformation.SetActive(false);
		fifthInformation.SetActive(false);

		exitButton.SetActive(false);

		Actions.onFreezePosition();

		disabledInfoButtons();
		isEnabledEscape = false;

        if (secondInfoPopupOpen == 1)
        {
			activeExitButton();
			secondInfoPopupOpen++;
        }
        else
        {
			collideAlready();
		}
    }
	public void Info3()
	{

		popupInformationPanel.SetActive(true);
		thirdInformation.SetActive(true);

		fifthInformation.SetActive(false);
		secondInformation.SetActive(false);
		firstInformation.SetActive(false);
		fourthInformation.SetActive(false);

		exitButton.SetActive(false);

		Actions.onFreezePosition();

		disabledInfoButtons();
		isEnabledEscape = false;

        if (thirdInfoPopupOpen == 1)
        {
			activeExitButton();
			thirdInfoPopupOpen++;
        }
        else
        {
			collideAlready();
		} 
	}
	public void Info4()
	{

		popupInformationPanel.SetActive(true);
		fourthInformation.SetActive(true);

		fifthInformation.SetActive(false);
		thirdInformation.SetActive(false);
		secondInformation.SetActive(false);
		firstInformation.SetActive(false);

		exitButton.SetActive(false);

		Actions.onFreezePosition();

		disabledInfoButtons();
		isEnabledEscape = false;

        if (fourthInfoPopupOpen == 1)
        {
			activeExitButton();
			fourthInfoPopupOpen++;
        }
        else
        {
			collideAlready();
		} 
	}
	public void Info5()
	{

		popupInformationPanel.SetActive(true);
		fifthInformation.SetActive(true);
		
		fourthInformation.SetActive(false);
		thirdInformation.SetActive(false);
		secondInformation.SetActive(false);
		firstInformation.SetActive(false);

		exitButton.SetActive(false);

		Actions.onFreezePosition();

		disabledInfoButtons();
		isEnabledEscape = false;

        if (fifthInfoPopupOpen == 1)
        {
			activeExitButton();
			fifthInfoPopupOpen++;
        }
        else
        {
			collideAlready();
		} 
	}





	public void collideAlready()
    {
			enabledInfoButtons();
			exitButton.SetActive(true);
			isEnabledEscape = true;
			isEnabledToChangeInfo = true;
	}
	public void activeExitButton()
    {
		exitButton.SetActive(true);
		isEnabledEscape = true;
		enabledInfoButtons();
		isEnabledToChangeInfo = true;	
	}
	public void disabledInfoButtons()
    {
		infoButton[0].interactable = false;
		infoButton[1].interactable = false;
		infoButton[2].interactable = false;
		infoButton[3].interactable = false;
		infoButton[4].interactable = false;
	}
	public void enabledInfoButtons()
	{
		infoButton[0].interactable = true;
		infoButton[1].interactable = true;
		infoButton[2].interactable = true;
		infoButton[3].interactable = true;
		infoButton[4].interactable = true;
	}
}




