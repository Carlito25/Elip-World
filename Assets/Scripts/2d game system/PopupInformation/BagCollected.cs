using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagCollected : MonoBehaviour
{
    [SerializeField] private GameObject bagButton;
    public static bool bagIsCollected = false;

    private void Start()
    {
        if (bagIsCollected == true)
        {
            bagButton.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            bagButton.SetActive(true);
            bagIsCollected = true;
        }
    }
}
