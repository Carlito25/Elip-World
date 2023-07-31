using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLaserTrap : MonoBehaviour
{
    [SerializeField] private GameObject laser;

    private void Start()
    {
        activateLaserTrap();
    }
    private void activateLaserTrap()
    {
        laser.SetActive(true);
        Invoke("deactivateLaserTrap", 2f);
    }
    private void deactivateLaserTrap()
    {
        laser.SetActive(false);
        Invoke("activateLaserTrap", 1f);
    }
}
