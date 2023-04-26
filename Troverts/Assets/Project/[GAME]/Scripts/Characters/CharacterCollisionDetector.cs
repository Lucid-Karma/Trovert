using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            EventManager.OnExtrvrtGreet.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            EventManager.OnExtrvrtGreetingEnd.Invoke();
        }
    }
}
