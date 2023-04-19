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
        currentState.UpdateState(this);
    }
    
    public override void StartState()
    {
        currentState = inPatrolState;
        currentState.EnterState(this);

        base.StartState();
    }

    public override void Patrol()
    {
        base.Patrol();

        if (!FsmManager.Instance.IsCharacterCommunicating)  // for one npc at a time.   ???
        {
            if(distance <= 2f)
            {
                executingNpcState = ExecutingNpcState.CHASE;
            } 
        }
    }

    public void Chase()
    {
        distance = Vector3.Distance(Agent.transform.position, pc.position);

        if(Agent.remainingDistance <= Agent.stoppingDistance)
        {
            executingNpcState = ExecutingNpcState.CHAT;
        }

        if(distance >= 5.0f)
        {
            executingNpcState = ExecutingNpcState.PATROL;
        }
        else
            Agent.destination = pc.position;
    }

    public void SwitchState(IntrovertNPCStates nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }
}
