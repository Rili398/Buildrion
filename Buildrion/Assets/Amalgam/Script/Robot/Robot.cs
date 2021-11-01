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
    private NavMeshAgent agent;
    private RobotState robotState;

    public float warkPower { get; set; }

    // Start is called before the first frame update
    private void Awake()
    {
        robotState = RobotState.Rest;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //=========================================================================

    //目的地設定
    public void SetDestination(Vector3 distPoint)
    {
        agent.destination = distPoint;
    }

    //
    public void SetRState(RobotState rs)
    {
        robotState = rs;
    }
}
