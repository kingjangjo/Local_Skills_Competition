using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeStop : MonoBehaviour
{
    Image screenProduction;
    private void Start()
    {
        screenProduction = GameObject.FindGameObjectWithTag("ScreenProduction").GetComponent<Image>();
        StartCoroutine(TimeStopStart());
    }
    IEnumerator TimeStopStart()
    {
        GameObject[] shoots = GameObject.FindGameObjectsWithTag("Shoot");
        foreach (var sh in shoots)
        {
            if (sh != null)
            {
                sh.GetComponent<RaiderShoot>().isStop = true;
                sh.GetComponent<RaiderShoot>().isFindTarget = false;
            }
        }
        yield return null;
        for (int i = 150; i >= 0; i--)
        {
            screenProduction.color = new Color(0.2509804f, 0.8726904f, 1, i / 255.0f);
            yield return new WaitForSeconds(0.02f);
        }
        foreach (var sh in shoots)
        {
            if (sh != null)
            {
                sh.GetComponent<RaiderShoot>().isStop = false;
                if(!sh.GetComponent<RaiderShoot>().ownObject.CompareTag("Player"))
                    sh.GetComponent<RaiderShoot>().isFindTarget = true;
            }
        }
        yield return null;
        Destroy(this);
    }
}
