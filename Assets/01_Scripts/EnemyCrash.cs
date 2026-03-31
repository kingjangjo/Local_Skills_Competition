using UnityEngine;

public class EnemyCrash : MonoBehaviour
{
    public float knockbackStrength = 10f;
    public Rigidbody enemyRb;
    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        enemyRb.linearVelocity = Vector3.Lerp(enemyRb.linearVelocity, Vector3.zero, 0.01f); // 0.15f는 브레이크 강도
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 direction = (transform.position - other.transform.position).normalized;

            enemyRb.AddForce(direction * knockbackStrength, ForceMode.Impulse);
        }
    }
}