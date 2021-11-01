using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ロボットの台数、最大数、ロボットごとの作業力を管理する

public class RobotBase : MonoBehaviour
{
    private int robotMax { get; set; }

    [Header("現在基地に残っているロボットの数")]
    [SerializeField] private int nowRobotCnt;

    [Header("ロボット一機当たりの作業力")]
    [SerializeField] private float baseWarkPower;

    //=========================================================================

    public int GetNowRobotCnt()
    {
        return nowRobotCnt;
    }

    public void SetBaseWarkPower(float wPower)
    {
        baseWarkPower = wPower;
    }
}
