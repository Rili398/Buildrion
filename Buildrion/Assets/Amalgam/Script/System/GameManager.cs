using UnityEngine;
using UnityEngine.UI;

//オプションとかの管理をする予定

public class GameManager : Singleton<GameManager>
{
    [Header("所持金")]
    [SerializeField] private int money;
    [SerializeField] private Text moneyText;

    [Header("ロボット数")]
    [SerializeField] private RobotBase roboBase;
    [SerializeField] private Text roboText;



    void Start()
    {
        //フレームレート設定
        Application.targetFrameRate = 60;

        roboBase = GameObject.FindGameObjectWithTag("RobotBase").GetComponent<RobotBase>();
    }

    private void Update()
    {
        if (moneyText != null)
        {
            moneyText.text = "MONEY :" + money.ToString("D8");
        }

        if(roboText != null)
        {
            roboText.text = "ロボ数／最大数 = " + roboBase.GetNowRobotCnt() + "／" + roboBase.robotMax;
        }
    }

    public void AddMoney(int value)
    {
        money += value;
    }

    public int GetMoney()
    {
        return money;
    }
}
