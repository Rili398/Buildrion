using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ロボットの台数、最大数、ロボットごとの作業力を管理する

public class RobotBase : MonoBehaviour
{
    [SerializeField] private string robotName;
    [SerializeField] private int defaultMax = 10;
    private int robotMax { get; set; }

    [Header("現在基地に残っているロボットの数")]
    [SerializeField] private int nowRobotCnt;

    [Header("ロボット一機当たりの作業力")]
    [SerializeField] private float baseWarkPower;

    [Header("インターバル")]
    [SerializeField] private float intervalTime = 0.5f;

    [Header("現在のロボットリスト")]
    [SerializeField] private List<Robot> roboList;

    //=========================================================================

    private void Start()
    {
        robotMax = defaultMax;
        nowRobotCnt = robotMax;

        AddRobotList(robotMax);
    }

    public void OrderCatcher(Vector3 dist, int num)
    {
        StartCoroutine(DispatchRobot(dist, num));
        nowRobotCnt = nowRobotCnt - num;
    }

    private IEnumerator DispatchRobot(Vector3 dist, int num)
    {
        for(int i = 0; i < num; i++)
        {
            //リストから有効化して目的地を伝える。
            Robot robot = FindRobot();
            robot.gameObject.SetActive(true);
            robot.SetRState(RobotState.Moving);
            robot.warkPower = baseWarkPower;
            robot.SetDestination(dist);

            yield return new WaitForSeconds(intervalTime);
        }
    }

    //指定した数だけロボットを出してリスト格納する
    private void AddRobotList(int num)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject obj = (GameObject)Resources.Load(robotName);
            Robot robot = Instantiate(obj, transform.position, Quaternion.identity).GetComponent<Robot>();
            roboList.Add(robot);
            robot.SetRState(RobotState.Rest);
            robot.gameObject.SetActive(false);
        }
    }

    //使っていないロボットを探して返す
    private Robot FindRobot()
    {
        foreach(Robot obj in roboList)
        {
            if(obj.GetRState() == RobotState.Rest)
            {
                obj.transform.position = transform.position;
                return obj;
            }
        }

        return new Robot();
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

    //=========================================================================

    //帰ってきたロボットを無効化
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Robot"))
        {
            Robot robot = other.GetComponent<Robot>();
            if (robot.GetRState() == RobotState.Return)
            {
                robot.SetRState(RobotState.Rest);
                robot.gameObject.SetActive(false);
                nowRobotCnt++;
            }
        }
    }
}
