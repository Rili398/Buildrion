using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour
{
    // �}�E�X�z�C�[���̉�]�l���i�[����ϐ�
    private float scroll;
    // �J�����ړ��̑��x
    public float speed = 1f;

    // �Q�[�����s���̌J��Ԃ�����
    void Update()
    {
        // �}�E�X�z�C�[���̉�]�l��ϐ� scroll �ɓn��
        scroll = Input.GetAxis("Mouse ScrollWheel");

        // �J�����̑O��ړ�����
        //�i�J�����������Ă������ forward �ɕϐ� scroll �� speed ����Z���ĉ��Z����j
        Camera.main.transform.position += transform.forward * scroll * speed;
    }
}