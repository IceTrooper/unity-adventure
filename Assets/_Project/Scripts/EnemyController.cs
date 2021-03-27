using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent => navMeshAgent;
    private NavMeshAgent navMeshAgent = null;
    public bool FollowEnabled => followEnabled;
    private bool followEnabled = true;

    private void OnEnable()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public bool SetTarget(Vector3 position)
    {
        return navMeshAgent.SetDestination(position);
    }
}
