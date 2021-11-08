using UnityEngine;
using UnityEngine.UI;

public class OrderRelay : MonoBehaviour
{
    public struct OrderInfo
    {
        public string title;   �@�@ �@//�^�C�g��
        public int reward;     �@�@�@ //��V��
        public int lowRobotCount;    //�Œ�䐔
        public OrdersRarity rarity;  //���A�x
        public string name;          //�������
    }

    [SerializeField] private GameObject orderForm;
    [SerializeField] private Land myLand;
    [SerializeField] private RobotBase roboBase;

    [Header("�˗����")]
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

        //�˗����ǂݍ���
        LoadOrderFromCsv();

        Debug.Log("�˗��ǂݍ���");

        //�˗�Obj�o��
        transform.GetChild(0).gameObject.SetActive(true);
    }

    //�˗��A�C�R�����N���b�N�����Ƃ��ɔ���
    public void ViewOrderForm()
    {
        Debug.Log("�˗��\��");

        //�˗����Ɉ˗�����ݒ�
        //orderForm.
        SetOrderForm(orderInfo);
        orderForm.GetComponent<Canvas>().enabled = true;
        //�{�^���Ɋ֐���ݒ�
    }

    public void SetOrderForm(OrderInfo info)
    {
        //�˗���UI�Ɉڐݗ\��
        //�e�����ݒ肷��
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
        myLand.SetOrderInfo(orderInfo.reward, orderInfo.lowRobotCount, orderInfo.name);

        //���{�b�g���_�Ɏw�����o��
        roboBase.OrderCatcher(myLand.transform.position, orderInfo.lowRobotCount);

        transform.GetChild(0).gameObject.SetActive(false);
    }

    //�I�[�_�[�L�����Z��
    public void CanselOrder()
    {
        orderExistFlg = false;
    }

    //=========================================================================

    private void LoadOrderFromCsv()
    {
        //���A�x�œǂݍ���CSV��I��
        //ID�̍s��ǂݍ���

        //�f�o�b�O�p�e�X�g�P�[�X
        orderInfo = new OrderInfo
        {
            title = "�e�X�g�P�[�X",
            reward = 1000,
            lowRobotCount = 3,
            rarity = orderInfo.rarity,
            name = "HAL����"
        };
    }
}