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

    public ExtrovertNPCStates currentState;
    public EscapeState escapeState = new EscapeState();
    public ExChatState exChatState = new ExChatState();
    public ExPatrolState exPatrolState = new ExPatrolState();


    private bool isExtrovertNpcMet;     // control if the agent is met before.

    [HideInInspector]
    public bool IsExtrovertNpcMet { get { return isExtrovertNpcMet; } set { isExtrovertNpcMet = value; } }


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

        // control if now, an agent is on chat state. If so do not fulfill the conditions & 
        // control if the agent is met before. If that so, do not escape or chat.
        if (!FsmManager.Instance.IsCharacterCommunicating)    
        {
            if (!IsExtrovertNpcMet)
            {
                if(distance >= 3.0f && distance <= 6.0f)
                {
                    executingNpcState = ExecutingNpcState.ESCAPE;
                    return;
                }
                else if(distance <= 1.5f)    
                {
                    executingNpcState = ExecutingNpcState.CHAT;
                    return;
                }
            }
        }
    }
    
    public void Escape()
    {
        if(distance <= 1.5f)    
        {
            executingNpcState = ExecutingNpcState.CHAT;
            return;
        }
        else if (distance >= 20.0f)
        {
            executingNpcState = ExecutingNpcState.PATROL;
            return;
        }

        if(Agent.remainingDistance <= Agent.stoppingDistance)
        {
            escapePoint = Agent.transform.position + distanceVec;
            Agent.SetDestination(escapePoint);
        } 

        distance = Vector3.Distance(Agent.transform.position, pc.position);
    }

    public void ChangeColor()
    {
        Agent.GetComponentInChildren<SkinnedMeshRenderer>().material = metMat;
    }

    public void SwitchState(ExtrovertNPCStates nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }
}
