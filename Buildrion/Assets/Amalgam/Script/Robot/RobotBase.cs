using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���{�b�g�̑䐔�A�ő吔�A���{�b�g���Ƃ̍�Ɨ͂��Ǘ�����

public class RobotBase : MonoBehaviour
{
    private int robotMax { get; set; }

    [Header("���݊�n�Ɏc���Ă��郍�{�b�g�̐�")]
    [SerializeField] private int nowRobotCnt;

    [Header("���{�b�g��@������̍�Ɨ�")]
    [SerializeField] private float baseWarkPower;

    //=========================================================================

    public int GetNowRobotCnt()
    {
        return nowRobotCnt;
    }

    public void SetBaseWarkPower(float wPower)
    {
        baseWarkPower = wPower;
    }
}
