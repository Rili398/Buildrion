using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rim_Change : MonoBehaviour
{

    public Material basemat;
    public Material rimmat;
    private int colorswitch = 0;

    public void MouseCrick() //�|�C���^�[���I�u�W�F�N�g�����������Ƃ�
    {
        Debug.Log("�}�E�X���N���b�N�������I");

        colorswitch++;

        if(colorswitch % 2 == 1)
        {
            gameObject.GetComponent<Renderer>().material = rimmat;

        }
        if (colorswitch % 2 == 0)
        {
            gameObject.GetComponent<Renderer>().material = basemat;

        }



    }


}
