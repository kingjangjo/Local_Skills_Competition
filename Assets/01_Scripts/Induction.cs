using UnityEngine;

public class Induction : MonoBehaviour
{
    public int rayCount = 100;
    public float viewAngle = 60f;
    public float viewDistance = 500f;
    public GameObject setTarget;
    private void Start()
    {
        setTarget = Resources.Load<GameObject>("TargetSet");
        Debug.LogWarningFormat(setTarget.name);
        Destroy(this, 0.1f);
    }

    private void Update()
    {
        float startAngle = -viewAngle / 2.0f;
        float angleStep = viewAngle / (rayCount - 1);

        for (int i = 0; i < rayCount; i++)
        {
            float currentAngle = startAngle + (angleStep * i);

            Quaternion rotation = Quaternion.Euler(0, currentAngle, 0);

            Vector3 dir = rotation * transform.forward;

            if (Physics.Raycast(transform.position, dir, out RaycastHit hit, viewDistance))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    GameObject[] shoots = GameObject.FindGameObjectsWithTag("Shoot");
                    foreach(var shot in shoots)
                    {
                        if(shot.GetComponent<RaiderShoot>() != null)
                        {
                            var targetSet = Instantiate(setTarget, hit.collider.gameObject.transform.position, Quaternion.identity);
                            targetSet.transform.SetParent(hit.collider.transform);
                            shot.GetComponent<RaiderShoot>().tracingTarget = hit.collider.gameObject;
                            shot.GetComponent<RaiderShoot>().ownObject = this.gameObject;
                            shot.GetComponent<RaiderShoot>().tracingTime += 9999;
                        }
                    }
                    Destroy(this);
                }
            }
            else
                Debug.DrawRay(transform.position, dir * viewDistance, Color.green);
        }
    }
}
