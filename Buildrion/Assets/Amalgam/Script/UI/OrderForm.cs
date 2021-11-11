using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderForm : MonoBehaviour
{
    [SerializeField] private OrderRelay orderRelay;

    private OrderInfo orderInfo;

    [SerializeField] private Text titleText;
    [SerializeField] private Text rewardText;
    [SerializeField] private Text lowUnitCntText;
    [SerializeField] private Image[] rarityImages;

    public void SetOrderForm(OrderInfo info, OrderRelay orderR)
    {
        orderInfo = info;
        orderRelay = orderR;

        titleText.text = info.title;
        rewardText.text = info.reward.ToString();
        lowUnitCntText.text = info.lowRobotCount.ToString();

        //ƒŒƒA“x
        if (orderInfo.rarity == OrdersRarity.OR_Common)
        {
            int i = 0;
            foreach (Image img in rarityImages)
            {
                if (i < 1)
                {
                    img.enabled = true;
                }
                else
                {
                    img.enabled = false;
                }

                i++;
            }
        }
        else if (orderInfo.rarity == OrdersRarity.OR_Rare)
        {
            int i = 0;
            foreach (Image img in rarityImages)
            {
                if (i < 2)
                {
                    img.enabled = true;
                }
                else
                {
                    img.enabled = false;
                }

                i++;
            }
        }
        else if (orderInfo.rarity == OrdersRarity.OR_SuperRare)
        {
            foreach (Image img in rarityImages)
            {
                img.enabled = true;
            }
        }
    }

    //====================================================================

    public void AcceptButton()
    {
        Debug.Log("1");

        if(orderRelay != null)
        {
            Debug.Log("2");
            orderRelay.AcceptOrder(orderInfo.lowRobotCount);
        }
        GetComponent<Canvas>().enabled = false;
    }

    public void CanselButton()
    {
        if (orderRelay != null)
        {
            orderRelay.CanselOrder();
        }
        GetComponent<Canvas>().enabled = false;
    }

    public void CloseButton()
    {
        GetComponent<Canvas>().enabled = false;
    }
}
