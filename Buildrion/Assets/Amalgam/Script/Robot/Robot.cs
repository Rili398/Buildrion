using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum RobotState
{
    Rest = 0,
    Moving,
    Working,
    Return,
    RS_MAX,
}

[RequireComponent(typeof(NavMeshAgent))]
public class Robot : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private RobotState robotState;
    private GameObject robotbase;

    [SerializeField] private Animator animator;
 
    public float warkPower { get; set; }

    // Start is called before the first frame update
    private void Awake()
    {
        robotState = RobotState.Rest;
        robotbase = GameObject.FindGameObjectWithTag("RobotBase");
    }

    //=========================================================================

    //ñ⁄ìIínê›íË
    public void SetDestination(Vector3 distPoint)
    {
        agent.destination = distPoint;
        animator.SetBool("walk", true);
    }

    public Vector3 GetDestination()
    {
        return agent.destination;
    }

    //
    public void SetRState(RobotState rs)
    {
        robotState = rs;

        if(robotState == RobotState.Return)
        {
            SetDestination(robotbase.transform.position);
        }

        if(robotState == RobotState.Rest)
        {
            animator.SetBool("walk", false);
        }
    }

    public RobotState GetRState()
    {
        return robotState;
    }
}
