using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints; //array of waypoints/transforms | a collection of empty GameObjects and use their positions as the waypoints
    int m_CurrentWaypointIndex; //index of the current waypoint

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position); //set the destination of the NavMeshAgent to the first waypoint
        
    }

    // Update is called once per frame
    void Update()
    {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination (waypoints[m_CurrentWaypointIndex].position); //set the destination of the NavMeshAgent to the next waypoint

        }
        
    }
}
