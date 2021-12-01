using System.Collections;
using System.Collections.Generic;
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

    //ResultUIここ

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

    //得点計算
    public void ScoreCalculate()
    {
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
    }
}
