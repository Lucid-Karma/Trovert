using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCManager : MonoBehaviour
{
    [SerializeField]    private GameObject[] npcPrefabs;
    private List<GameObject> introvertNPCs = new List<GameObject>();
    private List<GameObject> extrovertNPCs = new List<GameObject>();

    public int npcCount;    // make it private later..........
    private float xPos, zPos;
    private float rotAmount;
    Vector3 randomPoint;
    NavMeshHit hit;

    void OnEnable()
    {
        EventManager.OnIntrovertLevelStart.AddListener(CreateIntovertNPCs);
        EventManager.OnExtrovertLevelStart.AddListener(CreateExtrovertNPCs);
        EventManager.OnINpcNeeded.AddListener(CreateIntovertNPCsInProcess);
    }
    void OnDisable()
    {
        EventManager.OnIntrovertLevelStart.RemoveListener(CreateIntovertNPCs);
        EventManager.OnExtrovertLevelStart.RemoveListener(CreateExtrovertNPCs);
        EventManager.OnINpcNeeded.RemoveListener(CreateIntovertNPCsInProcess);
    }

    void CreateIntovertNPCs()
    {
        for (int i = 0; i < npcCount; i++)
        {
            rotAmount = Random.Range(0, 360);

            GameObject obj = (GameObject)Instantiate(npcPrefabs[0], GetRandomPos(new Vector3(0, 0, 0), 95.0f), Quaternion.AngleAxis(rotAmount, Vector3.up));
            introvertNPCs.Add(obj);
        }
    }

    void CreateExtrovertNPCs()
    {
        for (int i = 0; i < npcCount; i++)
        {
            rotAmount = Random.Range(0, 360);

            GameObject obj = (GameObject)Instantiate(npcPrefabs[1], GetRandomPos(new Vector3(0, 0, 0), 95.0f), Quaternion.AngleAxis(rotAmount, Vector3.up));
            extrovertNPCs.Add(obj);
        }
    }

    private Vector3 GetRandomPos(Vector3 center, float range)
    {
        randomPoint = center + Random.insideUnitSphere * range;
        NavMesh.SamplePosition(randomPoint, out hit, range, NavMesh.AllAreas);

        return hit.position;
    }

    void CreateIntovertNPCsInProcess()
    {
        rotAmount = Random.Range(0, 360);

        GameObject obj = (GameObject)Instantiate(npcPrefabs[0], GetRandomPos(new Vector3(0, 0, 0), 95.0f), Quaternion.AngleAxis(rotAmount, Vector3.up));
        introvertNPCs.Add(obj);
    }
}
