using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : Singleton<BirdManager>
{
    [SerializeField] private GameObject _bird;
    private List<GameObject> _birdList = new List<GameObject>();
    private Vector3 _randomBirdPos;
    private float _rotAmount = 50f;

    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            _rotAmount = Random.Range(0, 360);

            GameObject obj = (GameObject)Instantiate(_bird, GetRandomBirdPos(), Quaternion.AngleAxis(_rotAmount, Vector3.up));
            _birdList.Add(obj);
        }
    }

    public Vector3 GetRandomBirdPos()
    {
        _randomBirdPos = new Vector3(Random.Range(-200, 200), 30, Random.Range(-200, 200));
        return _randomBirdPos;
        
    }
}
