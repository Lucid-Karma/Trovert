using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Singleton<BulletManager>
{
    private List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField] private GameObject objectToPool;
    GameObject _bullet;

    private Vector3 _createPos;


    public void CreateBulletObject()
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

    public void GetBullet()   
    {
        _createPos = GetBulletPosition();
        _bullet = GetPooledObject();

            if(_bullet != null)
            {
                _bullet.transform.position = _createPos;
                _bullet.transform.rotation = transform.parent.rotation;
                _bullet.SetActive(true);
            }
    }

    public Vector3 GetBulletPosition()
    {
        return gameObject.transform.position;
    }
}
