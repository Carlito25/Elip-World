using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questions4P1W : MonoBehaviour
{
    public List<GameObject> questions4Pic1Word = new List<GameObject> { };

    [SerializeField] public Text stages;
    [SerializeField] private AudioSource clickSoundEffect;
    [SerializeField] private AudioSource clearSoundEffect;

    void Start()
    {
        Actions.onRandomQuestions?.Invoke(questions4Pic1Word);
    }

    public void ClickSoundEffect()
    {
        clickSoundEffect.Play();
    }
    public void ClearSoundEffect()
    {
        clearSoundEffect.Play();
    }

}
