using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float second = 0f;
    public TextMeshProUGUI timer;

    private void Update()
    {
        second += Time.deltaTime;
        timer.text = Convert.ToInt32(second/60).ToString("D2") + ":" + Convert.ToInt32(second%60).ToString("D2");
    }
}