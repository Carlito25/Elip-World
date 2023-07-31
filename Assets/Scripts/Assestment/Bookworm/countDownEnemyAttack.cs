using UnityEngine;
using UnityEngine.UI;
public class countDownEnemyAttack : MonoBehaviour
{
    private float currentTime = 0f;
    [SerializeField] private float startingTime;
    playerBookWormHealth PlayerBookWormHealth;

    public static bool isTimeIsUp = false;
    [SerializeField] Text countdownText;

    private void Awake()
    {
        PlayerBookWormHealth = GameObject.Find("Main Camera").GetComponent<playerBookWormHealth>();
    }
  
    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            Actions.BWBossAttackSoundEffect?.Invoke();
            PlayerBookWormHealth.bookwormTakeDamage(.5f);
            currentTime = 5;
        }

    }

    //private void OnEnable()
    //{
    //    Actions.onGetbossTimerAttack += bossTimerAttack;
    //}
    //private void OnDisable()
    //{
    //    Actions.onGetbossTimerAttack -= bossTimerAttack;
    //}


    //private float bossTimerAttack()
    //{
    //    return currentTime;
    //}



}
