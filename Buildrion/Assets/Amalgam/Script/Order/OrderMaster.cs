using System.Collections.Generic;
using UnityEngine;

//�˗��̔������Ǘ�����B�^�C�}�[�ň˗����������A�e�y�n�̈˗��I�u�W�F�N�g�Ɏw�����o��

//�˗��̃��A�x���Ǘ�����
public enum OrdersRarity
{
    OR_Common = 0,
    OR_Rare,
    OR_SuperRare,
    OR_Max
}

public class OrderMaster : MonoBehaviour
{
    private GameTimer orderTimer; //�˗������܂ł̃^�C�}�[
    [Header("�˗������^�C�}�[�ݒ�")]
    [SerializeField, Tooltip("�ŒZ(�b)")] private float timerMin = 10.0f;
    [SerializeField, Tooltip("�Œ�(�b)")] private float timerMax = 30.0f;

    [Header("���A�x���Ƃ̏o����")]
    [SerializeField,
     NamedArrayAtr(new string[(int)OrdersRarity.OR_Max] { "Common", "Rare", "SuperRare" })]
    private float[] popRate = new float[(int)OrdersRarity.OR_Max] { 0.5f, 0.3f, 0.2f };

    [Header("�^�[�Q�b�g�˗��I�u�W�F�N�g")]
    [SerializeField] private OrderRelay target;    //�˗�OBJ�N���X�^

    [Header("�˗�ID�̍ő�l")]
    [SerializeField] private int commonId;
    [SerializeField] private int rareId;
    [SerializeField] private int superRareId;

    [Header("�˗�OBJ�̃^�O��")]
    [SerializeField] private string rerayTag;

    // Start is called before the first frame update
    void Start()
    {
        //�˗��������Ԃ̐ݒ�
        orderTimer = new GameTimer(Mathf.Floor(Random.Range(timerMin, timerMax)));
        target = null;
    }

// Update is called once per frame
void Update()
    {
        //�^�C�}�[�X�V
        orderTimer.UpdateTimer();

        if(orderTimer.IsTimeUp)
        {
            float priority = Random.value;  //0~1

            //�˗������`�F�b�N
            bool result = OrderCheck(priority);
            //Debug.Log("�˗�����:" + result);
            //Debug.Log("�D��x:" + priority);

            //�˗��̒��I
            if (result)
            {
                LotteryOrder();
            }

            orderTimer.ResetTimer(Mathf.Floor(Random.Range(timerMin, timerMax)));
        }
    }

    //=========================================================================

    //�˗������`�F�b�N
    bool OrderCheck(float rate)
    {
        bool result = false;

        //���݂Ɖ��C�̗D��x�����߂�
        if(rate > 0.5f)
        {
            result = CheckConstructionOrder();

            if (!result)
            {
                //result = CheckRepairOrder();
            }
        }
        else
        {
            //result = CheckRepairOrder();

            if (!result)
            {
                result = CheckConstructionOrder();
            }
        }

        //�˗��������������A���ʕ�
        return result;
    }
    
    //���z�˗��̔��������`�F�b�N
    bool CheckConstructionOrder()
    {
        List<GameObject> select = new List<GameObject>();

        //�V�[�����̈˗�OBJ���擾���āA�����`�F�b�N
        foreach (var orderObj in GameObject.FindGameObjectsWithTag(rerayTag))
        {
            //�˗����������Ă��Ȃ� && ���ݍς�
            if (orderObj.GetComponent<OrderRelay>().GetOrdePossibleCon())
            {
                select.Add(orderObj);
            }
        }

        if (select.Count > 0)
        {
            target = select[Random.Range(0, select.Count)].GetComponent<OrderRelay>();
            return true;
        }

        return false;
    }

    //���C�˗��̔��������`�F�b�N
    //bool CheckRepairOrder()
    //{
    //    List<GameObject> select = new List<GameObject>();

    //    //�V�[�����̈˗�OBJ���擾���āA�����`�F�b�N
    //    foreach (var orderObj in GameObject.FindGameObjectsWithTag("OrderObj"))
    //    {
    //        //�˗����������Ă��Ȃ� && ���ݍς�
    //        if(orderObj.GetComponent<OrderRelay>().GetOrdePossibleRep())
    //        {
    //            select.Add(orderObj);
    //        }
    //    }

    //    if(select.Count > 0)
    //    {
    //        target = select[Random.Range(0, select.Count)].GetComponent<OrderRelay>();
    //        return true;
    //    }

    //    return false;
    //}

    //�˗��̒��I
    void LotteryOrder()
    {
        //���A�x����
        OrdersRarity rare = OrdersRarity.OR_Common;

        //����̒l�𒊑I
        float rate = Random.value;

        //���A�x���m�肳����
        foreach (var value in popRate)
        {
            if(rate < value)
            {
                break;
            }
            else
            {
                rate -= value;
                rare++;
            }
        }

        //�˗�ID����
        int id = 0;

        if (rare == OrdersRarity.OR_Common)
        {
            id = commonId;
        }
        else if (rare == OrdersRarity.OR_Rare)
        {
            id = rareId;
        }
        else if (rare == OrdersRarity.OR_SuperRare)
        {
            id = superRareId;
        }
        else
        {
            Debug.Log("�˗�����Ńo�O���Ă܂�(OrderMaster)");
        }

        //�˗�OBJ�ɓo�^
        if (target != null)
        {
            target.SetOrder(rare, id);
        }
    }
}
