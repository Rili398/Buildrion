using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Header("依頼情報")]
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

        //依頼情報読み込み
        LoadOrderFromCsv();

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
        //ボタンに関数を設定
    }

    public void SetOrderForm(OrderInfo info)
    {
        //依頼書UIに移設予定
        //各種情報を設定する
    }

    //=========================================================================

    //オーダー決定
    public void AcceptOrder()
    {
        myLand.SetLandStatus(Land.LandStatus.InConstruct);
        myLand.SetOrderInfo(orderInfo.reward, orderInfo.lowRobotCount);
    }

    //オーダーキャンセル
    public void CanselOrder()
    {
        isOrderExist = false;
    }

    //=========================================================================

    private void LoadOrderFromCsv()
    {
        //レア度で読み込むCSVを選ぶ
        //IDの行を読み込む
    }
}
