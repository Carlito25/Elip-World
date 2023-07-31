using UnityEngine;

public class CodeAudio : MonoBehaviour
{
    [SerializeField] private AudioSource voiceRec1;
    [SerializeField] private AudioSource voiceRec2;
    [SerializeField] private AudioSource voiceRecDescription;
   
    public void playAudio1()
    {
        voiceRec1.Play();

        voiceRec2.Stop();
        voiceRecDescription.Stop();
        Actions.onCloseNotifAudio?.Invoke();
    } 
    public void playAudio2()
    {
        voiceRec2.Play();

        voiceRec1.Stop();
        voiceRecDescription.Stop();
        Actions.onCloseNotifAudio?.Invoke();
    } 
    public void playAudioDescription()
    {
        voiceRecDescription.Play();

        voiceRec2.Stop();
        voiceRec1.Stop();
        Actions.onCloseNotifAudio?.Invoke();
    }
   
}
