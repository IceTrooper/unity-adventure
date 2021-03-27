using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TargetScanner
{
    public float detectionRadius = 10f;
    public LayerMask detectionLayerMask;
    public LayerMask viewBlockerLayerMask;

    public Transform[] Detect(Transform detector)
    {
        List<Transform> results = new List<Transform>();

        Collider[] hitColliders = Physics.OverlapSphere(detector.position, detectionRadius, detectionLayerMask, QueryTriggerInteraction.Ignore);
        foreach(var hc in hitColliders)
        {
            if(hc.CompareTag("Player"))
            {
                Vector3 toPlayer = hc.transform.position - detector.position;
                if(!Physics.Raycast(detector.position, toPlayer.normalized, detectionRadius, viewBlockerLayerMask, QueryTriggerInteraction.Ignore))
                {
                    results.Add(hc.transform);
                }
            }
        }

        return results.ToArray();
    }

    public void EditorGizmo(Transform transform)
    {
        Gizmos.color = new Color(0f, 0f, 0.7f, 1f);
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
