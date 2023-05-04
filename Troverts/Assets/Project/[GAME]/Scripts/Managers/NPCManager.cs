using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCManager : Singleton<NPCManager>
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
    }
    void OnDisable()
    {
        EventManager.OnIntrovertLevelStart.RemoveListener(CreateIntovertNPCs);
        EventManager.OnExtrovertLevelStart.RemoveListener(CreateExtrovertNPCs);
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
    public void CreateIntovertNPCsInProcess(Vector3 pcPos)
    {
        for (int i = 0; i < 3; i++)
        {
            rotAmount = Random.Range(0, 360);

            GameObject obj = (GameObject)Instantiate(npcPrefabs[0], GetRandomPosAroundPC(pcPos), Quaternion.AngleAxis(rotAmount, Vector3.up));
            introvertNPCs.Add(obj);
        }
    }

    private Vector3 GetRandomPos(Vector3 center, float range)
    {
        randomPoint = center + Random.insideUnitSphere * range;
        NavMesh.SamplePosition(randomPoint, out hit, range, NavMesh.AllAreas);

        return hit.position;
    }
    private Vector3 GetRandomPosAroundPC(Vector3 pcPos)
    {
        randomPoint = pcPos + Random.insideUnitSphere * 25.0f;
        NavMesh.SamplePosition(randomPoint, out hit, 25.0f, NavMesh.AllAreas);

        return hit.position;
    }
}
