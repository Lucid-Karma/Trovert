using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField]    private GameObject[] npcPrefabs;
    private List<GameObject> introvertNPCs = new List<GameObject>();
    private List<GameObject> extrovertNPCs = new List<GameObject>();

    public int npcCount;    // make it private later..........
    private float xPos, zPos;
    private float rotAmount;
    private Vector3 npcPos;

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

            GameObject obj = (GameObject)Instantiate(npcPrefabs[0], GetRandomPos(), Quaternion.AngleAxis(rotAmount, Vector3.up));
            introvertNPCs.Add(obj);
        }
    }

    void CreateExtrovertNPCs()
    {
        for (int i = 0; i < npcCount; i++)
        {
            rotAmount = Random.Range(0, 360);

            GameObject obj = (GameObject)Instantiate(npcPrefabs[1], GetRandomPos(), Quaternion.AngleAxis(rotAmount, Vector3.up));
            extrovertNPCs.Add(obj);
        }
    }

    private Vector3 GetRandomPos()
    {
        xPos = Random.Range(-50, 50);
        zPos = Random.Range(-10, 10);

        npcPos = new Vector3(xPos, 0, zPos);
        return npcPos;
    }
}
