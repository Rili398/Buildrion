using UnityEngine;
using UnityEngine.UI;

//���{�b�g���A�b�v�O���[�h�{�^��

public class RoboCntUG : MonoBehaviour
{
    [SerializeField] private RobotBase roboBase;
    [SerializeField] private Button upGradeButton;
    [SerializeField] private Text levelText;
    [SerializeField] private Text costText;
    [SerializeField] private Text upgradeText;

    [Header("���x���^�ő�l")]
    [SerializeField] private int maxLevel = 10; 
    [SerializeField] private int level;
    private int nextCost;
    private int nowRoboCnt;
    private int nextRoboCnt;

    RcUpGradeTable table;

    // Start is called before the first frame update
    void Start()
    {
        roboBase = GameObject.FindGameObjectWithTag("RobotBase").GetComponent<RobotBase>();
        table = new RcUpGradeTable();
        level = 1;
        nextCost = table.roboUGT[level - 1].cost;
        nowRoboCnt = roboBase.defaultMax;
        nextRoboCnt = table.roboUGT[level - 1].roboMax;

        //�e�L�X�g�X�V
        levelText.text = "Level." + level;
        costText.text = "COST:" + nextCost;
        upgradeText.text = nowRoboCnt + " �� " + nextRoboCnt;
    }

    // Update is called once per frame
    void Update()
    {
        if (Singleton<GameManager>.Instance.GetMoney() >= nextCost)
        {
            upGradeButton.interactable = true;
            costText.color = Color.black;
        }
        else
        {
            upGradeButton.interactable = false;
            costText.color = Color.red;
        }
    }

    //=========================================================================

    public void Upgrade()
    {
        if(Singleton<GameManager>.Instance.isGameEnd)
        {
            return;
        }

        if(level >= maxLevel)
        {
            return;
        }

        int addNum = nextRoboCnt - nowRoboCnt;

        //�����X�V
        Singleton<GameManager>.Instance.AddMoney(-nextCost);

        //���x�����グ�ď��X�V
        level += 1;
        nextCost = table.roboUGT[level - 1].cost;
        nowRoboCnt = nextRoboCnt;
        nextRoboCnt = table.roboUGT[level - 1].roboMax;

        //�e�L�X�g�X�V
        levelText.text = "Level." + level;
        costText.text = "COST:" + nextCost;
        upgradeText.text = nowRoboCnt + " �� " + nextRoboCnt;

        //roboBase���X�V
        roboBase.robotMax = nowRoboCnt;
        roboBase.AddRobotList(addNum);
    }
}

/*�{�^���Ń��x���A�b�v����UI�݌v
 * �E�\���̔z��Ŏ��̃R�X�g�A���̃��{�b�g�����Ǘ�
 * �EGameManager���炨����񎝂��Ă��āA���
 * �EInteractable�̃`�F�b�N�{�b�N�X��TF�؂�ւ��Ă��
 */
