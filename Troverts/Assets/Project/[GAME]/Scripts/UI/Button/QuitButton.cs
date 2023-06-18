using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{ 
    public void Finish()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif

        #if UNITY_STANDALONE
            Application.Quit();
        #endif

        #if UNITY_WEBGL
            Application.OpenURL("https://m1rr0r.itch.io/troverts");
        #endif
    }
}
