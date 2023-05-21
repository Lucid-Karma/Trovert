using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _pooledObjects = new List<GameObject>();
    [SerializeField] private GameObject _objectToPool;
    private int _amountToPool = 5;

    private Vector3 _createPos;

    Vector3 _randomPoint;
    NavMeshHit hit;


    void Awake() 
    {
        for (int i = 0; i < _amountToPool; i++) 
        {
            GameObject obj = (GameObject)Instantiate(_objectToPool);
            obj.SetActive(false); 
            _pooledObjects.Add(obj);
        }
    }

    void Start()
    {
        Invoke("GetCoinFirst", 10.0f);
    }

    public GameObject GetPooledObject() 
    {
        for (int i = 0; i < _pooledObjects.Count; i++) 
        {
            if (!_pooledObjects[i].activeInHierarchy) 
            {
                return _pooledObjects[i];
            }
        }
        
        return null;
    }

    public void GetCoin()   
    {
        _createPos = GetCoinPosition(new Vector3(0, 0, 0), 95.0f);
        GameObject bullet = GetPooledObject();

            if(bullet != null)
            {
                bullet.transform.position = _createPos;
                bullet.transform.rotation = transform.parent.rotation;
                bullet.SetActive(true);
            }
    }

    public Vector3 GetCoinPosition(Vector3 center, float range)
    {
        _randomPoint = center + Random.insideUnitSphere * range;
        NavMesh.SamplePosition(_randomPoint, out hit, range, NavMesh.AllAreas);

        return hit.position;
    }

    public void GetCoinFirst()
    {
        for (int i = 0; i < 5; i++)
        {
            GetCoin();
        }
    }
}
