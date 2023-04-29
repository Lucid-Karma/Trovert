using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    // private void OnEnable() 
    // {
    //     EventManager.OnGameStart.AddListener(RestartGame);
    //     EventManager.OnLevelStart.AddListener(RestartLevel);
    // }
    // private void OnDisable() 
    // {
    //     EventManager.OnGameStart.RemoveListener(RestartGame);   
    //     EventManager.OnLevelStart.RemoveListener(RestartLevel); 
    // }
    public void Restart()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        PlayerPrefs.DeleteAll();
        EventManager.OnRestart.Invoke();
    }

    // public void RestartGame()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    //     EventManager.OnRestart.Invoke();
    // }
}
