using System.Collections;
using UnityEngine;

public class Shootter : MonoBehaviour
{
    [Header("공격 딜레이")]
    public float shootDelay ;
    [Header("미사일 종류")]
    public GameObject shootRocket;
    [Header("미사일 발사 횟수")]
    public int shootCount = 0;
    [Header("미사일 연사 횟수")]
    public int shootAutoCount = 0;
    [Header("연사속도")]
    public float AutoDelay = 0;
    [Header("산탄 탄퍼짐 정도")]
    public float spreadAngle = 0;

    public float shootForce = 0;

    public GameObject target;
    private void Start()
    {
        target = FindFirstObjectByType<PlayerMove>().gameObject;
        StartCoroutine(ShootRocket());
    }
    private void Update()
    {
        transform.LookAt(target.transform);
    }
    IEnumerator ShootRocket()
    {
        while (true)
        {
            float startAngle = -spreadAngle / 2;
            float angleStep = 0;
            if (shootCount > 1)
                angleStep = spreadAngle / (shootCount - 1);
            for(int i = 1; i <= shootAutoCount; i++)
            {
                for(int j = 1; j <= shootCount; j++)
                {
                    float currentAngle = startAngle + (angleStep * j);
                    Quaternion rotation = Quaternion.Euler(0, currentAngle, 0);
                    Vector3 shootDirection = rotation * transform.forward;
                    var shot = Instantiate(shootRocket, transform.position, Quaternion.LookRotation(shootDirection));
                    shot.GetComponent<RaiderShoot>().ownObject = this.gameObject;
                    shot.GetComponent<Rigidbody>().AddForce(shot.transform.forward * shootForce, ForceMode.Impulse);
                }
                yield return new WaitForSeconds(AutoDelay);
            }
            yield return new WaitForSeconds(shootDelay);
        }
    }
}
