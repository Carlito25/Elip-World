using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; //drag the 2 waypoint object
    private int currentWaypointIndex = 0;
    private SpriteRenderer sprite;

    [SerializeField] private float speed = 2f;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            sprite.flipX = false;
            currentWaypointIndex++;

            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
                sprite.flipX = true;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
