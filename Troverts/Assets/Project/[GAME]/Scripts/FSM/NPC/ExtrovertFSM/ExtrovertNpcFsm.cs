using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrovertNpcFsm : NpcFSM
{
    [HideInInspector]
    public Vector3 escapePoint;

    // [HideInInspector]
    // public Vector3 distanceVec;

    public ExtrovertNPCStates currentState;
    public EscapeState escapeState = new EscapeState();
    public ExChatState exChatState = new ExChatState();
    public ExPatrolState exPatrolState = new ExPatrolState();


    void Update()
    {
        if(GameManager.Instance.IsLevelFail || GameManager.Instance.IsLevelSuccess)     return;
        
        currentState.UpdateState(this);
    }
    
    public override void StartState()
    {
        executingNpcState = ExecutingNpcState.PATROL;
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
            if (!IsNpcMet)
            {
                if(distance >= 6.0f && distance <= 10.0f)
                {
                    executingNpcState = ExecutingNpcState.ESCAPE;
                }
            }
        }
    }
    
    public void Escape()
    {
        distance = Vector3.Distance(Agent.transform.position, pc.position);

        if(Agent.remainingDistance <= Agent.stoppingDistance)
        {
            escapePoint = Agent.transform.position + distanceVec;
            Agent.SetDestination(escapePoint);
        } 

        if(distance <= 1.5f)    
        {
            executingNpcState = ExecutingNpcState.CHAT;
        }
        else if (distance >= 20.0f)
        {
            executingNpcState = ExecutingNpcState.PATROL;
        }   
    }

    public override void Meet()
    {
        Debug.Log("Press F");
    }
    public override void Die()
    {
        OnNpcDie.Invoke();
        gameObject.SetActive(false);
    }
    
    public void SwitchState(ExtrovertNPCStates nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }
}
