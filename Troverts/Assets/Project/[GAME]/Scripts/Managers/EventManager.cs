using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent OnGamePreStart = new UnityEvent();
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameEnd = new UnityEvent();

    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelAfterStart = new UnityEvent();
    public static UnityEvent OnLevelContine = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();

    public static UnityEvent OnLevelSuccess = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();

    public static UnityEvent OnRestart = new UnityEvent();

    public static UnityEvent OnIntrovertLevelStart = new UnityEvent();
    public static UnityEvent OnExtrovertLevelStart = new UnityEvent();

    public static UnityEvent OnCharacterChoose = new UnityEvent();
    public static UnityEvent OnExtrovertChoose = new UnityEvent();
    public static UnityEvent OnIntrovertChoose = new UnityEvent();
    public static UnityEvent OnEDifficultyChoose = new UnityEvent();
    public static UnityEvent OnIDifficultyChoose = new UnityEvent();

    public static UnityEvent OnObstacleCreated = new UnityEvent();
    public static UnityEvent OnCoinPickUp = new UnityEvent();
    public static UnityEvent OnBulletShoot = new UnityEvent();
    public static UnityEvent OnPointEarn = new UnityEvent();
    public static UnityEvent OnPointLose = new UnityEvent();
    public static UnityEvent OnEScoreTxtUpdate = new UnityEvent();
    public static UnityEvent OnIScoreTxtUpdate = new UnityEvent();

    public static UnityEvent OnIntrovertCaught = new UnityEvent();
    public static UnityEvent OnIntrovertLeave = new UnityEvent();
    public static UnityEvent OnIntrovertAim = new UnityEvent();
    public static UnityEvent OnIntrovertEndAim = new UnityEvent();
    public static UnityEvent OnIntrovertFirstBoxCall = new UnityEvent();
    public static UnityEvent OnIntrovertSecondBoxCall = new UnityEvent();
    public static UnityEvent OnIntrovertFirstPowerUp = new UnityEvent();
    public static UnityEvent OnPlayerStartedRunning = new UnityEvent();

    public static UnityEvent OnMusicOn = new UnityEvent();
    public static UnityEvent OnMusicOff = new UnityEvent();
    public static UnityEvent OnTimeBend = new UnityEvent();
    public static UnityEvent OnTimeFlow = new UnityEvent();
    public static UnityEvent OnCameraMove = new UnityEvent();

    public static UnityEvent OnCursorLock = new UnityEvent();
    public static UnityEvent OnICharacterDataReceive = new UnityEvent();
    public static UnityEvent OnECharacterDataReceive = new UnityEvent();

    public static UnityEvent OnPreGreet = new UnityEvent();
    public static UnityEvent OnNpcGreet = new UnityEvent();
    public static UnityEvent OnNpcGreetingEnd = new UnityEvent();
    public static UnityEvent OnNpcGetSmart = new UnityEvent();
}
