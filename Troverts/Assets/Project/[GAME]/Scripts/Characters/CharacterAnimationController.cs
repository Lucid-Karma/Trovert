using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    CharacterFSM characterFsm;
    CharacterFSM CharacterFSM { get { return (characterFsm == null) ? characterFsm = GetComponentInParent<CharacterFSM>() : characterFsm; } }

    private void OnEnable()
    {
        //EventManager.OnLevelStart.AddListener(() => InvokeTrigger("Start"));

        //EventManager.OnLevelFinish.AddListener(() => Animator.Rebind());

        // characterFsm.OncharacterFsmRevive.AddListener(() => InvokeTrigger("Start"));
        // characterFsm.OncharacterFsmJump.AddListener(() => InvokeTrigger("Jump"));
        // characterFsm.OncharacterFsmSlide.AddListener(() =>InvokeTrigger("Slide"));
        // characterFsm.OncharacterFsmHit.AddListener(() => InvokeTrigger("Hit"));

        CharacterFSM.OnCharacterIdle.AddListener(() => InvokeTrigger("Idle"));
        CharacterFSM.OnCharacterWalk.AddListener(() => InvokeTrigger("Walk"));

        // EventManager.OnIntrovertCaught.AddListener(() => InvokeTrigger("Idle"));
        // EventManager.OnIntrovertLeave.AddListener(() => InvokeTrigger("Walk"));
        
    }

    private void OnDisable()
    {
        //EventManager.OnLevelStart.RemoveListener(() => InvokeTrigger("Start"));


        //EventManager.OnLevelFinish.RemoveListener(() => Animator.Rebind());

        // characterFsm.OncharacterFsmJump.RemoveListener(() => InvokeTrigger("Jump"));
        // characterFsm.OncharacterFsmSlide.RemoveListener(() => InvokeTrigger("Slide"));
        // characterFsm.OncharacterFsmHit.RemoveListener(() => InvokeTrigger("Hit"));

        CharacterFSM.OnCharacterIdle.RemoveListener(() => InvokeTrigger("Idle"));
        CharacterFSM.OnCharacterWalk.RemoveListener(() => InvokeTrigger("Walk"));

        // EventManager.OnIntrovertCaught.RemoveListener(() => InvokeTrigger("Idle"));
        // EventManager.OnIntrovertLeave.RemoveListener(() => InvokeTrigger("Walk"));
    }

    // private void Update()
    // {
    //     UpdateAnimations();
    // }

    // private void UpdateAnimations()
    // {
    //     Animator.SetBool("Moving", LevelManager.Instance.IsLevelStarted);
    //     Animator.SetBool("IsDead", characterFsm.IsDead);
    // }

    private void InvokeTrigger(string value)
    {
        Animator.SetTrigger(value);
    }
}
