using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour 
{
    private Vector3 _nextPos;
    private Vector3 _gap;
    private Quaternion _targetAngle;
    private float _flySpeed = 25f;
    private float _rotationDegreePerSecond = 500;
    private float _distance;


    void Start()
    {
        _nextPos = BirdManager.Instance.GetRandomBirdPos();

        _gap = (_nextPos - transform.position).normalized;
        _targetAngle = Quaternion.LookRotation(new Vector3(_gap.x, 0f, _gap.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, _targetAngle, _rotationDegreePerSecond * Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        MoveBird();
    }

    public void MoveBird()
    {
        _distance = Vector3.Distance(transform.position, _nextPos);

        if (Mathf.Abs(_distance) <= 0.5f)
        {
            _nextPos = BirdManager.Instance.GetRandomBirdPos();

            _gap = (_nextPos - transform.position).normalized;
            _targetAngle = Quaternion.LookRotation(new Vector3(_gap.x, 0f, _gap.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetAngle, _rotationDegreePerSecond * Time.fixedDeltaTime);
        }

        transform.position += transform.forward * _flySpeed * Time.fixedDeltaTime;
    }    
}