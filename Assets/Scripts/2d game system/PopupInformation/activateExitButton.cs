
using UnityEngine;

public class activateExitButton : MonoBehaviour
{
	private int firstInfoPopupOpen;
	[SerializeField] private float secondsOfDelay;

	[SerializeField] private GameObject exitButton;

	private bool isEnabledEscape;
	private bool isEnabledToChangeInfo = true;

	private void Awake()
	{
		firstInfoPopupOpen = 1;
	}

	private float getSecondsofDelay()
    {
		return secondsOfDelay;
    }
	private void onEnable()
	{
		Actions.onFirstCollideChecker += firstCollideChecker;
		Actions.onGetSecondsofDelay += getSecondsofDelay;
	}
	private void OnDisable()
	{
		Actions.onFirstCollideChecker -= firstCollideChecker;
		Actions.onGetSecondsofDelay -= getSecondsofDelay;
	}


	public void firstCollideChecker()
	{
		Debug.Log("first CollideChecker is called");

		if (firstInfoPopupOpen == 1)
		{
			Invoke("activeExitButton", secondsOfDelay);
			firstInfoPopupOpen++;
			
		}
		else
		{
			Actions.onPopupCollideAlready?.Invoke();
		}
	}

	public void activeExitButton()
	{
		exitButton.SetActive(true);
		isEnabledEscape = true;
		Actions.onDisabledInfoButtons();
		isEnabledToChangeInfo = true;
	}


}
