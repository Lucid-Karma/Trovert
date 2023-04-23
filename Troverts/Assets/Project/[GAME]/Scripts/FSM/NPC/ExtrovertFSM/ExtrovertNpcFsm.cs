using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrovertNpcFsm : NpcFSM
{
    [HideInInspector]
    public Vector3 pcPoint, escapePoint;

    [HideInInspector]
    public Vector3 distanceVec;

    public Material metMat;
    private Material currentMat;

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
            if(distance <= 6.0f)
            {
                executingNpcState = ExecutingNpcState.ESCAPE;
            } 
        }
    }
    
    public void Escape()
    {
        
        if(Agent.remainingDistance <= Agent.stoppingDistance)
        {
            escapePoint = Agent.transform.position + distanceVec;
            Agent.SetDestination(escapePoint);
        } 

        if(distance <= 3.0f)    
        {
            executingNpcState = ExecutingNpcState.CHAT;
        }
        else if (distance >= 20.0f)
        {
            executingNpcState = ExecutingNpcState.PATROL;
        }

        distance = Vector3.Distance(Agent.transform.position, pc.position);
    }

    public void ChangeColor()
    {
        currentMat = Agent.GetComponent<Material>();
        currentMat = metMat;
    }

    public void SwitchState(ExtrovertNPCStates nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }
}
