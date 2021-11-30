using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ƒŠƒUƒ‹ƒg—p“¾“_ŒvZ

public class ResultMaster : Singleton<ResultMaster>
{
    [Header("—İŒv‰Ò‚¢‚¾‚¨‹à")]
    [SerializeField] int totalMoney;

    [Header("Œš’z‰Â”\‘S‘Ì”")]
    [SerializeField] int maxSlot;
    [SerializeField] int nowSlot;

    //ResultUI‚±‚±

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

    //“¾“_ŒvZ
    public void ScoreCalculate()
    {
        /*
         * ƒXƒRƒAƒAƒ^ƒbƒN•]‰¿€–Ú
         * —İŒv‰Ò‚¢‚¾‚¨‹à
         * ‹ó’n–Ô—…—¦
         * CBAS
         * 4’iŠK
         * ‚¨‹ài‚O`‚Tj{‹ó’ni‚O`‚Tj‘‡i‚O`‚P‚Oj
         * ‚O`‚Q@C
         * ‚R`‚T@B
         * ‚U`‚W@A
         * ‚X`@@S 
         * ‹ó’n
         * ‚O`‚Q‚O@‚P
         * ‚Q‚P`‚S‚O@‚Q
         * ‚S‚P`‚U‚O@‚R
         * ‚U‚P`‚W‚O@‚S
         * ‚W‚P`‚P‚O‚O@‚T
         */
    }
}
