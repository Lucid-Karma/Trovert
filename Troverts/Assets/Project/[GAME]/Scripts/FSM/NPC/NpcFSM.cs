using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public enum ExecutingNpcState
{
    PATROL,
    CHAT,
    CHASE,
    ESCAPE,
    SHOCK,

    WAIT
}
public abstract class NpcFSM : MonoBehaviour, IInteractable
{
    #region FSM
    public ExecutingNpcState executingNpcState;
    #endregion

    #region Events
    [HideInInspector]
    public UnityEvent OnNpcIdle = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnNpcWalk = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnNpcRun = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnNpcDie = new UnityEvent();
    #endregion
    
    #region Components
    private NavMeshAgent agent;
    public NavMeshAgent Agent{ get { return (agent == null) ? agent = GetComponent<NavMeshAgent>() : agent; } }
    #endregion
    
    #region Parameters

        #region NavMesh
        [HideInInspector]
        public Transform pc;
        public Vector3 pcPoint, distanceVec;

        [HideInInspector]
        public float distance;
        [HideInInspector]
        public float sprintSpeed = 7.0f;
        #endregion

        #region Rotation
        Vector3 direction;
        Quaternion lookRotation;
        private float rotationSpeed = 20.0f;
    #endregion

        #region Controllers
        private bool isNpcMet;     // control if the agent is met before.

        [HideInInspector]
        public bool IsNpcMet { get { return isNpcMet; } set { isNpcMet = value; } }
        #endregion  

        #region Others
        public Material metMat;
        #endregion

    #endregion
    

    void Start()    
    {
        StartState();
    }

    public virtual void StartState()
    {
        pc = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    #region Patrol Methods

    private Vector3 point;
    Vector3 randomPoint;
    NavMeshHit hit;
    public virtual void Patrol()
    {
        if(Agent.remainingDistance <= Agent.stoppingDistance) //done with path
        {   
            Agent.SetDestination(GetRandomPos(Vector3.zero, 95.0f));
        }

        distance = Vector3.Distance(Agent.transform.position, pc.position);
    }

    private Vector3 GetRandomPos(Vector3 center, float range)
    {
        randomPoint = center + Random.insideUnitSphere * range;
        NavMesh.SamplePosition(randomPoint, out hit, range, NavMesh.AllAreas);

        return hit.position;
    }
    #endregion

    public void RotateToPC(Vector3 pcPos)
    {
        direction = (pcPos - Agent.transform.position).normalized;
        lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        Agent.transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    public void Chat(UnityEvent pointEvent)
    {
        Agent.SetDestination(transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            EventManager.OnNpcGreetingEnd.Invoke();
            pointEvent.Invoke();
            executingNpcState = ExecutingNpcState.PATROL;
        }
    }

    public void ChangeColor()
    {
        Agent.GetComponentInChildren<SkinnedMeshRenderer>().material = metMat;
    }

    public void Shock()
    {
        executingNpcState = ExecutingNpcState.SHOCK;
    }
    public abstract void Die();
}
