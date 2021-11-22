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
        subCamera.SetActive(false);
    }


    //�P�ʎ��Ԃ��ƂɎ��s�����֐�
    void Update()
    {
        //�X�y�[�X�L�[��������Ă���ԁA�T�u�J�������A�N�e�B�u�ɂ���
        if (Input.GetKey("space"))
        {
            //�T�u�J�������A�N�e�B�u�ɐݒ�
            mainCamera.SetActive(false);
            subCamera.SetActive(true);
        }
        else
        {
            //���C���J�������A�N�e�B�u�ɐݒ�
            subCamera.SetActive(false);
            mainCamera.SetActive(true);
        }
    }
}
