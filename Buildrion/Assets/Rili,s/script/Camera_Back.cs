using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Back : MonoBehaviour
{
    private GameObject mainCamera;      //���C���J�����i�[�p
    private GameObject subCamera;       //�T�u�J�����i�[�p 
    public GameObject Camera_Active;


    //�Ăяo�����Ɏ��s�����֐�
    void Start()
    {
        //���C���J�����ƃT�u�J���������ꂼ��擾
        mainCamera = GameObject.Find("Main Camera");
        subCamera = GameObject.Find("Sub Camera");
        Camera_Active = GameObject.Find("Button");


        Camera_Active.GetComponent<fillbottom>().Camera_Actve(true, false);

    }
}
