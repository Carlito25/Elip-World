using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    [SerializeField] public Transform player;

    private void Update()
    {
        transform.position = new Vector3(player.position.x + .7f, player.position.y +.7f , transform.position.z);
    }
}
