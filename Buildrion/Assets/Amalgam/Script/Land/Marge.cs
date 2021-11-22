using UnityEngine;

//土地に付ける　合体用コンポーネント

public class Marge : MonoBehaviour
{
    [SerializeField] private Land myLand;
    public bool isMarge;
    //合体ボタン変数

    void Start()
    {
        myLand = GetComponent<Land>();
        isMarge = false;
        //合体ボタン変数Find
    }

    //=========================================================================

    public int GetRobotCnt()
    {
        return myLand.robotCnt;
    }

    public void ChangeBuildrion(bool command = true)
    {
        isMarge = command;
        myLand.margeRate = 3.0f;    //合体倍率
    }

    //=========================================================================

    //クリックされたら関数
    public void OnClick()
    {
        //合体ボタンに登録　Set〇〇
        Debug.Log("合体！");
    }
}
