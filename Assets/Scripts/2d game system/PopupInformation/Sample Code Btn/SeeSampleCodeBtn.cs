using UnityEngine;
using UnityEngine.UI;

public class SeeSampleCodeBtn : MonoBehaviour
{
   // [SerializeField] public Button PopupInformationButton;
    [SerializeField] public GameObject PopupInformationText;
    [SerializeField] public GameObject newPopupCodeText;
    [SerializeField] public GameObject exitButton;

    private void Start()
    {
        exitButton.SetActive(false);
    }


    public void seeSampleCode()
     {
        Actions.informationsSoundEffect?.Invoke();
        PopupInformationText.SetActive(false);
        newPopupCodeText.SetActive(true);
        Debug.Log("Sample code will show");
        exitButton.SetActive(true);
     }
    public void backToDescription()
    {
        Actions.informationsSoundEffect?.Invoke();
        PopupInformationText.SetActive(true);
        newPopupCodeText.SetActive(false);
        Debug.Log("description will show");
        exitButton.SetActive(false);
    }
}
