using UnityEngine;

public struct OrderInfo
{
    public string title;       //�^�C�g��
    public int reward;         //��V��
    public int lowRobotCount;    //�Œ�䐔
    public OrdersRarity rarity;  //���A�x
    public string name;          //�������
}

public class OrderRelay : MonoBehaviour
{
    [SerializeField] private GameObject orderForm;
    [SerializeField] private Land myLand;
    [SerializeField] private RobotBase roboBase;

    [Header("�˗����")]
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

        //�˗����ǂݍ���
        Debug.Log(rare);

        orderInfo = csvLoader.LoadOrderFromCsv(rare, id);

        Debug.Log("�˗��ǂݍ���");

        //�˗�Obj�o��
        transform.GetChild(0).gameObject.SetActive(true);
    }

    //�˗��A�C�R�����N���b�N�����Ƃ��ɔ���
    public void ViewOrderForm()
    {
        Debug.Log("�˗��\��");

        //�˗����Ɉ˗�����ݒ�
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

    //�I�[�_�[����
    public void AcceptOrder(int robotNum)
    {
        //�y�n�Ɉ˗�����n��
        myLand.SetLandStatus(LandStatus.InConstruct);
        myLand.SetOrderInfo(orderInfo.reward, robotNum, orderInfo.name);

        //���{�b�g���_�Ɏw�����o��
        roboBase.OrderCatcher(myLand.transform.position, robotNum);

        transform.GetChild(0).gameObject.SetActive(false);
    }

    //�I�[�_�[�L�����Z��
    public void CanselOrder()
    {
        orderExistFlg = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    //=========================================================================
}