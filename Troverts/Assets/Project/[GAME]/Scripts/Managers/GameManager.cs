using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool isGameStarted;
    public bool IsGameStarted { get { return isGameStarted; } private set { isGameStarted = value; } }

    private bool isLevelStarted;
    public bool IsLevelStarted { get { return isLevelStarted; } private set { isLevelStarted = value; } }

    private bool isLevelSuccess;
    public bool IsLevelSuccess { get { return isLevelSuccess; } private set { isLevelSuccess = value; } }

    private bool isLevelFail;
    public bool IsLevelFail { get { return isLevelFail; } private set { isLevelFail = value; } }


    // void Awake()
    // {
    //     PlayerPrefs.DeleteAll();
    // }

    public void StartGame()
    {
        if (IsGameStarted || applicationIsQuitting == false)
            return;

        IsGameStarted = true;
        EventManager.OnGameStart.Invoke();
    }

    public void EndGame()
    {
        if (!IsGameStarted || applicationIsQuitting == true)
            return;

        IsGameStarted = false;
        EventManager.OnGameEnd.Invoke();
    }


    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(() => IsLevelStarted = true);
        EventManager.OnRestart.AddListener(ContinueGame);
        EventManager.OnLevelFail.AddListener(FailGame);
        EventManager.OnLevelSuccess.AddListener(WinGame);

        EventManager.OnTimeBlend.AddListener(DelayLevel);
        EventManager.OnTimeFlow.AddListener(ContinueGame);
        EventManager.OnPreGreet.AddListener(ContinueGame);
    }
    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(() => IsLevelStarted = true);
        EventManager.OnRestart.RemoveListener(ContinueGame);
        EventManager.OnLevelFail.RemoveListener(FailGame);
        EventManager.OnLevelSuccess.RemoveListener(WinGame);

        EventManager.OnTimeBlend.RemoveListener(DelayLevel);
        EventManager.OnTimeFlow.RemoveListener(ContinueGame);
        EventManager.OnPreGreet.RemoveListener(ContinueGame);
    }

    void WinGame()
    {
        IsLevelSuccess = true;
        IsLevelStarted = false;
        PauseGame();
    }

    void FailGame()
    {
        IsLevelFail = true;
        IsLevelStarted = false;
        PauseGame();
    }

    void PauseGame()
    {
        Time.timeScale = 0.5f;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
    }

    public void DelayLevel()
    {
        //Time.timeScale = 0.1f;
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
