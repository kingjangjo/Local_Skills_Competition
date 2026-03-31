using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyHp))]
public class BossCrash : MonoBehaviour
{
    public float knockbackStrength = 10f;
    public Rigidbody enemyRb;
    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlayerAttack(other));
        }
    }
    IEnumerator PlayerAttack(Collider other)
    {
        Rigidbody playerRb = other.gameObject.GetComponent<Rigidbody>();
        Vector3 direction = (other.transform.position - transform.position).normalized;
        Debug.Log(direction);
        playerRb.AddForce(direction * knockbackStrength, ForceMode.Impulse);
        other.gameObject.GetComponent<PlayerMove>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        other.gameObject.GetComponent<PlayerMove>().enabled = true;
        yield return null;
    }
}