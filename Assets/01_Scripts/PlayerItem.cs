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
        if (Input.GetKeyDown(KeyCode.Alpha1) && PlayerManager.instance.haveParts[1] == 1)
        {
            StartCoroutine(Reflect());
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && PlayerManager.instance.haveParts[2] == 1)
        {
            gameObject.AddComponent<TimeStop>();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && PlayerManager.instance.haveParts[4] == 1)
        {
            StartCoroutine(SpawnSlowField());
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && PlayerManager.instance.haveParts[3] == 1)
        {
            StartCoroutine(BlackHole());
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && PlayerManager.instance.haveParts[0] == 1)
        {
            gameObject.AddComponent<Induction>();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            gameObject.AddComponent<Bomb>();
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