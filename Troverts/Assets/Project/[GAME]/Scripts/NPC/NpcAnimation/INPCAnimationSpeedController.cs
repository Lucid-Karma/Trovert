using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INPCAnimationSpeedController : MonoBehaviour
{
    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    private string _animationSpeedName = "GoofyRunSpeed";
    private float _normalSpeed = 1f;
    private float _delayedSpeed = 0.5f;


    void OnEnable()
    {
        EventManager.OnTimeBlend.AddListener(PerformMotionDelayed);
        EventManager.OnTimeFlow.AddListener(PerformNormalMotion);
    }
    void OnDisable()
    {
        EventManager.OnTimeBlend.RemoveListener(PerformMotionDelayed);
        EventManager.OnTimeFlow.RemoveListener(PerformNormalMotion);
    }


    private void PerformMotionDelayed()
    {
        Animator.SetFloat(_animationSpeedName, _delayedSpeed);
    }

    private void PerformNormalMotion()
    {
        Animator.SetFloat(_animationSpeedName, _normalSpeed);
    }
}
