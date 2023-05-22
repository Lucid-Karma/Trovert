using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolder : MonoBehaviour
{
    [SerializeField] private GameObject _awpGunPrefab;
    GameObject awpGun;

    void OnEnable()
    {
        EventManager.OnIntrovertAim.AddListener(InitializeGun);
        //EventManager.OnIntrovertEndAim.AddListener(DisposeGun);
    }
    void OnDisable()
    {
        EventManager.OnIntrovertAim.RemoveListener(InitializeGun);
        //EventManager.OnIntrovertEndAim.RemoveListener(DisposeGun);
    }

    void Start()        // ???!!!
    {
        awpGun = Instantiate(_awpGunPrefab, transform);
        awpGun.SetActive(false);
    }
    private void InitializeGun()
    {
        //_awpGunPrefab.transform.position = gameObject.transform.position;
        //_awpGunPrefab.transform.rotation = Quaternion.identity;
        awpGun.SetActive(true);
        Debug.Log("gun active");
    }

    private void DisposeGun()
    {
        awpGun.SetActive(false);
        Debug.Log("no gun");
    }
}