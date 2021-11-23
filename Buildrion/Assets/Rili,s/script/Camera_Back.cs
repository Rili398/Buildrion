using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Back : MonoBehaviour
{
    private GameObject mainCamera;      //メインカメラ格納用
    private GameObject subCamera;       //サブカメラ格納用 
    public GameObject Camera_Active;


    //呼び出し時に実行される関数
    void Start()
    {
        //メインカメラとサブカメラをそれぞれ取得
        mainCamera = GameObject.Find("Main Camera");
        subCamera = GameObject.Find("Sub Camera");
        Camera_Active = GameObject.Find("Button");


        Camera_Active.GetComponent<fillbottom>().Camera_Actve(true, false);

    }
}
