using UnityEngine;

/// <summary>
/// Game�r���[�ɂ�Scene�r���[�̂悤�ȃJ�����̓������}�E�X����ɂ���Ď�������
/// </summary>
[RequireComponent(typeof(Camera))]
public class camera_move : MonoBehaviour
{
    [SerializeField, Range(0.1f, 10f)]
    private float wheelSpeed = 1f;

    [SerializeField, Range(0.1f, 10f)]
    private float moveSpeed = 1f;

    [SerializeField, Range(0.1f, 10f)]
    private float rotateSpeed = 1f;

    private Vector3 preMousePos;

    private void Update()
    {
        MouseUpdate();
        return;
    }

    private void MouseUpdate()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0.0f)
            MouseWheel(scrollWheel);

        if (Input.GetMouseButtonDown(0) ||
           Input.GetMouseButtonDown(1) ||
           Input.GetMouseButtonDown(2))
            preMousePos = Input.mousePosition;

        MouseDrag(Input.mousePosition);
    }

    private void MouseWheel(float delta)
    {
        transform.position += transform.forward * delta * wheelSpeed;
        return;
    }

    private void MouseDrag(Vector3 mousePos)
    {
        Vector3 diff = mousePos - preMousePos;

        if (diff.magnitude < Vector3.kEpsilon)
            return;

        if (Input.GetMouseButton(0))
            transform.Translate(-diff * Time.deltaTime * moveSpeed);
        else if (Input.GetMouseButton(1))
            CameraRotate(new Vector2(-diff.y, diff.x) * rotateSpeed);

        preMousePos = mousePos;
    }

    public void CameraRotate(Vector2 angle)
    {
        transform.RotateAround(transform.position, transform.right, angle.x);
        transform.RotateAround(transform.position, Vector3.up, angle.y);
    }
}




/*using System.Collections;
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
}*/
