using UnityEngine;

//�y�n�ɕt����@���̗p�R���|�[�l���g

public class Marge : MonoBehaviour
{
    [SerializeField] private Land myLand;
    public bool isMarge;
    //���̃{�^���ϐ�

    void Start()
    {
        myLand = GetComponent<Land>();
        isMarge = false;
        //���̃{�^���ϐ�Find
    }

    //=========================================================================

    public int GetRobotCnt()
    {
        return myLand.robotCnt;
    }

    public void ChangeBuildrion(bool command = true)
    {
        isMarge = command;
        myLand.margeRate = 3.0f;    //���̔{��
    }

    //=========================================================================

    //�N���b�N���ꂽ��֐�
    public void OnClick()
    {
        //���̃{�^���ɓo�^�@Set�Z�Z
        Debug.Log("���́I");
    }
}
