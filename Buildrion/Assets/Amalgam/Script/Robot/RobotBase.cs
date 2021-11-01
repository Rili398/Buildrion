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

    [Header("インターバル")]
    [SerializeField] private float intervalTime = 0.5f;

    //=========================================================================

    public void OrderCatcher(Vector3 dist, int num)
    {
        StartCoroutine(DispatchRobot(dist, num));
    }

    private IEnumerator DispatchRobot(Vector3 dist, int num)
    {
        for(int i = 0; i < num; i++)
        {
            //リストから有効化して目的地を伝える。

            yield return new WaitForSeconds(intervalTime);
        }
    }

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
