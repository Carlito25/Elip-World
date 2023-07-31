using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveNextButton : MonoBehaviour
{
    [SerializeField] private GameObject newNextLevelButton;
    [SerializeField] private GameObject oldNextLevelButton;

    void Start()
    {
        newNextLevelButton.SetActive(true);
        oldNextLevelButton.SetActive(false);
    }

    
}
