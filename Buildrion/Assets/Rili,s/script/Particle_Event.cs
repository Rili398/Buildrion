using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Event : MonoBehaviour
{

    public ParticleSystem particle;


    public void OnMouse() //�|�C���^�[���I�u�W�F�N�g�ɏ�����Ƃ�
    {
        Debug.Log("�}�E�X��In�������I");
        particle.Play();

    }
    public void OutMouse() //�|�C���^�[���I�u�W�F�N�g���痣�ꂽ�Ƃ�
    {
        Debug.Log("�}�E�X��Out�������I");
        particle.Stop();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            particle.Play();

        }


    }
}
