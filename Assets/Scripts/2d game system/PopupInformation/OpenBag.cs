using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBag : MonoBehaviour
{
    [SerializeField] private GameObject bagPanel;
    public static bool bagIsOpened = false;

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab) && BagCollected.bagIsCollected == true)
        {
            if (bagIsOpened)
            {
                closeBag();
            }
            else
            {
                openBag();
            }
        }
        
    }

    public void openBag()
    {
        Actions.InventorySoundEffect?.Invoke();
        bagPanel.SetActive(true);
        //Actions.onFreezePosition();
        Time.timeScale = 0f;
        bagIsOpened = true;
    }

    public void closeBag()
    {
        Actions.InventorySoundEffect?.Invoke();
        bagPanel.SetActive(false);
        // Actions.onEnabledMovePlayer();
        Time.timeScale = 1f;
        bagIsOpened = false;
    }
}
