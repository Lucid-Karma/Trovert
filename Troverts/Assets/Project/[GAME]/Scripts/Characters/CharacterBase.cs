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

    // void OnEnable()
    // {
    //     EventManager.OnDifficultyChoose.AddListener(LearnDifficulty);
    // }
    // void OnDisable()
    // {
    //     EventManager.OnDifficultyChoose.RemoveListener(LearnDifficulty);
    // }

    public abstract void SetEnergy();
    public abstract void ReceiveData();

    public virtual void ManageEnergy(int amount)
    {
        Die();
    }

    public void Die()
    {
        EventManager.OnLevelFail.Invoke();
    }

    // private void LearnDifficulty()
    // {
    //     selectedDifficulty = PlayerPrefs.GetInt("selected_difficulty");
    // }

    // NpcFSM npc;

    // public void OnControllerColliderHit(ControllerColliderHit hit)
    // {
    //     npc = hit.gameObject.GetComponent<NpcFSM>();

    //     if(npc != null)
    //     {
    //         npc.Interact();
    //     }
    // }
}
