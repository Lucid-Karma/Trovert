using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntrovertNpcFsm : NpcFSM
{
    public IntrovertNPCStates currentState;
    public ChaseState chaseState = new ChaseState();
    public InPatrolState inPatrolState = new InPatrolState();
    public InChatState inChatState = new InChatState();


    void Update()
    {
        if(GameManager.Instance.IsLevelFail || GameManager.Instance.IsLevelSuccess)     return;

        currentState.UpdateState(this);
    }
    
    public override void StartState()
    {
        executingNpcState = ExecutingNpcState.CHASE;

        currentState = chaseState;
        currentState.EnterState(this);

        base.StartState();
    }

    public Vector3 escapePoint;
    public override void Patrol()
    {
        base.Patrol();

        if (!FsmManager.Instance.IsCharacterCommunicating)  // for one npc at a time.   ???
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

        // if(distance >= 20.0f)
        // {
        //     executingNpcState = ExecutingNpcState.PATROL;
        // }
        // else
            //Agent.destination = pc.position;
            
    }

    public void SwitchState(IntrovertNPCStates nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }
}