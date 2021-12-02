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

    [Header("UI")]
    [SerializeField] private Canvas resultUILoot;
    [SerializeField] private Text moneyText;
    [SerializeField] private Text rateText;
    [SerializeField] private Text rankText;

    //== �v���p�e�B ====================================
    public bool ResultUIEnable
    {
        get
        {
            return resultUILoot.enabled;
        }

        set
        {
            resultUILoot.enabled = value;
        }
    }
    //=================================================

    //== �萔��` ======================================
    const int Money_Low     = 5000;
    const int Money_Middle  = 10000;
    const int Money_High    = 20000;
    const int Money_Highest = 35000;

    const float SlotRate_Low     = 0.2f;
    const float SlotRate_Middle  = 0.4f;
    const float SlotRate_High    = 0.6f;
    const float SlotRate_Highest = 0.8f;

    const int TotalScore_Low     = 3;
    const int TotalScore_Middle  = 6;
    const int TotalScore_High    = 9;
    //==============================================

    void Start()
    {
        totalMoney = 0;
        nowSlot = 0;

        ResultUIEnable = false;
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
        //�ތ^�l�����z�Ɠy�n�̖ԗ�����ʁX�Ɍv�Z���đ����X�R�A���o��
        int moneyScore, rateScore, totalScore;
        moneyScore = rateScore = totalScore = 0;

        //�݌v�l�����z�̃X�R�A�v�Z
        if(totalMoney < Money_Low)
        {
            moneyScore = 1;
        }
        else if(totalMoney >= Money_Low && totalMoney < Money_Middle)
        {
            moneyScore = 2;
        }
        else if(totalMoney >= Money_Middle && totalMoney < Money_High)
        {
            moneyScore = 3;
        }
        else if(totalMoney >= Money_High && totalMoney < Money_Highest)
        {
            moneyScore = 4;
        }
        else if (totalMoney >= Money_Highest)
        {
            moneyScore = 5;
        }

        //�y�n�ԗ����̃X�R�A�v�Z
        float slotRate = nowSlot / (float)maxSlot;

        if (slotRate < SlotRate_Low)
        {
            rateScore = 1;
        }
        else if (slotRate >= SlotRate_Low && slotRate < SlotRate_Middle)
        {
            rateScore = 2;
        }
        else if (slotRate >= SlotRate_Middle && slotRate < SlotRate_High)
        {
            rateScore = 3;
        }
        else if (slotRate >= SlotRate_High && slotRate < SlotRate_Highest)
        {
            rateScore = 4;
        }
        else if (slotRate >= SlotRate_Highest)
        {
            rateScore = 5;
        }

        //�����X�R�A�ɉ�����UI���������ĕ\��
        moneyText.text = totalMoney.ToString();
        rateText.text = Mathf.FloorToInt(slotRate * 100).ToString();

        totalScore = moneyScore + rateScore;

        if(totalScore < TotalScore_Low)
        {
            rankText.text = "C";
        }
        else if (totalScore >= TotalScore_Low && totalScore < TotalScore_Middle)
        {
            rankText.text = "B";
        }
        else if (totalScore >= TotalScore_Middle && totalScore < TotalScore_High)
        {
            rankText.text = "A";
        }
        else if (totalScore >= TotalScore_High)
        {
            rankText.text = "S";
        }

        ResultUIEnable = true;
    }
}

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
