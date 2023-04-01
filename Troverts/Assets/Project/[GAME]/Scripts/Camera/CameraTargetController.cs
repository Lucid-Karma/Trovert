using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTargetController : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    public CinemachineVirtualCamera CinemachineVirtualCamera{ get { return(cinemachineVirtualCamera == null)? cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>() : cinemachineVirtualCamera; }}

    [SerializeField] private Transform introvertTarget;
    [SerializeField] private Transform extrovertTarget;

    void OnEnable()
    {
        EventManager.OnIntrovertLevelStart.AddListener(MakeTargetIntrovert);
        EventManager.OnExtrovertLevelStart.AddListener(MakeTargetExtrovert);
    }
    void OnDisable()
    {
        EventManager.OnIntrovertLevelStart.RemoveListener(MakeTargetIntrovert);
        EventManager.OnExtrovertLevelStart.RemoveListener(MakeTargetExtrovert);
    }

    private void MakeTargetIntrovert()
    {
        CinemachineVirtualCamera.Follow = introvertTarget;
    }

    private void MakeTargetExtrovert()
    {
        CinemachineVirtualCamera.Follow = extrovertTarget;
    }

}
