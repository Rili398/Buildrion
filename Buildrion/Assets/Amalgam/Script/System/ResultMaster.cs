using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���U���g�p���_�v�Z

public class ResultMaster : Singleton<ResultMaster>
{
    [Header("�݌v�҂�������")]
    [SerializeField] int totalMoney;

    [Header("���z�\�S�̐�")]
    [SerializeField] int maxSlot;
    [SerializeField] int nowSlot;

    //ResultUI����

    // Start is called before the first frame update
    void Start()
    {
        totalMoney = 0;
        nowSlot = 0;
    }

    //=========================================================================

    public void AddTotalMoney(int add)
    {
        totalMoney += add;
    }

    public void AddNowSlot()
    {
        nowSlot++;
    }

    //=========================================================================

    //���_�v�Z
    public void ScoreCalculate()
    {
        /*
         * �X�R�A�A�^�b�N�]������
         * �݌v�҂�������
         * ��n�ԗ���
         * CBAS
         * 4�i�K
         * �����i�O�`�T�j�{��n�i�O�`�T�j�������i�O�`�P�O�j
         * �O�`�Q�@C
         * �R�`�T�@B
         * �U�`�W�@A
         * �X�`�@�@S 
         * ��n
         * �O�`�Q�O�@�P
         * �Q�P�`�S�O�@�Q
         * �S�P�`�U�O�@�R
         * �U�P�`�W�O�@�S
         * �W�P�`�P�O�O�@�T
         */
    }
}
