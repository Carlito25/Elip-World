using UnityEngine;
using UnityEngine.UI;

public class disabledCheckpointButton : MonoBehaviour
{
    [SerializeField] private Button restartCheckpoint;
    [SerializeField] private Text numberOfCheckpointText;


    
    private void Update()
    {
        

        if (PopupInfo.numberOfCheckPoint == 0 || Actions.onGetCurrentCheckpoint?.Invoke() == null)
        {
            restartCheckpoint.interactable = false;
            numberOfCheckpointText.text = "You are not allowed to restart to the checkpoint!";
        }
        else
        {
            numberOfCheckpointText.text = "Number of times you can return to the checkpoint: " + PopupInfo.numberOfCheckPoint;
        }
    }
}
