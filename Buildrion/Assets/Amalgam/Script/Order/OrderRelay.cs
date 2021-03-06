using UnityEngine;

public struct OrderInfo
{
    public string title;        //^Cg
    public int reward;          //ñVà
    public int lowRobotCount;   //Åáä
    public OrdersRarity rarity; //Ax
    public string name;         //¨íÞ
    public float hp;            //ËHP
}

public class OrderRelay : MonoBehaviour
{
    [SerializeField] private GameObject orderForm;
    [SerializeField] private Land myLand;
    [SerializeField] private RobotBase roboBase;

    [Header("Ëîñ")]
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

        orderInfo = csvLoader.LoadOrderFromCsv(rare, id);

        //ËObjo»
        transform.GetChild(0).gameObject.SetActive(true);
    }

    //ËACRðNbNµ½Æ«É­®
    public void ViewOrderForm()
    {
        //ËÉËîñðÝè
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

    //public bool GetOrdePossibleRep()
    //{
    //    LandStatus ls = myLand.GetLandStatus();

    //    if(ls == LandStatus.IsBuilt)
    //    {
    //        return !orderExistFlg;
    //    }

    //    return false;
    //}

    //=========================================================================

    //I[_[è
    public void AcceptOrder(int robotNum)
    {
        //ynÉËîñðn·
        myLand.SetLandStatus(LandStatus.InConstruct);

        myLand.SetOrderInfo(orderInfo.reward, robotNum, orderInfo.name, orderInfo.hp);

        //{bg_Éw¦ðo·
        roboBase.OrderCatcher(myLand.transform.position, robotNum);

        transform.GetChild(0).gameObject.SetActive(false);
    }

    //I[_[LZ
    public void CanselOrder()
    {
        orderExistFlg = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    //=========================================================================
}