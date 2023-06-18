using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Singleton<BulletManager>
{
    private List<GameObject> pooledObjects = new List<GameObject>();
    private List<GameObject> usableBulletObjects = new List<GameObject>();
    [SerializeField] private GameObject objectToPool;
    GameObject _bullet;

    // void Start()
    // {
    //     for (int i = 0; i < 20; i++)
    //     {
    //         SetObject();
    //     }
    // }

    void OnEnable()
    {
        EventManager.OnCoinPickUp.AddListener(FillBulletPool);
        EventManager.OnIntrovertLevelStart.AddListener(SetObject);
    }
    void OnDisable()
    {
        EventManager.OnCoinPickUp.RemoveListener(FillBulletPool);
        EventManager.OnIntrovertLevelStart.RemoveListener(SetObject);
    }

    public void SetObject()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false); 
            pooledObjects.Add(obj);
        }
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

    private void FillBulletPool()
    {
        usableBulletObjects.Add(GetPooledObject());
    }
    private void DrainBulletPool(GameObject bullet)
    {
        usableBulletObjects.Remove(bullet);
    }
    private GameObject GetPooledBullet()
    {
        for (int i = 0; i < usableBulletObjects.Count; i++) 
        {
            return usableBulletObjects[i];
        }
        
        return null;
    }

    public void GetBullet(Vector3 spawnPoint, Quaternion spawnRot)   
    {
        _bullet = GetPooledBullet();

            if(_bullet != null)
            {
                _bullet.transform.position = spawnPoint;
                _bullet.transform.rotation = spawnRot;
                _bullet.SetActive(true);
            }
        
        DrainBulletPool(_bullet);
    }
}
