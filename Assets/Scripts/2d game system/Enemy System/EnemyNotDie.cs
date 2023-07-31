using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNotDie : MonoBehaviour
{
    private SpriteRenderer sr;
    private void Awake()
    {
      
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Fireball")
        {
            
            sr.color = Color.red;
            Invoke("enemeyTurnWhite", .2f);

            //enemyDeactivate();
            //CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        }
    }
    private void enemeyTurnWhite()
    {
        sr.color = Color.white;
    }
}
