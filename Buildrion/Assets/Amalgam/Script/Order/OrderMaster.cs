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

public class OrderMaster : Singleton<OrderMaster>
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
    [SerializeField] private int commonIdMax = 1;
    [SerializeField] private int rareIdMax = 1;
    [SerializeField] private int superRareIdMax = 1;

    // Start is called before the first frame update
    void Start()
    {
        //�˗��������Ԃ̐ݒ�
        orderTimer = new GameTimer(Mathf.Floor(Random.Range(timerMin, timerMax)));
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
            Debug.Log("�D��x:" + priority);
            Debug.Log("�˗�����:" + result);

            //�˗��̒��I
            if(result)
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
            result = CheckRepairOrder();
        }
        else
        {
            result = CheckRepairOrder();
            result = CheckConstructionOrder();
        }

        //�˗��������������A���ʕ�
        return result;
    }
    
    //���z�˗��̔��������`�F�b�N
    bool CheckConstructionOrder()
    {
        //�V�[�����̓y�n���擾���āA�����`�F�b�N
        //

        return true;
    }

    //���C�˗��̔��������`�F�b�N
    bool CheckRepairOrder()
    {
        //�V�[�����̓y�n���擾���āA�����`�F�b�N
        //

        return true;
    }

    //�˗��̒��I
    void LotteryOrder()
    {
        //���A�x����
        OrdersRarity rare = OrdersRarity.OR_Max;

        //����̒l�𒊑I
        float rate = Random.value;

        //���A�x���m�肳����
        foreach(var value in popRate)
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

        if(rare == OrdersRarity.OR_Common)
        {
            id = Mathf.FloorToInt(Random.Range(0, commonIdMax));
        }
        else if (rare == OrdersRarity.OR_Rare)
        {
            id = Mathf.FloorToInt(Random.Range(0, rareIdMax));
        }
        else if (rare == OrdersRarity.OR_SuperRare)
        {
            id = Mathf.FloorToInt(Random.Range(0, superRareIdMax));
        }
        else
        {
            Debug.Log("�˗�����Ńo�O���Ă܂�(OrderMaster)");
        }

        //�˗�OBJ�ɓo�^
        target.SetOrder(rare, id);
    }
}
