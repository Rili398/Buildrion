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

    [Header("�C���^�[�o��")]
    [SerializeField] private float intervalTime = 0.5f;

    //=========================================================================

    public void OrderCatcher(Vector3 dist, int num)
    {
        StartCoroutine(DispatchRobot(dist, num));
    }

    private IEnumerator DispatchRobot(Vector3 dist, int num)
    {
        for(int i = 0; i < num; i++)
        {
            //���X�g����L�������ĖړI�n��`����B

            yield return new WaitForSeconds(intervalTime);
        }
    }

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
