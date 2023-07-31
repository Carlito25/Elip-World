using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private EnemyHealth EnemyHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
        totalHealthBar.fillAmount = EnemyHealth.EnemycurrentHealth / 10;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = EnemyHealth.EnemycurrentHealth / 10;
    }
}
