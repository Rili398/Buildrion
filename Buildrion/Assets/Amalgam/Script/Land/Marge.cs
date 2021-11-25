using UnityEngine;

//土地に付ける　合体用コンポーネント

public class Marge : MonoBehaviour
{
    [SerializeField] private Land myLand;
    public bool isMarge;
    //合体ボタン変数
    private fillbottom margeButton;

    public bool isWarking;
    public bool timeStop;

    void Start()
    {
        myLand = GetComponent<Land>();
        isMarge = false;
        margeButton = GameObject.FindGameObjectWithTag("MargeButton").GetComponent<fillbottom>();

        isWarking = false;
        timeStop = false;
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
        timeStop = true;
    }

    //=========================================================================

    //クリックされたら関数
    public void OnClick()
    {
        margeButton.SetMarge(this);
    }
}
