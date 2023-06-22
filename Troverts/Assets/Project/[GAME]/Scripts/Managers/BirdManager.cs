using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : Singleton<BirdManager>
{
    [SerializeField] private GameObject _bird;
    private List<GameObject> _birdList = new List<GameObject>();
    private Vector3 _randomBirdPos, _randomNextBirdPos;
    private Vector3 _stickDirection;
    private float _range = 100f;
    private float _rotAmount = 50f;
    private float _rotationDegreePerSecond = 1000;
    public float _flySpeed;

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            _rotAmount = Random.Range(0, 360);

            GameObject obj = (GameObject)Instantiate(_bird, GetRandomBirdPos(), Quaternion.AngleAxis(_rotAmount, Vector3.up));
            _birdList.Add(obj);
        }
    }

    void FixedUpdate()
    {
        MoveBird();
    }

    private Vector3 GetRandomBirdPos()
    {
        _randomBirdPos = Vector3.zero + Random.insideUnitSphere * _range;
        return _randomBirdPos;
    }

    public void MoveBird()
    {
        for (int i = 0; i < _birdList.Count; i++)
        {
            if (_birdList[i].transform.position == _randomBirdPos)
            {
                _randomBirdPos = GetRandomBirdPos();
                _stickDirection = new Vector3(_randomBirdPos.x, 0, _randomBirdPos.z);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(_stickDirection, Vector3.up), _rotationDegreePerSecond * Time.fixedDeltaTime);
            }

            _birdList[i].transform.position += transform.forward * _flySpeed * Time.fixedDeltaTime;
        }
        
    }
}
