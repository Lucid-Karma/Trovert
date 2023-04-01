using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitManager : MonoBehaviour
{
    void Start()
    {
        //Init Game Here
        SceneManager.LoadScene("TrovertUI", LoadSceneMode.Additive);
        SceneManager.LoadScene("TrovertGame", LoadSceneMode.Additive);
        Destroy(gameObject);
    }
}
