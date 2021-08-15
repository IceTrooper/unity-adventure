using UnityEngine;

public class SpiderBehaviour : MonoBehaviour
{
    [SerializeField] private MeleeWeapon meleeWeapon;
    [SerializeField] private float attackDistance = 3f;
    [SerializeField] private TargetScanner playerScanner;
    [SerializeField] private float timeToStopPursuit;

    private EnemyController enemyController = null;

    private Vector3 originalPosition;
    private Transform followTarget = null;
    private float timerSinceLostTarget = 0f;

    public static readonly int hashInPursuit = Animator.StringToHash("InPursuit");
    public static readonly int hashNearBase = Animator.StringToHash("NearBase");
    public static readonly int hashSpotted = Animator.StringToHash("Spotted");
    public static readonly int hashAttack = Animator.StringToHash("Attack");
    public static readonly int hashDie = Animator.StringToHash("Die");

    private void OnEnable()
    {
        enemyController = GetComponent<EnemyController>();
        originalPosition = transform.position;
    }

    private void Update()
    {
        FindTarget();
        CheckAttack();

        Vector3 toBase = originalPosition - transform.position;
        toBase.y = 0f;
        enemyController.AnimatorController.SetBool(hashNearBase, toBase.sqrMagnitude < 0.01f);
    }

    private void FindTarget()
    {
        Transform[] targets = playerScanner.Detect(transform);

        if(targets.Length > 0)
        {
            // Pick closest target
            Transform closestTarget = targets[0];
            float closestDistanceSqr = Vector3.SqrMagnitude(transform.position - closestTarget.position);
            for(int i=1; i<targets.Length; i++)
            {
                float distanceSqr = Vector3.SqrMagnitude(transform.position - targets[i].position);
                if(distanceSqr < closestDistanceSqr)
                {
                    closestDistanceSqr = distanceSqr;
                    closestTarget = targets[i];
                }
            }

            if(followTarget == null)
            {
                // We just saw the player
                enemyController.AnimatorController.SetTrigger(hashSpotted);
                StartPursuit();
            }

            followTarget = closestTarget;
            enemyController.SetTarget(followTarget.position);
        }
        else
        {
            if(followTarget == null)
            {
                timerSinceLostTarget = 0f;
            }
            else
            {
                // We lost the target
                timerSinceLostTarget += Time.deltaTime;

                // Pursuit player even if not seen until timer is finished.
                if(timerSinceLostTarget >= timeToStopPursuit)
                {
                    followTarget = null;
                    enemyController.SetTarget(originalPosition);
                    StopPursuit();
                }
            }
        }
    }

    private void StartPursuit()
    {
        enemyController.AnimatorController.SetBool(hashInPursuit, true);
    }

    private void StopPursuit()
    {
        enemyController.AnimatorController.SetBool(hashInPursuit, false);
    }

    private void CheckAttack()
    {
        if(followTarget != null)
        {
            Vector3 toTarget = followTarget.position - transform.position;
            
            if(toTarget.sqrMagnitude < attackDistance * attackDistance)
            {
                enemyController.AnimatorController.SetTrigger(hashAttack);
            }
        }
    }

    public void Attack()
    {
        meleeWeapon.MakeAttack();
    }

    public void Die()
    {
        enemyController.NavMeshAgent.isStopped = true;
        GetComponent<Collider>().enabled = false;
        enemyController.AnimatorController.SetTrigger(hashDie);
    }

    private void OnDrawGizmosSelected()
    {
        playerScanner.EditorGizmo(transform);
    }
}
