using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Event : MonoBehaviour
{
       // Material red = Resources.Load<Material>("sozai/materials/red");
       // Material rim = Resources.Load<Material>("sozai/materials/red");

    public Material basemat;
    public Material rimmat;

    void Start()
    {

    }



    public void OnMouse() //ポインターがオブジェクトに乗ったとき
    {
        Debug.Log("マウスがInしたお！");
        // クラスAのGameObject
        gameObject.GetComponent<Renderer>().material = rimmat;
    }

    public void OutMouse() //ポインターがオブジェクトから離れたとき
    {
        Debug.Log("マウスがOutしたお！");

        gameObject.GetComponent<Renderer>().material = basemat;

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

        Vector3 objectPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 pointScreen = new Vector3(Input.mousePosition.x,Input.mousePosition.y,objectPoint.z);

        Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);

       // pointWorld.z = transform.position.z;

        transform.position = pointWorld;
    }


}
