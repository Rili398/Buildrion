using UnityEngine;
using UnityEngine.UI;

//�I�v�V�����Ƃ��̊Ǘ�������\��

public class GameManager : Singleton<GameManager>
{
    [Header("������")]
    [SerializeField] private int money;
    [SerializeField] private Text moneyText;

    [Header("���{�b�g��")]
    [SerializeField] private RobotBase roboBase;
    [SerializeField] private Text roboText;

    [Header("���̎��̔{��")]
    [SerializeField] private float margedRate;


    void Start()
    {
        //�t���[�����[�g�ݒ�
        Application.targetFrameRate = 60;

        roboBase = GameObject.FindGameObjectWithTag("RobotBase").GetComponent<RobotBase>();

        margedRate = 3.0f;
    }

    private void Update()
    {
        if (moneyText != null)
        {
            moneyText.text = "MONEY :" + money.ToString("D8");
        }

        if(roboText != null)
        {
            roboText.text = "���{���^�ő吔 = " + roboBase.GetNowRobotCnt() + "�^" + roboBase.robotMax;
        }
    }

    //=========================================================================

    public void AddMoney(int value)
    {
        money += value;
    }

    public int GetMoney()
    {
        return money;
    }

    public float GetMargeRate()
    {
        return margedRate;
    }

    public void SetMargeRate(float inMRate)
    {
        margedRate = inMRate;
    }
}
