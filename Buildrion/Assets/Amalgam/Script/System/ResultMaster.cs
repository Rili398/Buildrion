using UnityEngine;
using UnityEngine.UI;

//リザルト用得点計算

public class ResultMaster : Singleton<ResultMaster>
{
    [Header("累計稼いだお金")]
    [SerializeField] int totalMoney;

    [Header("建築可能全体数")]
    [SerializeField] int maxSlot;
    [SerializeField] int nowSlot;

    [Header("UI")]
    [SerializeField] private Canvas resultUILoot;
    [SerializeField] private Text moneyText;
    [SerializeField] private Text rateText;
    [SerializeField] private Text rankText;

    //== プロパティ ====================================
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

    //== 定数定義 ======================================
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

    //得点計算
    public void ScoreCalculate()
    {
        //類型獲得金額と土地の網羅率を別々に計算して総合スコアを出す
        int moneyScore, rateScore, totalScore;
        moneyScore = rateScore = totalScore = 0;

        //累計獲得金額のスコア計算
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

        //土地網羅率のスコア計算
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

        //総合スコアに応じてUI書き換えて表示
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
 * スコアアタック評価項目
 * 累計稼いだお金
 * 空地網羅率
 * CBAS
 * 4段階
 * お金（０〜５）＋空地（０〜５）＝総合（０〜１０）
 * ０〜２　C
 * ３〜５　B
 * ６〜８　A
 * ９〜　　S 
 * 空地
 * ０〜２０　１
 * ２１〜４０　２
 * ４１〜６０　３
 * ６１〜８０　４
 * ８１〜１００　５
 */
