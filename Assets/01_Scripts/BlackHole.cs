using Unity.VisualScripting;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float radius = 10f;
    public float pullStrength = 5f;
    public LayerMask targetLayer;

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, targetLayer);

        foreach(Collider hit in colliders)
        {
            Rigidbody shotRigidbody = hit.GetComponent<Rigidbody>();

            if (shotRigidbody != null)
            {
                Vector3 direction = transform.position - hit.transform.position;
                shotRigidbody.AddForce(direction.normalized * pullStrength, ForceMode.Acceleration);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}