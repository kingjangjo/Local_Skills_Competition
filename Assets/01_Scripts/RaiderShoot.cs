using System.Collections;
using UnityEngine;

public class RaiderShoot : MonoBehaviour
{
    public GameObject tracingTarget;
    private Vector3 tracingObjectPosition;
    public bool isFindTarget = true;
    [Header("따라가는 시간")]
    public float speed = 5.0f;
    [Header("따라가는 시간")]
    public float tracingTime = 3.0f;

    [Header("추적 여부")]
    public bool isTracing = true;

    [Header("폭발 이펙트")]
    public GameObject explosionEff;

    public GameObject ownObject;

    [Header("데미지")]
    public float damage;

    public bool isStop = false;

    public Rigidbody shootRigidbody;
    private void Start()
    {
        tracingTarget = FindFirstObjectByType<PlayerMove>().gameObject;
        StartCoroutine(ChasePlayer());
        Destroy(gameObject, 10f);

        shootRigidbody = GetComponent<Rigidbody>();
    }
    IEnumerator ChasePlayer()
    {
        yield return new WaitForSeconds(tracingTime);
        isFindTarget = false;
    }
    private void Update()
    {
        if (isFindTarget && isTracing)
        {
            FindTargetPosition();
            Vector3 direction = (tracingObjectPosition - transform.position).normalized;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2 * Time.deltaTime);

            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
            shootRigidbody.linearVelocity = transform.forward * speed;
        }
        else if (isStop) {
            if (GetComponent<Rigidbody>() != null)
            {
                var rb = GetComponent<Rigidbody>();
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
        else
        {
            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
            shootRigidbody.linearVelocity = transform.forward * speed;
        }
    }
    void FindTargetPosition()
    {
        if (tracingTarget == null)
            isFindTarget = false;
        else
            tracingObjectPosition = tracingTarget.transform.position;
    }
    public void SetTargetPosition(GameObject target)
    {
        tracingObjectPosition = target.transform.position;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (ownObject == null || collision.gameObject == ownObject.gameObject)
            return;
        if (collision.CompareTag("Obstacle"))
            return;
        if (collision.gameObject.GetComponent<HpScript>() != null)
        {
            StartCoroutine(Attack());
            if (ownObject.GetComponent<HpScript>() != null)
            {
                collision.GetComponent<HpScript>().TakeDamage(damage);
            }
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (ownObject == null || collision.gameObject == ownObject.gameObject)
    //        return;
    //    if (collision.gameObject.GetComponent<HpScript>() != null)
    //    {
    //        StartCoroutine(Attack());
    //        if (ownObject.GetComponent<HpScript>() != null)
    //        {
    //            collision.gameObject.GetComponent<HpScript>().TakeDamage(damage);
    //        }
    //    }
    //}
    IEnumerator Attack()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<TrailRenderer>().enabled = false;
        var explosion = Instantiate(explosionEff, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(explosion);
        Destroy(gameObject);
    }
}