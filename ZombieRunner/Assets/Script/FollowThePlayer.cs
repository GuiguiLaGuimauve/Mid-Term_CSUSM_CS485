using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowThePlayer : MonoBehaviour {

    public Transform position;

    // Use this for initialization
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = position.position;
    }

    private void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = position.position;
    }
}
