using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Attacked : MonoBehaviour
{
    Image screenProduction;
    private void Start()
    {
        screenProduction = GameObject.FindGameObjectWithTag("ScreenProduction").GetComponent<Image>();
        StartCoroutine(Hit());
    }
    IEnumerator Hit()
    {
        for (int i = 150; i >= 0; i--)
        {
            screenProduction.color = new Color(1f, 0, 0f, i / 255.0f);
            yield return new WaitForSeconds(0.005f);
        }
        Destroy(this);
    }
}
