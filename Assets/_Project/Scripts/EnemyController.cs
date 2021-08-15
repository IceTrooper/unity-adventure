using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent => navMeshAgent;
    private NavMeshAgent navMeshAgent = null;
    public Animator AnimatorController => animatorController;
    private Animator animatorController;

    public bool FollowEnabled => followEnabled;
    private bool followEnabled = true;

    private void OnEnable()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animatorController = GetComponent<Animator>();
    }

    public bool SetTarget(Vector3 position)
    {
        return navMeshAgent.SetDestination(position);
    }
}
