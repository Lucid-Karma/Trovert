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
    }
    void OnDisable()
    {
        EventManager.OnIntrovertAim.RemoveListener(InitializeGun);
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
    }

    // private void DisposeGun()
    // {
    //     awpGun.SetActive(false);
    // }
}
