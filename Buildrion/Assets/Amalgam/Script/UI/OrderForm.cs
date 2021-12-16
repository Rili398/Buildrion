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
    [SerializeField] private Button acceptButton;

    private RobotBase robotBase;

    private void Start()
    {
        robotBase = GameObject.FindGameObjectWithTag("RobotBase").GetComponent<RobotBase>();
    }

    private void Update()
    {
        if(robotBase.GetNowRobotCnt() >= orderInfo.lowRobotCount)
        {
            acceptButton.interactable = true;
        }
        else
        {
            acceptButton.interactable = false;
        }
    }

    public void SetOrderForm(OrderInfo info, OrderRelay orderR)
    {
        orderInfo = info;
        orderRelay = orderR;

        titleText.text = info.title;
        rewardText.text = "報酬金　" + info.reward.ToString();
        lowUnitCntText.text = "必要機体　" + info.lowRobotCount.ToString();

        //レア度
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
        if(orderRelay != null)
        {
            orderRelay.AcceptOrder(orderInfo.lowRobotCount);
        }
        Singleton<SoundManager>.Instance.PlaySeByName("click2");
        GetComponent<Canvas>().enabled = false;
    }

    public void CanselButton()
    {
        if (orderRelay != null)
        {
            orderRelay.CanselOrder();
        }
        Singleton<SoundManager>.Instance.PlaySeByName("click2");
        GetComponent<Canvas>().enabled = false;
    }

    public void CloseButton()
    {
        GetComponent<Canvas>().enabled = false;
    }
}
