using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrovertNpcFsm : NpcFSM
{
    [HideInInspector]
    public Vector3 pcPoint, escapePoint;

    public ExtrovertNPCStates currentState;
    public EscapeState escapeState = new EscapeState();
    public ExChatState exChatState = new ExChatState();
    public ExPatrolState exPatrolState = new ExPatrolState();


    void Update()
    {
        currentState.UpdateState(this);
    }
    
    public override void StartState()
    {
        currentState = exPatrolState;
        currentState.EnterState(this);

        base.StartState();
    }

    public override void Patrol()
    {
        base.Patrol();

        if (!FsmManager.Instance.IsCharacterCommunicating)
        {
            if(/*distance >= 1.5f && */distance <= 4f)
            {
                executingNpcState = ExecutingNpcState.ESCAPE;
            } 
        }
        
        // else if(distance <= 1.5f)    
        // {
        //     executingNpcState = ExecutingNpcState.CHAT;
        // }
    }
    
    [HideInInspector]
    public Vector3 distanceVec;
    public void Escape()
    {
        distance = Vector3.Distance(Agent.transform.position, pc.position);
        escapePoint = Agent.transform.position + distanceVec;

        Agent.SetDestination(escapePoint);

        if(distance <= 1.5f)    
        {
            executingNpcState = ExecutingNpcState.CHAT;
        }
        else if (distance >= 15f)
        {
            executingNpcState = ExecutingNpcState.PATROL;
        }
    }

    public void SwitchState(ExtrovertNPCStates nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }
}
