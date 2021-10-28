using UnityEngine;

//依頼の発生を管理する。タイマーで依頼発生させ、各土地の依頼オブジェクトに指示を出す

//依頼のレア度を管理する
public enum OrdersRarity
{
    OR_Common = 0,
    OR_Rare,
    OR_SuperRare,
    OR_Max
}

public class OrderMaster : Singleton<OrderMaster>
{
    private GameTimer orderTimer; //依頼発生までのタイマー
    [Header("依頼発生タイマー設定")]
    [SerializeField, Tooltip("最短(秒)")] private float timerMin = 10.0f;
    [SerializeField, Tooltip("最長(秒)")] private float timerMax = 30.0f;

    [Header("レア度ごとの出現率")]
    [SerializeField,
     NamedArrayAtr(new string[(int)OrdersRarity.OR_Max] { "Common", "Rare", "SuperRare" })]
    private float[] popRate = new float[(int)OrdersRarity.OR_Max] { 0.5f, 0.3f, 0.2f };

    [Header("ターゲット依頼オブジェクト")]
    [SerializeField] private OrderRelay target;    //依頼OBJクラス型

    [Header("依頼IDの最大値")]
    [SerializeField] private int commonIdMax = 1;
    [SerializeField] private int rareIdMax = 1;
    [SerializeField] private int superRareIdMax = 1;

    // Start is called before the first frame update
    void Start()
    {
        //依頼発生時間の設定
        orderTimer = new GameTimer(Mathf.Floor(Random.Range(timerMin, timerMax)));
    }

    // Update is called once per frame
    void Update()
    {
        //タイマー更新
        orderTimer.UpdateTimer();

        if(orderTimer.IsTimeUp)
        {
            float priority = Random.value;  //0~1

            //依頼発生チェック
            bool result = OrderCheck(priority);
            Debug.Log("優先度:" + priority);
            Debug.Log("依頼発生:" + result);

            //依頼の抽選
            if(result)
            {
                LotteryOrder();
            }

            orderTimer.ResetTimer(Mathf.Floor(Random.Range(timerMin, timerMax)));
        }
    }

    //=========================================================================

    //依頼発生チェック
    bool OrderCheck(float rate)
    {
        bool result = false;

        //建設と改修の優先度を決める
        if(rate > 0.5f)
        {
            result = CheckConstructionOrder();
            result = CheckRepairOrder();
        }
        else
        {
            result = CheckRepairOrder();
            result = CheckConstructionOrder();
        }

        //依頼が発生したか、結果報告
        return result;
    }
    
    //建築依頼の発生条件チェック
    bool CheckConstructionOrder()
    {
        //シーン内の土地を取得して、条件チェック
        //

        return true;
    }

    //改修依頼の発生条件チェック
    bool CheckRepairOrder()
    {
        //シーン内の土地を取得して、条件チェック
        //

        return true;
    }

    //依頼の抽選
    void LotteryOrder()
    {
        //レア度決定
        OrdersRarity rare = OrdersRarity.OR_Max;

        //今回の値を抽選
        float rate = Random.value;

        //レア度を確定させる
        foreach(var value in popRate)
        {
            if(rate < value)
            {
                break;
            }
            else
            {
                rate -= value;
                rare++;
            }
        }

        //依頼ID決定
        int id = 0;

        if(rare == OrdersRarity.OR_Common)
        {
            id = Mathf.FloorToInt(Random.Range(0, commonIdMax));
        }
        else if (rare == OrdersRarity.OR_Rare)
        {
            id = Mathf.FloorToInt(Random.Range(0, rareIdMax));
        }
        else if (rare == OrdersRarity.OR_SuperRare)
        {
            id = Mathf.FloorToInt(Random.Range(0, superRareIdMax));
        }
        else
        {
            Debug.Log("依頼決定でバグってます(OrderMaster)");
        }

        //依頼OBJに登録
        target.SetOrder(rare, id);
    }
}
