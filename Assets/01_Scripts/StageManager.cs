using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class StageData
{
    public int stageNumber;
    public string stageName;
    public string description;
    public GameObject[] obstacles;
    public GameObject[] enemys;
    public GameObject boss;
}
public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public int currentStage = 1;
    public List<StageData> datas;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Update()
    {
        switch (currentStage)
        {
            case 1:
                LoadStage1();
                break;
            case 2:
                LoadStage2();
                break;
            case 3:
                LoadStage3();
                break;
        }
    }
    public void LoadStage1()
    {

    }
    public void LoadStage2()
    {

    }
    public void LoadStage3()
    {

    }
}