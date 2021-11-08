using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���{�b�g�̑䐔�A�ő吔�A���{�b�g���Ƃ̍�Ɨ͂��Ǘ�����

public class RobotBase : MonoBehaviour
{
    [SerializeField] private string robotName;
    [SerializeField] private int defaultMax = 10;
    private int robotMax { get; set; }

    [Header("���݊�n�Ɏc���Ă��郍�{�b�g�̐�")]
    [SerializeField] private int nowRobotCnt;

    [Header("���{�b�g��@������̍�Ɨ�")]
    [SerializeField] private float baseWarkPower;

    [Header("�C���^�[�o��")]
    [SerializeField] private float intervalTime = 0.5f;

    [Header("���݂̃��{�b�g���X�g")]
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
            //���X�g����L�������ĖړI�n��`����B
            Robot robot = FindRobot();
            robot.gameObject.SetActive(true);
            robot.SetRState(RobotState.Moving);
            robot.warkPower = baseWarkPower;
            robot.SetDestination(dist);

            yield return new WaitForSeconds(intervalTime);
        }
    }

    //�w�肵�����������{�b�g���o���ă��X�g�i�[����
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

    //�g���Ă��Ȃ����{�b�g��T���ĕԂ�
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

    //�A���Ă������{�b�g�𖳌���
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
