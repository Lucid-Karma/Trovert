using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntrovertNpcFsm : NpcFSM
{
    public IntrovertNPCStates currentState;
    public ChaseState chaseState = new ChaseState();
    public InPatrolState inPatrolState = new InPatrolState();
    public InChatState inChatState = new InChatState();
    public ShockState shockState = new ShockState();
    public InDeadState inDeadState = new InDeadState();
    public InWaitState inWaitState = new InWaitState();
    public InEscapeState inEscapeState = new InEscapeState();


    void OnEnable()
    {
        EventManager.OnNpcGetSmart.AddListener(() => executingNpcState = ExecutingNpcState.CHASE);
        EventManager.OnNpcShock.AddListener(Shock);
    }
    void OnDisable()
    {
        EventManager.OnNpcGetSmart.RemoveListener(() => executingNpcState = ExecutingNpcState.CHASE);
        EventManager.OnNpcShock.RemoveListener(Shock);
    }

    void Update()
    {
        if(GameManager.Instance.IsLevelFail || GameManager.Instance.IsLevelSuccess)     return;

        currentState.UpdateState(this);
    }
    
    public override void StartState()
    {
        if(NPCManager.Instance.isINpcSurprise)
        {
            executingNpcState = ExecutingNpcState.CHASE;

            currentState = chaseState;
            currentState.EnterState(this);
        }
        else
        {
            executingNpcState = ExecutingNpcState.WAIT;

            currentState = inWaitState;
            currentState.EnterState(this);
        }
        
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
                executingNpcState = ExecutingNpcState.CHASE;
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
    
    public override void Die()
    {
        executingNpcState = ExecutingNpcState.DEAD;
    }
    public override void Escape()
    {
        base.Escape();
    }
    
    public IEnumerator DelayEscape()
    {
        yield return new WaitForSeconds(1.5f);

        executingNpcState = ExecutingNpcState.ESCAPE;
    }
    

    public void SwitchState(IntrovertNPCStates nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }
}
