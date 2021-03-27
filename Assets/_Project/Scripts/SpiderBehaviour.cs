using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBehaviour : MonoBehaviour
{
    public TargetScanner playerScanner;
    public float timeToStopPursuit;

    private EnemyController enemyController = null;

    private Vector3 originalPosition;
    private Transform followTarget = null;
    private float timerSinceLostTarget = 0f;

    private void OnEnable()
    {
        enemyController = GetComponent<EnemyController>();
        originalPosition = transform.position;
    }

    private void Update()
    {
        FindTarget();
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

            followTarget = closestTarget;
            enemyController.SetTarget(followTarget.position);
            //if(followTarget == null)
            //{
            //    // We just saw the player
            //    followTarget = closestTarget;
            //}
            //else
            //{
            //    followTarget = closestTarget;
            //}
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

                if(timerSinceLostTarget >= timeToStopPursuit)
                {
                    followTarget = null;
                }
            }
        }

        if(followTarget == null)
        {
            // We just saw the player
            if(targets.Length > 0)
            {
                // Pick closest
                foreach(var t in targets)
                {
                    followTarget = t;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        playerScanner.EditorGizmo(transform);
    }
}
