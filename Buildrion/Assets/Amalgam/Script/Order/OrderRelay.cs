using UnityEngine;
using UnityEngine.UI;

public class OrderRelay : MonoBehaviour
{
    public struct OrderInfo
    {
        public string title;   　　 　//タイトル
        public int reward;     　　　 //報酬金
        public int lowRobotCount;    //最低台数
        public OrdersRarity rarity;  //レア度
        public string name;          //建物種類
    }

    [SerializeField] private GameObject orderForm;
    [SerializeField] private Land myLand;
    [SerializeField] private RobotBase roboBase;

    [Header("依頼情報")]
    [SerializeField] private bool orderExistFlg;
    [SerializeField] private int orderID;

    private OrderInfo orderInfo;

    // Start is called before the first frame update
    void Start()
    {
        orderForm = GameObject.FindGameObjectWithTag("OrderForm");
        myLand = gameObject.GetComponentInParent<Land>();
        roboBase = GameObject.FindGameObjectWithTag("RobotBase").GetComponent<RobotBase>();

        orderExistFlg = false;

        orderInfo = new OrderInfo();
    }

    //=========================================================================
    public void SetOrder(OrdersRarity rare, int id)
    {
        orderExistFlg = true;
        orderInfo.rarity = rare;
        orderID = id;

        //依頼情報読み込み
        LoadOrderFromCsv();

        Debug.Log("依頼読み込み");

        //依頼Obj出現
        transform.GetChild(0).gameObject.SetActive(true);
    }

    //依頼アイコンをクリックしたときに発動
    public void ViewOrderForm()
    {
        Debug.Log("依頼表示");

        //依頼書に依頼情報を設定
        //orderForm.
        SetOrderForm(orderInfo);
        orderForm.GetComponent<Canvas>().enabled = true;
        //ボタンに関数を設定
    }

    public void SetOrderForm(OrderInfo info)
    {
        //依頼書UIに移設予定
        //各種情報を設定する
    }

    public bool GetOrdePossibleCon()
    {
        LandStatus ls = myLand.GetLandStatus();

        if(ls == LandStatus.NoBuild)
        {
            return !orderExistFlg;
        }

        return false;
    }

    public bool GetOrdePossibleRep()
    {
        LandStatus ls = myLand.GetLandStatus();

        if(ls == LandStatus.IsBuilt)
        {
            return !orderExistFlg;
        }

        return false;
    }

    //=========================================================================

    //オーダー決定
    public void AcceptOrder(int robotNum)
    {
        //土地に依頼情報を渡す
        myLand.SetLandStatus(LandStatus.InConstruct);
        myLand.SetOrderInfo(orderInfo.reward, orderInfo.lowRobotCount, orderInfo.name);

        //ロボット拠点に指示を出す
        roboBase.OrderCatcher(myLand.transform.position, orderInfo.lowRobotCount);

        transform.GetChild(0).gameObject.SetActive(false);
    }

    //オーダーキャンセル
    public void CanselOrder()
    {
        orderExistFlg = false;
    }

    //=========================================================================

    private void LoadOrderFromCsv()
    {
        //レア度で読み込むCSVを選ぶ
        //IDの行を読み込む

        //デバッグ用テストケース
        orderInfo = new OrderInfo
        {
            title = "テストケース",
            reward = 1000,
            lowRobotCount = 3,
            rarity = orderInfo.rarity,
            name = "HAL月面"
        };
    }
}