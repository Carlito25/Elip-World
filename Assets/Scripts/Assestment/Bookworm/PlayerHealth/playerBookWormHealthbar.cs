using UnityEngine;
using UnityEngine.UI;

public class playerBookWormHealthbar : MonoBehaviour
{
    [SerializeField] private playerBookWormHealth playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    private void Start()
    {
        totalHealthBar.fillAmount = playerHealth.playerCurrentHealth / 10;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.playerCurrentHealth / 10;
    }

}
