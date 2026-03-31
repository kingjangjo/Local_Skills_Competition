using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    Image screenProduction;
    private void Start()
    {
        screenProduction = GameObject.FindGameObjectWithTag("ScreenProduction").GetComponent<Image>();
        StartCoroutine(Boom());
    }
    IEnumerator Boom()
    {
        GameObject[] shoots = GameObject.FindGameObjectsWithTag("Shoot");
        foreach (var sh in shoots)
        {
            if (sh != null)
            {
                Destroy(sh.gameObject);
            }
        }
        yield return null;
        for (int i = 150; i >= 0; i--)
        {
            screenProduction.color = new Color(0.4150943f, 0.4150943f, 0.4716981f, i / 255.0f);
            yield return new WaitForSeconds(0.005f);
        }
        Destroy(this);
    }
}
