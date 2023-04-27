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
    ESCAPE
}
public abstract class NpcFSM : MonoBehaviour
{
    #region FSM
    public ExecutingNpcState executingNpcState;
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
    [HideInInspector]
    public Transform pc;
    private float range = 95.0f;

    [HideInInspector]
    public float distance;
    #endregion

        #region Rotation
    Vector3 direction;
    Quaternion lookRotation;
    private float rotationSpeed = 20.0f;
    #endregion
    
    #endregion
    

    void Start()    
    {
        executingNpcState = ExecutingNpcState.PATROL;
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
            if (RandomPoint(new Vector3(0, 0, 0), range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                Agent.SetDestination(point);
            }
        }

        distance = Vector3.Distance(Agent.transform.position, pc.position);
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
      
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

    public void RotateToPC(Vector3 pcPos)
    {
        direction = (pcPos - Agent.transform.position).normalized;
        lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        Agent.transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    public void Chat(UnityEvent pointEvent)
    {
        Agent.SetDestination(transform.position);

        EventManager.OnNpcGreet.Invoke();

        if (Input.GetMouseButtonDown(0))
        {
            EventManager.OnNpcGreetingEnd.Invoke();
            pointEvent.Invoke();
            executingNpcState = ExecutingNpcState.PATROL;
        }
    }
}
