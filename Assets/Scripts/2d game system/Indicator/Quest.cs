using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{

    public QuestArrow arrow;

   
    private void Update()
    {
        onQuestClick();
    }

    public void onQuestClick()
    {

        arrow.gameObject.SetActive(true);

        //arrow.target = this.transform;
     
            for (int i = 0; i < arrow.collectibles.Count; i++)
            {    
                    arrow.target = arrow.collectibles[i].transform;           
            }
            
     }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            arrow.collectibles.Remove(gameObject);
        }
    }
}

