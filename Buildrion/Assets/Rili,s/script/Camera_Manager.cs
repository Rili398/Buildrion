using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager : MonoBehaviour
{
    private GameObject mainCamera;      //メインカメラ格納用
    private GameObject subCamera;       //サブカメラ格納用 


    //呼び出し時に実行される関数
    void Start()
    {
        //メインカメラとサブカメラをそれぞれ取得
        mainCamera = GameObject.Find("Main Camera");
        subCamera = GameObject.Find("Sub Camera");

        //サブカメラを非アクティブにする
        Camera_Actve(false, true);
    }


    //単位時間ごとに実行される関数

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
