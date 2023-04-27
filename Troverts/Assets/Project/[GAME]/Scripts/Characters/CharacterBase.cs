using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class CharacterBase : MonoBehaviour
{
    [HideInInspector]
    public int selectedDifficulty;
    [HideInInspector]
    public static int Energy;
    public static int Score = 0;  
    

    public abstract void SetEnergy();
    public abstract void ReceiveData();

    public virtual void ManageEnergy()
    {
        Die();
    }

    public void Die()
    {
        EventManager.OnLevelFail.Invoke();
    }
}
