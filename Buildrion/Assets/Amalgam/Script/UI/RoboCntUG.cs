using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ロボット数アップグレードボタン

public class RoboCntUG : MonoBehaviour
{
    [SerializeField] private RobotBase roboBase;
    [SerializeField] private Text levelText;
    [SerializeField] private Text costText;
    [SerializeField] private Text upgradeText;

    [SerializeField] private int level;
    private int nextCost;
    private int nowRoboCnt;
    private int nextRoboCnt;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*ボタンでレベルアップするUI設計
 * ・構造体配列で次のコスト、次のロボット数を管理
 * ・GameManagerからお金情報持ってきて、やる
 * ・InteractableのチェックボックスをTF切り替えてやる
 */
