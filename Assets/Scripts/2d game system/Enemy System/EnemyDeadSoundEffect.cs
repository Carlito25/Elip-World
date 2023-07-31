using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadSoundEffect : MonoBehaviour
{
    [SerializeField] private AudioSource enemyDeadAudio;

    private void OnEnable()
    {
        Actions.enemyDeadSoundEffect += enemyDeadPlay;
    }
    private void OnDisable()
    {
        Actions.enemyDeadSoundEffect -= enemyDeadPlay;
    }
    private void enemyDeadPlay()
    {
        enemyDeadAudio.Play();
    }
}
