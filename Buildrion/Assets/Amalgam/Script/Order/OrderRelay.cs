using UnityEngine;

public struct OrderInfo
{
    public string title;       //タイトル
    public int reward;         //報酬金
    public int lowRobotCount;    //最低台数
    public OrdersRarity rarity;  //レア度
    public string name;          //建物種類
}

public class OrderRelay : MonoBehaviour
{
    [SerializeField] private GameObject orderForm;
    [SerializeField] private Land myLand;
    [SerializeField] private RobotBase roboBase;

    [Header("依頼情報")]
    [SerializeField] private bool orderExistFlg;
    [SerializeField] private int orderID;

    private OrderInfo orderInfo;
    private CSVLoader csvLoader;

    // Start is called before the first frame update
    void Start()
    {
        orderForm = GameObject.FindGameObjectWithTag("OrderForm");
        myLand = gameObject.GetComponentInParent<Land>();
        roboBase = GameObject.FindGameObjectWithTag("RobotBase").GetComponent<RobotBase>();

        orderExistFlg = false;

        orderInfo = new OrderInfo();
        csvLoader = GetComponent<CSVLoader>();
    }

    //=========================================================================
    public void SetOrder(OrdersRarity rare, int id)
    {
        orderExistFlg = true;
        orderInfo.rarity = rare;
        orderID = id;

        //依頼情報読み込み
        Debug.Log(rare);

        orderInfo = csvLoader.LoadOrderFromCsv(rare, id);

        Debug.Log("依頼読み込み");

        //依頼Obj出現
        transform.GetChild(0).gameObject.SetActive(true);
    }

    //依頼アイコンをクリックしたときに発動
    public void ViewOrderForm()
    {
        Debug.Log("依頼表示");

        //依頼書に依頼情報を設定
        orderForm.GetComponent<OrderForm>().SetOrderForm(orderInfo, this);
        orderForm.GetComponent<Canvas>().enabled = true;
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
        myLand.SetOrderInfo(orderInfo.reward, robotNum, orderInfo.name);

        //ロボット拠点に指示を出す
        roboBase.OrderCatcher(myLand.transform.position, robotNum);

        transform.GetChild(0).gameObject.SetActive(false);
    }

    //オーダーキャンセル
    public void CanselOrder()
    {
        orderExistFlg = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    //=========================================================================
}