using UnityEngine;
using UnityEngine.UI;

//�I�v�V�����Ƃ��̊Ǘ�������\��

public class GameManager : Singleton<GameManager>
{
    [Header("������")]
    [SerializeField] private int money;
    [SerializeField] private Text moneyText;

    void Start()
    {
        //�t���[�����[�g�ݒ�
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        moneyText.text = "MONEY :" + money.ToString("D8");
    }

    public void AddMoney(int value)
    {
        money += value;
    }
}
