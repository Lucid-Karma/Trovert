using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public enum ExecutingNpcState
{
    PATROL,
    CHASE,
    ESCAPE,
    CHAT
}
public abstract class NpcFSM : MonoBehaviour//, IInteractable
{
    #region FSM
    public ExecutingNpcState executingNpcState;
    public NPCStates currentState;
    public PatrolState patrolState = new PatrolState();
    public ChaseState chaseState = new ChaseState();
    public EscapeState escapeState = new EscapeState();
    public ChatState chatState = new ChatState();
    #endregion

    #region Events
    [HideInInspector]
    public UnityEvent OnNpcIdle = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnNpcWalk = new UnityEvent();
    #endregion
    
    #region Components
    private NavMeshAgent agent;
    public NavMeshAgent Agent{ get { return (agent == null) ? agent = GetComponent<NavMeshAgent>() : agent; } }
    #endregion
    
    #region Parameters

    #region NavMesh
    private Transform pc;
    private float range = 10.0f;
    #endregion
    
    #endregion
    

    void Start()
    {
        executingNpcState = ExecutingNpcState.PATROL;
        currentState = patrolState;
        currentState.EnterState(this);

        pc = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void Move()
    {
        // codes for npc movement.
    }

    #region Patrol Methods
    
    [HideInInspector]
    public float distance;
    public void Patrol()
    {
        if(Agent.remainingDistance <= Agent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (RandomPoint(new Vector3(0, 0, 0), range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                Agent.SetDestination(point);
            }
        }

        distance = Vector3.Distance(Agent.transform.position, pc.position);

        if(PlayerPrefs.GetString("selected_character") == "introvert")
        {
            if (!FsmManager.Instance.IsCharacterCommunicating)  // for one npc at a time.   ???
            {
                if(distance <= 2f)
                {
                    executingNpcState = ExecutingNpcState.CHASE;
                } 
            }
        }
        else if(PlayerPrefs.GetString("selected_character") == "extrovert")
        {
            if(distance <= 3f)
            {
                executingNpcState = ExecutingNpcState.ESCAPE;
            } 
        }
        
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        { 
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
    #endregion

    public bool hasMet = false;
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

    public IEnumerator Chat()
    {
        yield return new WaitForSeconds(3.0f); 

        executingNpcState = ExecutingNpcState.PATROL;
    }

    [HideInInspector]
    public Vector3 pcPoint, escapePoint;
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

    public void SwitchState(NPCStates nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }

    //public abstract void Interact();
    // public void Communicate()
    // {
    //     executingNpcState = ExecutingNpcState.CHAT;
    // }
}
