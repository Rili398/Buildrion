using UnityEngine;

/// <summary>
/// GameビューにてSceneビューのようなカメラの動きをマウス操作によって実現する
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

    public float Limit_Hi_x = 0;
    public float Limit_Low_x = 0;

    public float Limit_Hi_y = 0;
    public float Limit_Low_y = 0;

    public float Limit_Hi_z = 0;
    public float Limit_Low_z = 0;



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




        mousePos.x = Mathf.Clamp(transform.position.x, this.Limit_Low_x, this.Limit_Hi_x);

        mousePos.y = Mathf.Clamp(transform.position.y, this.Limit_Low_y, this.Limit_Hi_y);

        mousePos.z = Mathf.Clamp(transform.position.z, this.Limit_Low_z, this.Limit_Hi_z);

        transform.position = new Vector3(mousePos.x, mousePos.y, mousePos.z);

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
    // マウスホイールの回転値を格納する変数
    private float scroll;
    // カメラ移動の速度
    public float speed = 1f;


    // ゲーム実行中の繰り返し処理
    void Update()
    {

    // マウスホイールの回転値を変数 scroll に渡す
    scroll = Input.GetAxis("Mouse ScrollWheel");
        // カメラの前後移動処理
        //（カメラが向いている方向 forward に変数 scroll と speed を乗算して加算する）
        Camera.main.transform.position += transform.forward * scroll * speed;
    }
}*/
