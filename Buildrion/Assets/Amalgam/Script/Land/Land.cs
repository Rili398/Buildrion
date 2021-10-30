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

    [Header("�e��p�����[�^")]
    [SerializeField] private List<RobotBase> robotList;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private float returnInterval = 1.0f;

    //�����̃��X�g
    private BuildingList buildingList;

    private void Awake()
    {
        //landStatus = LandStatus.NoBuild;
        isOrdered = false;
        isWarking = false;

        if(progressBar == null)
        {
            progressBar = gameObject.GetComponentInChildren<ProgressBar>();
        }

        progressBar.gameObject.SetActive(false);
        buildingList = new BuildingList();
    }

    // Update is called once per frame
    void Update()
    {
        //�X�e�[�g�Ǘ�
       if (landStatus == LandStatus.InConstruct)
        {
            if (!isWarking)
            {
                if (repuiredCount < robotList.Count)
                {
                    isWarking = true;
                    //���ݒ��I�u�W�F�N�g�\��
                    if (buildingName != null)
                    {
                        transform.GetChild(1).GetChild(
                            buildingList.BuildingName.IndexOf(buildingName)
                            ).gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                //�v���O���X�o�[�̐i�s
                progressBar.value += workPower;

                if(progressBar.value >= 1.0f)
                {
                    landStatus = LandStatus.IsBuilt;

                    //���݌�I�u�W�F�N�g�ɐ؂�ւ�
                    if (buildingName != null)
                    {
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
                transform.GetComponentInChildren<OrderRelay>().CanselOrder();
            }
        }
    }

    //=========================================================================

    private void OnCollisionEnter(Collision collision)
    {
        //�˗�������
        if (isOrdered)
        {
            if (collision.gameObject.CompareTag("Robot"))
            {
                //���{�b�g�����X�g�Ɋi�[
                RobotBase rbase = collision.gameObject.GetComponent<RobotBase>();
                robotList.Add(rbase);
                rbase.gameObject.SetActive(false);

                //��Ɨ͌v�Z
                //workPower += rbase.warkPower;
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

    public void SetOrderInfo(int rew, int roboNum, string name)
    {
        reward = rew;
        repuiredCount = roboNum;
        buildingName = name;
        progressBar.gameObject.SetActive(true);

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
            //robo.SetRobotState(RobotState.Return);
            robotList.Remove(robo);

            yield return new WaitForSeconds(returnInterval);
        }
    }
}
