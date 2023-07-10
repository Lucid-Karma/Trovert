using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAnimationController : MonoBehaviour
{
    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    NpcFSM npcFSM;
    NpcFSM NpcFSM { get { return (npcFSM == null) ? npcFSM = GetComponentInParent<NpcFSM>() : npcFSM; } }

    public string[] shockAnimations;  // Array of animation clips to be played on the actors 
    private int animNum;

    void OnEnable()
    {
        NpcFSM.OnNpcWalk.AddListener(() => InvokeTrigger("Walk"));
        NpcFSM.OnNpcIdle.AddListener(() => InvokeTrigger("Idle"));
        NpcFSM.OnNpcRun.AddListener(() => InvokeTrigger("Goofy Run"));
        NpcFSM.OnNpcDie.AddListener(() => InvokeTrigger("Die"));
        NpcFSM.OnNpcPanic.AddListener(() => InvokeTrigger(PlayCutscene()));
    }
    void OnDisable()
    {
        NpcFSM.OnNpcWalk.RemoveListener(() => InvokeTrigger("Walk"));
        NpcFSM.OnNpcIdle.RemoveListener(() => InvokeTrigger("Idle"));
        NpcFSM.OnNpcRun.RemoveListener(() => InvokeTrigger("Goofy Run"));
        NpcFSM.OnNpcDie.RemoveListener(() => InvokeTrigger("Die"));
        NpcFSM.OnNpcPanic.RemoveListener(() => InvokeTrigger(PlayCutscene()));
    }

    private void InvokeTrigger(string value)
    {
        Animator.SetTrigger(value);
    }

    #region Event Based Methods
    public void DieAnimActs()
    {
        NpcFSM.StopNpc();
    }

    public void Panic()
    {
        NpcFSM.Panic();

        OrganiseNpcColliderWithAnimation();
    }

    #region Helper Methods

    private void OrganiseNpcColliderWithAnimation()
    {
        Animator.rootPosition = NpcFSM.Agent.nextPosition;
    }

    #endregion

    #endregion

    

    public string PlayCutscene() 
    {
        animNum = Random.Range(0, shockAnimations.Length);
        return shockAnimations[animNum];
    } 
}
