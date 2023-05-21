using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAnimationController : MonoBehaviour
{
    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    NpcFSM npcFSM;
    NpcFSM NpcFSM { get { return (npcFSM == null) ? npcFSM = GetComponentInParent<NpcFSM>() : npcFSM; } }

    void OnEnable()
    {
        NpcFSM.OnNpcWalk.AddListener(() => InvokeTrigger("Walk"));
        NpcFSM.OnNpcIdle.AddListener(() => InvokeTrigger("Idle"));
        NpcFSM.OnNpcRun.AddListener(() => InvokeTrigger("Goofy Run"));
    }
    void OnDisable()
    {
        NpcFSM.OnNpcWalk.RemoveListener(() => InvokeTrigger("Walk"));
        NpcFSM.OnNpcIdle.RemoveListener(() => InvokeTrigger("Idle"));
        NpcFSM.OnNpcRun.RemoveListener(() => InvokeTrigger("Goofy Run"));
    }

    private void InvokeTrigger(string value)
    {
        Animator.SetTrigger(value);
    }
}
