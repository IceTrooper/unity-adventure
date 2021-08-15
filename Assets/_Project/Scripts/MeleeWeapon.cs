using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    [System.Serializable]
    public class AttackPoint
    {
        public float radius;
        public Vector3 offset;
        public Transform attackRoot;
    }

    [SerializeField] private LayerMask targetLayerMask;
    [SerializeField] private AttackPoint attackPoint;

    public void MakeAttack()
    {
        Vector3 worldPos = attackPoint.attackRoot.position + attackPoint.attackRoot.TransformVector(attackPoint.offset);

        Collider[] hitColliders = Physics.OverlapSphere(worldPos, attackPoint.radius, targetLayerMask, QueryTriggerInteraction.Ignore);
        foreach(var hc in hitColliders)
        {
            Damageable d = hc.GetComponent<Damageable>();
            if(d == null) return;
            d.ApplyDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint.attackRoot != null)
        {
            Vector3 worldPos = attackPoint.attackRoot.TransformVector(attackPoint.offset);

            Gizmos.color = new Color(1f, 0f, 0f, 0.4f);
            Gizmos.DrawSphere(attackPoint.attackRoot.position + worldPos, attackPoint.radius);
        }
    }
}
