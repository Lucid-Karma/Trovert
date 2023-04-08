using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExecutingNpcState
{
    PATROL,
    CHASE,
    ESCAPE,
    CHAT
}
public abstract class NpcFSM : MonoBehaviour, IInteractable
{
    public ExecutingNpcState executingNpcState;
    public NPCStates currentState;
    public PatrolState patrolState = new PatrolState();
    public ChaseState chaseState = new ChaseState();
    public EscapeState escapeState = new EscapeState();
    public ChatState chatState = new ChatState();

    void Start()
    {
        executingNpcState = ExecutingNpcState.PATROL;
        currentState = patrolState;
        currentState.EnterState(this);
    }

    public void Move()
    {
        // codes for npc movement.
    }

    public void SwitchState(NPCStates nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }

    public abstract void Interact();
    public void Communicate()
    {
        executingNpcState = ExecutingNpcState.CHAT;
    }
}
