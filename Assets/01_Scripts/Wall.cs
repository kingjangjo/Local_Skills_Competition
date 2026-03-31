using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float knockbackStrength = 10f;
    public Vector3 dir;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌 감지: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlayerAttack(other));
        }
    }
    IEnumerator PlayerAttack(Collider other)
    {
        Debug.Log("PlayerAttack 코루틴 시작");
        Rigidbody playerRb = other.gameObject.GetComponent<Rigidbody>();

        playerRb.AddForce(dir * knockbackStrength, ForceMode.Impulse);
        other.gameObject.GetComponent<PlayerMove>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        other.gameObject.GetComponent<PlayerMove>().enabled = true;
        yield return null;
    }
}
