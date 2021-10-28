using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�y�n�̏����Ǘ�����N���X

public class Land : MonoBehaviour
{
    public enum LandStatus
    {
        NoBuild = 0,
        InConstruct,
        IsBuilt,
        LandStatMax
    }

    [SerializeField, Tooltip("�y�n�̏��")] private LandStatus landStatus;

    public bool isOrdered { get; set; }
    [SerializeField, Tooltip("��ƒ��t���O")] private bool isWarking;
    [SerializeField] private int reward;
    [SerializeField] private int repuiredCount;
    public float workPower { get; set; } = 0;

    [SerializeField] private List<RobotBase> robotList;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private float returnInterval = 1.0f;

    private void Awake()
    {
        landStatus = LandStatus.NoBuild;
        isOrdered = false;
        isWarking = false;

        if(progressBar == null)
        {
            progressBar = gameObject.GetComponentInChildren<ProgressBar>();
        }

        progressBar.gameObject.SetActive(false);
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
                    progressBar.gameObject.SetActive(true);
                }
            }
            else
            {
                //�v���O���X�o�[�̐i�s
                progressBar.value += workPower;

                if(progressBar.value >= 1.0f)
                {
                    landStatus = LandStatus.IsBuilt;
                }
            }
        }
       else if(landStatus == LandStatus.IsBuilt)
        {
            if(isWarking)
            {
                StartCoroutine(ReternRobot());
                isWarking = false;
                isOrdered = false;
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

    public void SetOrderInfo(int rew, int roboNum)
    {
        reward = rew;
        repuiredCount = roboNum;
        isOrdered = true;
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
