using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] public Camera[] cameras;
    private AudioListener[] camAudio = new AudioListener[2];

    private void Awake() 
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            camAudio[i] = cameras[i].GetComponent<AudioListener>(); // Access every AudioListener of cameras.
        }

        camAudio[1].enabled = false;    
        cameras[1].enabled =  false; // Disable second Camera so game'll start with Main Camera.

    }

    void OnEnable()
    {
        EventManager.OnIntrovertSecondPowerUp.AddListener(LookFirstPerson);
    }
    void OnDisable()
    {
        EventManager.OnIntrovertSecondPowerUp.RemoveListener(LookFirstPerson);
    }

    void LookFirstPerson()
    {
        camAudio[0].enabled = false;    
        cameras[0].enabled =  false;

        camAudio[1].enabled = true;    
        cameras[1].enabled = true;
    }
}
