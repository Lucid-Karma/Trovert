using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Singleton<BulletManager>
{
    private List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField] private GameObject objectToPool;
    GameObject _bullet;

    // void Start()
    // {
    //     for (int i = 0; i < 20; i++)
    //     {
    //         SetBulletObject();
    //     }
    // }

    void OnEnable()
    {
        EventManager.OnCoinPickUp.AddListener(SetBulletObject);
    }
    void OnDisable()
    {
        EventManager.OnCoinPickUp.RemoveListener(SetBulletObject);
    }

    public void SetBulletObject()
    {
        GameObject obj = (GameObject)Instantiate(objectToPool);
        obj.SetActive(false); 
        pooledObjects.Add(obj);
    }

    public GameObject GetPooledObject() 
    {
        for (int i = 0; i < pooledObjects.Count; i++) 
        {
            if (!pooledObjects[i].activeInHierarchy) 
            {
                return pooledObjects[i];
            }
        }
        
        return null;
    }

    public void GetBullet(Vector3 spawnPoint, Quaternion spawnRot)   
    {
        _bullet = GetPooledObject();

            if(_bullet != null)
            {
                _bullet.transform.position = spawnPoint;
                _bullet.transform.rotation = spawnRot;
                _bullet.SetActive(true);
            }
    }
}
