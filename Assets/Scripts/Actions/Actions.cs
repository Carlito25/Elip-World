using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Actions 
{
    public static Func<char> onRandomLettersGenerator;

    public static Func<List<char>, char, char> onRandomCorrectLettersGenerator;

    public static  Action<GameObject, Func<bool>, Func<bool>, Action> onCheckAnswerBW;

    public static Action<GameObject, GameObject, Func<bool> > onCheckAnswer4P1W;

    public static Action <List<GameObject>> onRandomQuestions;

    public static Action onFreezePosition;

    public static Action onEnabledMovePlayer;

    public static Func <int> onGetCollectibles;

    public static Func<bool> onSetEnemySpeed;

    public static Func<bool> onSetIsEnabledEscape;

    public static Func<Transform> onGetCurrentCheckpoint;

    public static Func<bool> onGetOutpostIsTrigger;

    public static Action onQuitPopup;

    public static Action onQuitIntroDialog;

    public static Func <int> onGetPreviousQuestion;

    public static Action onPopupCollideAlready;

    public static Action onFirstCollideChecker;

    public static Action onDisabledInfoButtons;

    public static Func <float> onGetSecondsofDelay;

    public static Action onClickSoundEffect;

    public static Action onDropSoundEffect;

    public static Action onCorrectAnswerSoundEffect;

    public static Action onWrongAnswerSoundEffect;

    public static Func<Image> onButtonImage;

    public static Func<bool> onGetWarningSign;

    public static Func<Text> onGetEnemyKilledText;

    public static Func<int> onGetEnemyKilledCount;
    public static Func<int> onGetEnemyKilledIncrement;

    public static Action onChangeCollectibleGoal;

    public static Action onChangeKilledCountGoal;

    public static Action onCheckEnemyKilledIsCompleted;

    public static Action onCloseNotifAudio;

    public static Action onCloseNotifCompleteItem;

    public static Action onCloseNotifNotCompleteItem;

    public static Action onCloseLevel3NotifNotCompleteItem;

    public static Action onCloseEnemyCompleted;

    public static Func<float> onGetPlayerHealth;

    public static Action BWPlayerAttackSoundEffect;

    public static Action BWBossAttackSoundEffect;

    public static Action MainMenuButtonSoundEffect;

    public static Action InventorySoundEffect;

    public static Action informationsSoundEffect;

    public static Action enemyDeadSoundEffect;

    public static Action clearSoundEffect;

    public static Func<float> onGetbossTimerAttack;









}
