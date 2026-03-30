using System.Collections;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    public GameObject reflection;
    public GameObject slowField;
    public GameObject blackHole;
    public GameObject SetTarget;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(Reflect());
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameObject.AddComponent<TimeStop>();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(SpawnSlowField());
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            StartCoroutine(BlackHole());
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            gameObject.AddComponent<Induction>();
        }
    }
    IEnumerator Reflect()
    {
        GameObject reflect = Instantiate(reflection, this.gameObject.transform.position, Quaternion.identity);
        reflect.transform.SetParent(this.gameObject.transform);
        this.gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(0.8f);
        this.gameObject.GetComponent<Collider>().enabled = true;
        if(reflect != null)
        {
            Destroy(reflect);
        }
    }
    IEnumerator SpawnSlowField()
    {
        GameObject reflect = Instantiate(slowField, this.gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5.3f);
        if (reflect != null)
        {
            Destroy(reflect);
        }
    }
    IEnumerator BlackHole()
    {
        GameObject blackHole = Instantiate(this.blackHole, this.gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5.3f);
        if (blackHole != null)
        {
            Destroy(blackHole);
        }
    }
}