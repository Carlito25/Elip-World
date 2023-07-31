using UnityEngine;

public class enemyWaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; //drag the 2 waypoint object
    private int currentWaypointIndex = 0;
    private SpriteRenderer sprite;

    [SerializeField] private float enemySpeed = 2f;
    
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            transform.localScale = new Vector3(2, transform.localScale.y, transform.localScale.z);
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
                transform.localScale = new Vector3(-2, transform.localScale.y, transform.localScale.z);
            }
        }
        if (Actions.onSetEnemySpeed.Invoke())
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * 0f);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * enemySpeed);
        }
    }
}
