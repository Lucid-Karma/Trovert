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

        EventManager.OnIntrovertShoot.AddListener(Shoot);
        EventManager.OnIntrovertEndShoot.AddListener(EndShoot);
    }
    void OnDisable()
    {
        EventManager.OnCameraMove.RemoveListener(ShowFarAway);
        EventManager.OnLevelStart.RemoveListener(ShowCloser);

        EventManager.OnIntrovertShoot.RemoveListener(Shoot);
        EventManager.OnIntrovertEndShoot.RemoveListener(EndShoot);
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

    private void Shoot()
    {
        Cameras[0].SetActive(false);
        Cameras[3].SetActive(true);
    }
    private void EndShoot()
    {
        Cameras[3].SetActive(false);
        Cameras[0].SetActive(true);
    }
}
