using System.Collections.Generic;
using UnityEngine;

public class SlowField : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Shoot"))
            other.gameObject.GetComponent<RaiderShoot>().speed *= 0.1f;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Shoot"))
            other.gameObject.GetComponent<RaiderShoot>().speed *= 10 / 1f;
    }
}