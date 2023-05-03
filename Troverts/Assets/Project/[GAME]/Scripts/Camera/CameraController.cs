using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public List<GameObject> Cameras = new List<GameObject>();   

    void OnEnable()
    {
        EventManager.OnCameraMove.AddListener(ShowFarAway);
        EventManager.OnLevelStart.AddListener(ShowCloser);
    }
    void OnDisable()
    {
        EventManager.OnCameraMove.RemoveListener(ShowFarAway);
        EventManager.OnLevelStart.RemoveListener(ShowCloser);
    }

    public void ShowCloser()
    {
        Cameras[2].SetActive(false);
        Cameras[1].SetActive(false);
        Cameras[0].SetActive(true);
    }

    public void ShowFarAway()
    {
        Cameras[0].SetActive(false);
        Cameras[2].SetActive(false);
        Cameras[1].SetActive(true);
    }
}
