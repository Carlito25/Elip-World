using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float enemyStartingHealth;
    playerAttackAnimation PlayerAttackAnimation;
    enemyAttackAnimation EnemyAttackAnimation;
    randomGenerator RandomGenerator;
    QuestionBW QuestionBW;
    laserAnimation LaserAnim;
    [SerializeField] private GameObject EnemyIsDeadPanel;
    [SerializeField] private GameObject timerText;
    [SerializeField] private GameObject bossDiePanel;
    public float EnemycurrentHealth { get; private set; }
    
    private Animator anim;
    private Rigidbody2D rb;

    private void Awake()
    {
        PlayerAttackAnimation = GameObject.Find("Player").GetComponent<playerAttackAnimation>();
        EnemycurrentHealth = enemyStartingHealth;
        EnemyAttackAnimation = GameObject.Find("Enemy").GetComponent<enemyAttackAnimation>();
        RandomGenerator = GameObject.Find("Canvas").GetComponent<randomGenerator>();
        QuestionBW = GameObject.Find("Canvas").GetComponent<QuestionBW>();
        LaserAnim = GameObject.Find("Elip Laser").GetComponent<laserAnimation>();
    }
    public void bookwormEnemyTakeDamage(float _damage)
    {
        EnemycurrentHealth = Mathf.Clamp(EnemycurrentHealth - _damage, 0, enemyStartingHealth);
        if (EnemycurrentHealth > 0)
        {
            PlayerAttackAnimation.attackAnimation();
            PlayerAttackAnimation.idleAnimation();
            LaserAnim.playerLaserAnimation();
            EnemyAttackAnimation.enemyGetDamage();      
            RandomGenerator.getRandomQuestion(QuestionBW.questionsBookworm);
        }
        else
        {
            Invoke("activateEnemyDeadPanel", 2f);
            EnemyAttackAnimation.enemyDead();
            CountdownTimer.isTimeIsUp = true;
            timerText.SetActive(false);
            bossDiePanel.SetActive(true);
        }
    }

    private void activateEnemyDeadPanel()
    {
        EnemyIsDeadPanel.SetActive(true);
    }
}
