using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_event : MonoBehaviour
{

    public GameObject pointlight;
    private void Start()
    {
        pointlight.SetActive(false);

    }


    public void OnMouse() //�|�C���^�[���I�u�W�F�N�g�ɏ�����Ƃ�
    {
        pointlight.SetActive(true);
    }

    public void OutMouse() //�|�C���^�[���I�u�W�F�N�g�ɏ�����Ƃ�
    {
        pointlight.SetActive(false);
    }

}
