using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _timeBenderBox;
    [SerializeField] private GameObject _shooterBox;
    private Vector3 _createPos, _randomPoint;
    NavMeshHit hit;

    void OnEnable()
    {
        EventManager.OnIntrovertFirstBoxCall.AddListener(GetTimeBender);
        EventManager.OnIntrovertSecondBoxCall.AddListener(GetShooter);
    }
    void OnDisable()
    {
        EventManager.OnIntrovertFirstBoxCall.RemoveListener(GetTimeBender);
        EventManager.OnIntrovertSecondBoxCall.RemoveListener(GetShooter);
    }

    public void GetTimeBender()   
    {
        _createPos = GetBoxPosition(new Vector3(0, 0, 0), 5.0f);

        if(_timeBenderBox != null)
        {
            GameObject obj = (GameObject)Instantiate(_timeBenderBox, _createPos, Quaternion.identity);
            obj.SetActive(true);
        }
    }

    public void GetShooter()   
    {
        _createPos = GetBoxPosition(new Vector3(0, 0, 0), 5.0f);

        if(_shooterBox != null)
        {
            GameObject obj = (GameObject)Instantiate(_shooterBox, _createPos, Quaternion.identity);
            obj.SetActive(true);
        }
    }

    private Vector3 GetBoxPosition(Vector3 center, float range)
    {
        _randomPoint = center + Random.insideUnitSphere * range;
        UnityEngine.AI.NavMesh.SamplePosition(_randomPoint, out hit, range, UnityEngine.AI.NavMesh.AllAreas);

        return hit.position;
    }
}
