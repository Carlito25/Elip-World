using UnityEngine;
using EZCameraShake;

public class EnemyDamage : MonoBehaviour
{
    private Animator anim;
   [SerializeField] private int enemyKilled = 0;
    private bool enemyisDead;
    int numberOfHit = 0;
    private SpriteRenderer sr;
    private string enemyKilledGoalText = "/5";
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Fireball")
        {
            numberOfHit++;
            Debug.Log(numberOfHit);
            sr.color = Color.red;
            if (numberOfHit == 3)
            {
                enemyisDead = true;
                Actions.enemyDeadSoundEffect?.Invoke();
                anim.SetTrigger("dead");
                Actions.onGetEnemyKilledIncrement?.Invoke();
                Actions.onGetEnemyKilledText.Invoke().text = Actions.onGetEnemyKilledCount?.Invoke().ToString() + enemyKilledGoalText;
                Actions.onCheckEnemyKilledIsCompleted?.Invoke();
            }
            Invoke("enemeyTurnWhite", .2f);
            
            //enemyDeactivate();
            //CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);

        }
    }

    private void changeKilledCountGoal()
    {
        if (Actions.onGetEnemyKilledCount?.Invoke() >= 5 && Actions.onGetEnemyKilledCount?.Invoke() <= 9)
        {
            enemyKilledGoalText = "/10";
            Actions.onGetEnemyKilledText.Invoke().text = Actions.onGetEnemyKilledCount?.Invoke() + enemyKilledGoalText;
        }
        else if (Actions.onGetEnemyKilledCount?.Invoke() >= 10 && Actions.onGetEnemyKilledCount?.Invoke() <= 14)
        {
            enemyKilledGoalText = "/15";
            Actions.onGetEnemyKilledText.Invoke().text = Actions.onGetEnemyKilledCount?.Invoke() + enemyKilledGoalText;
        }
        else if (Actions.onGetEnemyKilledCount?.Invoke() >= 15 && Actions.onGetEnemyKilledCount?.Invoke() <= 19)
        {
            enemyKilledGoalText = "/20";
            Actions.onGetEnemyKilledText.Invoke().text = Actions.onGetEnemyKilledCount?.Invoke() + enemyKilledGoalText;
        }
        else if (Actions.onGetEnemyKilledCount?.Invoke() >= 20 && Actions.onGetEnemyKilledCount?.Invoke() <= 24)
        {
            enemyKilledGoalText = "/25";
            Actions.onGetEnemyKilledText.Invoke().text = Actions.onGetEnemyKilledCount?.Invoke() + enemyKilledGoalText;
        }
    }

    
    private void enemeyTurnWhite()
    {
        sr.color = Color.white;
    }


    public void enemyDeactivate()
    {  
        gameObject.SetActive(false);
        //Actions.onSetEnemySpeed.Invoke(0f);
    }

    private bool isEnemyIsDead()
    {
        return enemyisDead;
    }

    private void OnEnable()
    {
        Actions.onSetEnemySpeed += isEnemyIsDead;
        Actions.onChangeKilledCountGoal += changeKilledCountGoal;
    }
    private void OnDisable()
    {
        Actions.onSetEnemySpeed -= isEnemyIsDead;
        Actions.onChangeKilledCountGoal -= changeKilledCountGoal;
    }




}
