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
    public ParticleSystem particle;

    //�����̃��X�g
    private BuildingList buildingList;
    private Marge marge;

    //��ƒ����{�b�g
    [SerializeField] private Animator[] roboAnimator;
    [SerializeField] private Animator margedRoboAnimator;

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
        //�Q�[���i�s��Ԋm�F
        if(Singleton<GameManager>.Instance.isGameEnd)
        {
            return; 
        }

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

                        SetViewRobot(false);
                    }
                }
            }
            else
            {
                //�v���O���X�o�[�̐i�s�@�������~��
                if (!marge.timeStop)
                {
                    progressBar.AddValue(workPower * margeRate);
                }

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

                //���{�b�g����Ԃ�
                StartCoroutine(ReternRobot());

                //�p�����[�^�����Z�b�g
                isWarking = false;
                isOrdered = false;
                workPower = 0;
                progressBar.ResetProgress();
                progressBar.gameObject.SetActive(false);
                transform.GetComponentInChildren<OrderRelay>().CanselOrder();
                marge.isWarking = false;
                InvisibleRobot();

                //�����p�[�e�B�N������
                particle.Play();

                //�������Z
                Singleton<GameManager>.Instance.AddMoney(reward);

                //�X�R�A���Z
                Singleton<ResultMaster>.Instance.AddNowSlot();
                Singleton<ResultMaster>.Instance.AddTotalMoney(reward);

                reward = 0;
            }
        }

        robotCnt = robotList.Count;
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

    //�y�n�̏�Ԑݒ�
    public void SetLandStatus(LandStatus ls)
    {
        landStatus = ls;
    }

    //�y�n�̏�Ԏ擾
    public LandStatus GetLandStatus()
    {
        return landStatus;
    }

    //�˗����󂯎��
    public void SetOrderInfo(int rew, int roboNum, string name, float hp)
    {
        reward = rew;
        repuiredCount = roboNum;
        buildingName = name;
        progressBar.gameObject.SetActive(true);
        progressBar.SetMaxValue(hp); 

        isOrdered = true;
    }

    //���z�����{�b�g�\���ݒ�
    public void SetViewRobot(bool isMarge)
    {
        //���́^�񍇑�
        if (isMarge)
        {
            //���̃��{����
            foreach(var anim in roboAnimator)
            {
                anim.gameObject.SetActive(false);
            }

            if (margedRoboAnimator != null)
            {
                margedRoboAnimator.gameObject.SetActive(true);
            }

            margedRoboAnimator.SetBool("build", true);
        }
        else
        {
            //�񍇑̃��{����
            foreach (var anim in roboAnimator)
            {
                anim.gameObject.SetActive(true);
                anim.SetBool("build", true);
            }

            if (margedRoboAnimator != null)
            {
                margedRoboAnimator.gameObject.SetActive(false);
            }
        }
    }

    //���z�����{�b�g��\��
    public void InvisibleRobot()
    {
        foreach (var anim in roboAnimator)
        {
            anim.gameObject.SetActive(false);
        }

        if (margedRoboAnimator != null)
        {
            margedRoboAnimator.gameObject.SetActive(false);
        }
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
