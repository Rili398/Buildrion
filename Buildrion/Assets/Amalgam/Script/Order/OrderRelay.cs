using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Header("�˗����")]
    [SerializeField] private bool isOrderExist;
    [SerializeField] private int orderID;
    [SerializeField] private OrderInfo orderInfo;

    // Start is called before the first frame update
    void Awake()
    {
        orderForm = GameObject.FindGameObjectWithTag("OrderForm");
        myLand = gameObject.GetComponentInParent<Land>();
        isOrderExist = false;
        orderInfo = new OrderInfo();
    }

    //=========================================================================
    public void SetOrder(OrdersRarity rare, int id)
    {
        isOrderExist = true;
        orderInfo.rarity = rare;
        orderID = id;

        //�˗����ǂݍ���
        LoadOrderFromCsv();

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
        //�{�^���Ɋ֐���ݒ�
    }

    public void SetOrderForm(OrderInfo info)
    {
        //�˗���UI�Ɉڐݗ\��
        //�e�����ݒ肷��
    }

    //=========================================================================

    //�I�[�_�[����
    public void AcceptOrder()
    {
        myLand.SetLandStatus(Land.LandStatus.InConstruct);
        myLand.SetOrderInfo(orderInfo.reward, orderInfo.lowRobotCount);
    }

    //�I�[�_�[�L�����Z��
    public void CanselOrder()
    {
        isOrderExist = false;
    }

    //=========================================================================

    private void LoadOrderFromCsv()
    {
        //���A�x�œǂݍ���CSV��I��
        //ID�̍s��ǂݍ���
    }
}
