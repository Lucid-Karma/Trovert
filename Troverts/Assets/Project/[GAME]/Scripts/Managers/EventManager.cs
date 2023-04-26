using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameEnd = new UnityEvent();

    public static UnityEvent OnLevelStart = new UnityEvent();
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
    public static UnityEvent OnDifficultyChoose = new UnityEvent();

    public static UnityEvent OnObstacleCreated = new UnityEvent();

    public static UnityEvent OnIntrovertCaught = new UnityEvent();
    public static UnityEvent OnIntrovertLeave = new UnityEvent();
    public static UnityEvent OnPlayerStartedRunning = new UnityEvent();

    public static UnityEvent OnMusicOn = new UnityEvent();
    public static UnityEvent OnMusicOff = new UnityEvent();

    public static UnityEvent OnCursorLock = new UnityEvent();
    public static UnityEvent OnICharacterDataReceive = new UnityEvent();
    public static UnityEvent OnECharacterDataReceive = new UnityEvent();

    public static UnityEvent OnExtrvrtGreet = new UnityEvent();
    public static UnityEvent OnExtrvrtGreetingEnd = new UnityEvent();
}
