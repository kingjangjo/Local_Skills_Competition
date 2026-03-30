using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject player;
    public Rigidbody playerRigidbody;
    public float speed = 8.0f;
    public float rotateSpeed = 8.0f;

    private void Update()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float verti = Input.GetAxisRaw("Vertical");
        float forwardSpeed = Vector3.Dot(playerRigidbody.linearVelocity, transform.forward);

        if (verti > 0)
        {
            playerRigidbody.linearVelocity = transform.forward * verti * speed;
        }
        else if (verti < 0)
        {
            if (forwardSpeed > 0.1f)
            {
                playerRigidbody.linearVelocity = Vector3.Lerp(playerRigidbody.linearVelocity, Vector3.zero, 0.15f); // 0.15f는 브레이크 강도
            }
            else
            {
                playerRigidbody.linearVelocity = Vector3.zero;
            }
        }
        else
        {
            playerRigidbody.linearVelocity = Vector3.Lerp(playerRigidbody.linearVelocity, Vector3.zero, 0.05f);
        }
        transform.Rotate(0, hori * rotateSpeed, 0);
    }
}