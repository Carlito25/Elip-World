using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestionBW : MonoBehaviour
{
    public List<GameObject> questionsBookworm = new List<GameObject> { };

    //[SerializeField] public Text stages;
    [SerializeField] private AudioSource clickSoundEffect;
    [SerializeField] private AudioSource clearSoundEffect;
    [SerializeField] private AudioSource playerAttackSoundEffect;
    [SerializeField] private AudioSource bossAttackSoundEffect;
    private void OnEnable()
    {
        Actions.BWPlayerAttackSoundEffect += PlayerAttackSoundEffect;
        Actions.BWBossAttackSoundEffect += BossAttackSoundEffect;

        Actions.clearSoundEffect += ClearSoundEffect;
    }
    private void OnDisable()
    {
        Actions.BWPlayerAttackSoundEffect -= PlayerAttackSoundEffect;
        Actions.BWBossAttackSoundEffect -= BossAttackSoundEffect;

        Actions.clearSoundEffect -= ClearSoundEffect;
    }
    public void BossAttackSoundEffect()
    {
        bossAttackSoundEffect.Play();
    }

    public void PlayerAttackSoundEffect()
    {
        playerAttackSoundEffect.Play();
    }
    void Start()
    {
        Actions.onRandomQuestions?.Invoke(questionsBookworm);
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
