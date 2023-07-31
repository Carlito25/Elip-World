using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeAudio2 : MonoBehaviour
{
    [SerializeField] private AudioSource [] voiceRec;
    

    public void playAudio1()
    {
        voiceRec[0].Play();

        voiceRec[1].Stop();
        voiceRec[2].Stop();
        voiceRec[3].Stop();
        voiceRec[4].Stop();
        voiceRec[5].Stop();
        voiceRec[6].Stop();

        Actions.onCloseNotifAudio?.Invoke();
    }
    public void playAudio2()
    {
        voiceRec[1].Play();

        voiceRec[0].Stop();
        voiceRec[2].Stop();
        voiceRec[3].Stop();
        voiceRec[4].Stop();
        voiceRec[5].Stop();
        voiceRec[6].Stop();

        Actions.onCloseNotifAudio?.Invoke();
    }

    public void playAudio3()
    {
        voiceRec[2].Play();

        voiceRec[0].Stop();
        voiceRec[1].Stop();
        voiceRec[3].Stop();
        voiceRec[4].Stop();
        voiceRec[5].Stop();
        voiceRec[6].Stop();

        Actions.onCloseNotifAudio?.Invoke();
    }
    public void playAudio4()
    {
        voiceRec[3].Play();

        voiceRec[0].Stop();
        voiceRec[1].Stop();
        voiceRec[2].Stop();
        voiceRec[4].Stop();
        voiceRec[5].Stop();
        voiceRec[6].Stop();

        Actions.onCloseNotifAudio?.Invoke();
    }
    public void playAudio5()
    {
        voiceRec[4].Play();

        voiceRec[0].Stop();
        voiceRec[1].Stop();
        voiceRec[2].Stop();
        voiceRec[3].Stop();
        voiceRec[5].Stop();
        voiceRec[6].Stop();
        

        Actions.onCloseNotifAudio?.Invoke();
    }
    public void playAudio6()
    {
        voiceRec[5].Play();

        voiceRec[0].Stop();
        voiceRec[1].Stop();
        voiceRec[2].Stop();
        voiceRec[3].Stop();
        voiceRec[4].Stop();
        voiceRec[6].Stop();

        Actions.onCloseNotifAudio?.Invoke();
    }
    public void playAudioDescription()
    {
        voiceRec[6].Play();

        voiceRec[4].Stop();
        voiceRec[0].Stop();
        voiceRec[1].Stop();
        voiceRec[2].Stop();
        voiceRec[3].Stop();
        voiceRec[5].Stop();

        Actions.onCloseNotifAudio?.Invoke();
    }
}
