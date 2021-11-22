using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�y�n�̏����Ǘ�����N���X

public enum LandStatus
{
    NoBuild = 0,
    InConstruct,
    IsBuilt,
    LandStatMax
}

public class Land : MonoBehaviour
{
    [SerializeField, Tooltip("�y�n�̏��")] private LandStatus landStatus;

    public bool isOrdered { get; set; }
    [SerializeField, Tooltip("��ƒ��t���O")] private bool isWarking;

    [Header("�˗����")]
    [SerializeField] private int reward;
    [SerializeField] private int repuiredCount;
    [SerializeField] private string buildingName;
    public float workPower { get; set; } = 0;
    [SerializeField] private float wp;

    [Header("�e��p�����[�^")]
    [SerializeField] private List<Robot> robotList;
    [SerializeField] private ProgressBar02 progressBar;
    [SerializeField] private float returnInterval = 1.0f;
    public float margeRate;
    public int robotCnt;

    //�����̃��X�g
    private BuildingList buildingList;
    private Marge marge;

    public bool iot;
    public bool iw;

    private void Awake()
    {
        //landStatus = LandStatus.NoBuild;
        isOrdered = false;
        isWarking = false;

        if(progressBar == null)
        {
            progressBar = gameObject.GetComponentInChildren<ProgressBar02>();
        }

        progressBar.gameObject.SetActive(false);
        buildingList = new BuildingList();

        marge = GetComponent<Marge>();
        margeRate = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //�X�e�[�g�Ǘ�
       if (landStatus == LandStatus.InConstruct)
        {
            if (!isWarking)
            {
                if (repuiredCount <= robotList.Count)
                {
                    isWarking = true;
                    marge.isWarking = true;
                    //���ݒ��I�u�W�F�N�g�\��
                    if (buildingName != null)
                    {
                        transform.GetChild(1).GetChild(
                            buildingList.BuildingName.IndexOf(buildingName)
                            ).gameObject.SetActive(true);

                        transform.GetChild(2).GetChild(
                            buildingList.BuildingName.IndexOf(buildingName)
                            ).gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                //�v���O���X�o�[�̐i�s
                progressBar.AddValue(workPower * margeRate);

                if(progressBar.GetIsMax())
                {
                    landStatus = LandStatus.IsBuilt;

                    //���݌�I�u�W�F�N�g�ɐ؂�ւ�
                    if (buildingName != null)
                    {
                        transform.GetChild(1).GetChild(
                            buildingList.BuildingName.IndexOf(buildingName)
                            ).gameObject.SetActive(false);

                        transform.GetChild(2).GetChild(
                            buildingList.BuildingName.IndexOf(buildingName)
                            ).gameObject.SetActive(true);
                    }
                }
            }
        }
       else if(landStatus == LandStatus.IsBuilt)
        {
            if(isWarking)
            {
                //�˗��I��
                StartCoroutine(ReternRobot());
                isWarking = false;
                isOrdered = false;
                workPower = 0;
                progressBar.ResetProgress();
                progressBar.gameObject.SetActive(false);
                transform.GetComponentInChildren<OrderRelay>().CanselOrder();
                marge.isWarking = false;

                //�������Z
                Singleton<GameManager>.Instance.AddMoney(reward);
                reward = 0;
            }
        }

       //���{�b�g�̕\��
       if(isWarking)
        {
            //���́^�񍇑�
            if(marge.isMarge)
            {
                //���̃��{����
            }
            else
            {
                //�񍇑̃��{����
            }
        }

        robotCnt = robotList.Count;

        iot = isOrdered;
        iw = isWarking;

        Debug.Log(iot);
        Debug.Log(iw);
    }

    //=========================================================================

    private void OnTriggerEnter(Collider other)
    {
        //�˗�������
        if (isOrdered)
        {
            if (other.gameObject.CompareTag("Robot"))
            {
                //���{�b�g�����X�g�Ɋi�[
                Robot robot = other.gameObject.GetComponent<Robot>();
                Vector3 tmp = robot.GetDestination();
                tmp.y = 0.0f;

                //�ړI�n����������Ȃ���Ίi�[���Ȃ�
                if (tmp == transform.position)
                {
                    robotList.Add(robot);
                    robot.SetRState(RobotState.Working);
                    robot.gameObject.SetActive(false);

                    //��Ɨ͌v�Z
                    workPower += robot.warkPower;
                }
            }
        }
    }

    //=========================================================================

    public void SetLandStatus(LandStatus ls)
    {
        landStatus = ls;
    }

    public LandStatus GetLandStatus()
    {
        return landStatus;
    }

    public void SetOrderInfo(int rew, int roboNum, string name, float hp)
    {
        reward = rew;
        repuiredCount = roboNum;
        buildingName = name;
        progressBar.gameObject.SetActive(true);
        progressBar.SetMaxValue(hp); 

        isOrdered = true;

        Debug.Log("reward:" + reward);
        Debug.Log("reCon:" + repuiredCount);
    }

    //=========================================================================

    IEnumerator ReternRobot()
    {
        //���X�g�̏ォ�烍�{�b�g��L����
        foreach(var robo in robotList)
        {
            robo.gameObject.SetActive(true);

            //�A�҃��[�h�ɕύX
            robo.SetRState(RobotState.Return);

            yield return new WaitForSeconds(returnInterval);
        }

        robotList.Clear();
    }
}
