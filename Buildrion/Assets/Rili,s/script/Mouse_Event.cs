using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Event : MonoBehaviour
{
    public void OnMouse() //ポインターがオブジェクトに乗ったとき
    {
        Debug.Log("マウスがInしたお！");
        //  transform.localScale *= 1.5f;
    }

    public void OutMouse() //ポインターがオブジェクトから離れたとき
    {
        Debug.Log("マウスがOutしたお！");

    }

    public void MouseCrick() //ポインターがオブジェクトを押下したとき
    {
        Debug.Log("マウスがクリックしたお！");

    }

    public void MouseCrick_Out() //ポインターを押下状態から離したとき
    {
        Debug.Log("マウスのクリックが離れたお！");
    }

    public void MouseDrag() //オブジェクトがドラッグされている間
    {
        Debug.Log("マウスに引っ張られてるお！");
    }


}
