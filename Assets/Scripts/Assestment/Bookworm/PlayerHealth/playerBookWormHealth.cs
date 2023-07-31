using System;
using UnityEngine;

public class playerBookWormHealth : MonoBehaviour
{
    [SerializeField] private float playerStartingHealth;
    randomGenerator RandomGenerator;
    QuestionBW questionBW;
    public static event Action onEnemyAttack;
    [SerializeField] private GameObject PlayerIsDead;
    public float playerCurrentHealth { get; private set; }
    private void Awake()
    {
        RandomGenerator = GameObject.Find("Canvas").GetComponent<randomGenerator>();
        questionBW = GameObject.Find("Canvas").GetComponent<QuestionBW>();
        playerCurrentHealth = playerStartingHealth;
    }

    public void bookwormTakeDamage(float _damage)
    {
        playerCurrentHealth = Mathf.Clamp(playerCurrentHealth - _damage, 0, playerStartingHealth);

        if (playerCurrentHealth > 0)
        { 
            onEnemyAttack?.Invoke();
            RandomGenerator.getRandomQuestion(questionBW.questionsBookworm);
        }
        else
        {
            PlayerIsDead.SetActive(true);
        }
    }

}
