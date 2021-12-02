using UnityEngine;
using UnityEngine.UI;

//ロボット数アップグレードボタン

public class RoboCntUG : MonoBehaviour
{
    [SerializeField] private RobotBase roboBase;
    [SerializeField] private Button upGradeButton;
    [SerializeField] private Text levelText;
    [SerializeField] private Text costText;
    [SerializeField] private Text upgradeText;

    [Header("レベル／最大値")]
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

        //テキスト更新
        levelText.text = "Level." + level;
        costText.text = "COST:" + nextCost;
        upgradeText.text = nowRoboCnt + " → " + nextRoboCnt;
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

        //お金更新
        Singleton<GameManager>.Instance.AddMoney(-nextCost);

        //レベルを上げて情報更新
        level += 1;
        nextCost = table.roboUGT[level - 1].cost;
        nowRoboCnt = nextRoboCnt;
        nextRoboCnt = table.roboUGT[level - 1].roboMax;

        //テキスト更新
        levelText.text = "Level." + level;
        costText.text = "COST:" + nextCost;
        upgradeText.text = nowRoboCnt + " → " + nextRoboCnt;

        //roboBaseを更新
        roboBase.robotMax = nowRoboCnt;
        roboBase.AddRobotList(addNum);
    }
}

/*ボタンでレベルアップするUI設計
 * ・構造体配列で次のコスト、次のロボット数を管理
 * ・GameManagerからお金情報持ってきて、やる
 * ・InteractableのチェックボックスをTF切り替えてやる
 */
