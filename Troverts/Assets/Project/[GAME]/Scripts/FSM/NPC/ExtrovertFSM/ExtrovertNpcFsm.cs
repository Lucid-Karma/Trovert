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

        if(distance <= 3f)
        {
            executingNpcState = ExecutingNpcState.ESCAPE;
        } 
    }
    
    public void Escape(float distance)
    {
        pcPoint = pc.position;
        escapePoint = new Vector3(-pcPoint.x, pcPoint.y, -pcPoint.z);

        Agent.SetDestination(escapePoint);

        if(distance <= 1.5f)    
        {
            executingNpcState = ExecutingNpcState.CHAT;
        }
        else if(Agent.remainingDistance <= Agent.stoppingDistance)
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
