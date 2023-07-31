using UnityEngine;

public class InformationShortcuts : MonoBehaviour
{
    private NextPopup shortcuts;

    private void Awake()
    {
        shortcuts = GetComponent<NextPopup>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            shortcuts.Info1();
        }
    }
}
