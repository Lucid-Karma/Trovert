using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntrovertNpcFsm : NpcFSM
{
    public IntrovertNPCStates currentState;
    public ChaseState chaseState = new ChaseState();
    public InPatrolState inPatrolState = new InPatrolState();
    public InChatState inChatState = new InChatState();
    public InWaitState inWaitState = new InWaitState();


    void OnEnable()
    {
        EventManager.OnNpcGetSmart.AddListener(() => executingNpcState = ExecutingNpcState.CHASE);
    }
    void OnDisable()
    {
        EventManager.OnNpcGetSmart.RemoveListener(() => executingNpcState = ExecutingNpcState.CHASE);
    }

    void Update()
    {
        if(GameManager.Instance.IsLevelFail || GameManager.Instance.IsLevelSuccess)     return;

        currentState.UpdateState(this);
    }
    
    public override void StartState()
    {
        executingNpcState = ExecutingNpcState.WAIT;

        currentState = inWaitState;
        currentState.EnterState(this);

        base.StartState();
    }

    public Vector3 escapePoint;
    public override void Patrol()
    {
        base.Patrol();

        if (!FsmManager.Instance.IsCharacterCommunicating)  // for one npc at a time. 
        {
            if (!IsNpcMet)
            {
                // if(distance <= 6.0f)
                // {
                    executingNpcState = ExecutingNpcState.CHASE;
                // }  
            }
        }
    }

    public void Chase()
    {
        distance = Vector3.Distance(Agent.transform.position, pc.position);

        if (!FsmManager.Instance.IsCharacterCommunicating)
        {
            if (!IsNpcMet)
            {
                if(distance <= 1.5f)    
                {
                    executingNpcState = ExecutingNpcState.CHAT;
                }
                else    Agent.SetDestination(pc.position);
            }
        }
        else    executingNpcState = ExecutingNpcState.PATROL;
    }

    public void SwitchState(IntrovertNPCStates nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }
}
