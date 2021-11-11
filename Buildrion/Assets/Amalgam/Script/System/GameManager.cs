using UnityEngine;
using UnityEngine.UI;

//オプションとかの管理をする予定

public class GameManager : Singleton<GameManager>
{
    [Header("所持金")]
    [SerializeField] private int money;
    [SerializeField] private Text moneyText;

    void Start()
    {
        //フレームレート設定
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        moneyText.text = "MONEY :" + money.ToString("D8");
    }

    public void AddMoney(int value)
    {
        money += value;
    }
}
