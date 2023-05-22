using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.OnBulletShoot.AddListener(SpawnBullet);
    }
    void OnDisable()
    {
        EventManager.OnBulletShoot.RemoveListener(SpawnBullet);
    }

    private void SpawnBullet()
    {
        BulletManager.Instance.GetBullet(gameObject.transform.position, gameObject.transform.rotation);
        Debug.Log("bullet spawned");
    }
}
