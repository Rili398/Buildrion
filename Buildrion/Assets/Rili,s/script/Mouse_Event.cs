using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Event : MonoBehaviour
{
    void Start()
    {     
    }



    public void OnMouse() //�|�C���^�[���I�u�W�F�N�g�ɏ�����Ƃ�
    {
        Debug.Log("�}�E�X��In�������I");

    }

    public void OutMouse() //�|�C���^�[���I�u�W�F�N�g���痣�ꂽ�Ƃ�
    {
        Debug.Log("�}�E�X��Out�������I");


    }

    public void MouseCrick() //�|�C���^�[���I�u�W�F�N�g�����������Ƃ�
    {
        Debug.Log("�}�E�X���N���b�N�������I");

    }

    public void MouseCrick_Out() //�|�C���^�[��������Ԃ��痣�����Ƃ�
    {
        Debug.Log("�}�E�X�̃N���b�N�����ꂽ���I");
    }

    public void MouseDrag() //�I�u�W�F�N�g���h���b�O����Ă����
    {
        Debug.Log("�}�E�X�Ɉ��������Ă邨�I");

        Vector3 objectPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 pointScreen = new Vector3(Input.mousePosition.x,Input.mousePosition.y,objectPoint.z);

        Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);

       // pointWorld.z = transform.position.z;

        transform.position = pointWorld;
    }


}
