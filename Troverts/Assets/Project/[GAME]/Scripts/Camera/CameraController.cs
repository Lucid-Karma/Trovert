using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public List<GameObject> Cameras = new List<GameObject>();   

    void OnEnable()
    {
        EventManager.OnCameraMove.AddListener(ShowFarAway);
        EventManager.OnLevelStart.AddListener(ShowCloser);

        EventManager.OnIntrovertAim.AddListener(Aim);
        //EventManager.OnIntrovertEndAim.AddListener(EndAim);
    }
    void OnDisable()
    {
        EventManager.OnCameraMove.RemoveListener(ShowFarAway);
        EventManager.OnLevelStart.RemoveListener(ShowCloser);

        EventManager.OnIntrovertAim.RemoveListener(Aim);
        //EventManager.OnIntrovertEndAim.RemoveListener(EndAim);
    }

    private void ShowCloser()
    {
        Cameras[2].SetActive(false);
        Cameras[1].SetActive(false);
        Cameras[0].SetActive(true);
    }

    private void ShowFarAway()
    {
        Cameras[0].SetActive(false);
        Cameras[2].SetActive(false);
        Cameras[1].SetActive(true);
    }

    private void Shoot()    // same function with Aim().
    {
        Cameras[0].SetActive(false);
        Cameras[3].SetActive(true);
    }
    private void EndAim()
    {
        Cameras[3].SetActive(false);
        Cameras[0].SetActive(true);
    }

    private void Aim()
    {
        Cameras[3].GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 9;
    }
}
