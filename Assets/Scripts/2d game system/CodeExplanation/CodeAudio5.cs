using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeAudio5 : MonoBehaviour
{
    [SerializeField] private AudioSource[] voiceRec;


 
    public void playAudio1()
    {
        voiceRec[0].Play();

        voiceRec[1].Stop();
        voiceRec[2].Stop();
        voiceRec[3].Stop();
 

        Actions.onCloseNotifAudio?.Invoke();
    }

    public void playAudio2()
    {
        voiceRec[1].Play();

        voiceRec[0].Stop();
        voiceRec[3].Stop();
        voiceRec[2].Stop();


        Actions.onCloseNotifAudio?.Invoke();
    }
    public void playAudio3()
    {
        voiceRec[2].Play();

        voiceRec[0].Stop();
        voiceRec[1].Stop();
        voiceRec[3].Stop();
   

        Actions.onCloseNotifAudio?.Invoke();
    }
    public void playAudioDescription()
    {
        voiceRec[3].Play();

        voiceRec[0].Stop();
        voiceRec[1].Stop();
        voiceRec[2].Stop();

        Actions.onCloseNotifAudio?.Invoke();
    }
  
}
