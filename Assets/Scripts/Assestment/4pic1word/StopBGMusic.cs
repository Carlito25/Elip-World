using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBGMusic : MonoBehaviour
{
    [SerializeField] private AudioSource BGMusic;

    // Update is called once per frame
    void Update()
    {
        if (CountdownTimer.isTimeIsUp == true)
        {
            BGMusic.Stop();      
        }
    }
}
