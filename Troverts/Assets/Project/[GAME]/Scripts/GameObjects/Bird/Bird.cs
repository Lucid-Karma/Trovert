using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour 
{
    private Vector3 _nextPos;
    private Vector3 _gap;
    private Quaternion _targetAngle;
    private float _flySpeed = 25f;
    private float _rotationDegreePerSecond = 1000;
    private bool isArrived = false;


    void Start()
    {
        _nextPos = BirdManager.Instance.GetRandomBirdPos();
        Debug.Log("first destination: " + _nextPos.x+" "+_nextPos.y+" "+_nextPos.z);

        _gap = (_nextPos - transform.position).normalized;
        _targetAngle = Quaternion.LookRotation(new Vector3(_gap.x, 0f, _gap.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, _targetAngle, _rotationDegreePerSecond * Time.fixedDeltaTime);
        Vector3 i= _nextPos + Random.insideUnitSphere * 10;
        Debug.Log(i.x+" "+i.y+" "+i.z);
    }

    void FixedUpdate()
    {
        MoveBird(_nextPos);
    }

    public void MoveBird(Vector3 nextPos)
    {
        if (transform.position == nextPos + Random.insideUnitSphere * 3)
        {
            nextPos = BirdManager.Instance.GetRandomBirdPos();

            _gap = (_nextPos - transform.position).normalized;
            _targetAngle = Quaternion.LookRotation(new Vector3(_gap.x, 0f, _gap.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetAngle, _rotationDegreePerSecond * Time.fixedDeltaTime);

            Debug.Log("Arrived");
        }

        transform.position += transform.forward * _flySpeed * Time.fixedDeltaTime;
    }    
}