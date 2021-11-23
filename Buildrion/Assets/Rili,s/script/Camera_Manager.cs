using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager : MonoBehaviour
{
    private GameObject mainCamera;      //���C���J�����i�[�p
    private GameObject subCamera;       //�T�u�J�����i�[�p 


    //�Ăяo�����Ɏ��s�����֐�
    void Start()
    {
        //���C���J�����ƃT�u�J���������ꂼ��擾
        mainCamera = GameObject.Find("Main Camera");
        subCamera = GameObject.Find("Sub Camera");

        //�T�u�J�������A�N�e�B�u�ɂ���
        Camera_Actve(false, true);
    }


    //�P�ʎ��Ԃ��ƂɎ��s�����֐�

    public void Camera_Actve(bool MainActive, bool SubActive)
    {
        if (MainActive == true && SubActive == false)
        {
            mainCamera.SetActive(true);
            subCamera.SetActive(false);
        }

        if (MainActive == false && SubActive == true)
        {
            mainCamera.SetActive(false);
            subCamera.SetActive(true);
        }

    }

}
