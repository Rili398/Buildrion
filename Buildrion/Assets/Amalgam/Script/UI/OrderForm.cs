using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderForm : MonoBehaviour
{
    [SerializeField] private OrderRelay orderRelay;

    private OrderInfo orderInfo;

    private Text titleText;
    private Text rewardText;
    private Text lowUnitCntText;
    private Image[] rarityImages;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetOrderForm(OrderInfo info, OrderRelay orderR)
    {
        orderInfo = info;
        orderRelay = orderR;
    }

    //====================================================================

    public void AcceptButton()
    {
        if(orderRelay != null)
        {
            orderRelay.AcceptOrder(orderInfo.lowRobotCount);
        }
    }

    public void CanselButton()
    {
        if (orderRelay != null)
        {

        }
    }
}
