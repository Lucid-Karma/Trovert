using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseNpcSpawner : MonoBehaviour
{
    private Transform playerTransform;
    private float spawnRadius = 20.0f;
    private float spawnInterval = 5.0f;
    private float distance;

    void OnEnable()
    {
        EventManager.OnIntrovertSecondPowerUp.AddListener(() => gameObject.SetActive(false));
    }
    void OnDisable()
    {
        EventManager.OnIntrovertSecondPowerUp.RemoveListener(() => gameObject.SetActive(false));
    }

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //InvokeRepeating("Spawn", 10.0f, spawnInterval);
    }

    // private void Spawn()
    // {
    //     distance = Vector3.Distance(transform.position, playerTransform.position);

    //     if(distance <= spawnRadius)
    //     {
    //         if (!FsmManager.Instance.IsCharacterCommunicating)
    //             NPCManager.Instance.CreateIntovertNPCsInProcess(playerTransform);
    //     }

    //     Debug.Log("spawned");
    // }

    void OnTriggerEnter(Collider other)
    {
        if (!enabled) return;

        if(other.gameObject.CompareTag("Player"))
        {
            // distance = Vector3.Distance(transform.position, playerTransform.position);

            // if(distance <= spawnRadius)
            // {
                if (!FsmManager.Instance.IsCharacterCommunicating)
                    NPCManager.Instance.CreateIntovertNPCsInProcess(playerTransform);
            // }

            Debug.Log("spawned");
        }
    }
}
