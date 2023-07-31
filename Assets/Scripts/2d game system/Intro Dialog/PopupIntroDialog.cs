using UnityEngine;

public class PopupIntroDialog : MonoBehaviour
{
    [SerializeField] private GameObject popupIntroDialogPanel;
    [SerializeField] private GameObject exitButton;

    [SerializeField] private GameObject removeIntroDialogObject;

    private bool isEnabledEscape;

   

    private void OnEnable()
    {
        Actions.onSetIsEnabledEscape += setIsEnabledEscape;
        Actions.onQuitIntroDialog += quitIntroDialog;
        
    }
    private void OnDisable()
    {
        Actions.onSetIsEnabledEscape -= setIsEnabledEscape;
        Actions.onQuitIntroDialog -= quitIntroDialog;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                openPopupIntroDialogPanel();        
                Actions.onFreezePosition?.Invoke();      
                gameObject.SetActive(false);    
        }    
    }

    private void openPopupIntroDialogPanel()
    {
        popupIntroDialogPanel.SetActive(true);
        isEnabledEscape = true;

    }
    public void quitIntroDialog()
    {
        Actions.MainMenuButtonSoundEffect?.Invoke();
        popupIntroDialogPanel.SetActive(false);
        //removeIntroDialogObject.SetActive(false);
        Actions.onEnabledMovePlayer?.Invoke();

        isEnabledEscape = false;
    }
    private bool setIsEnabledEscape()
    {
        return isEnabledEscape;
    }


}
