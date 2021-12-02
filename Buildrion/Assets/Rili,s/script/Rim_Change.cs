using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rim_Change : MonoBehaviour
{

    public Material basemat;
    public Material rimmat;
    private int colorswitch = 0;

    public void MouseCrick() //ポインターがオブジェクトを押下したとき
    {
        Debug.Log("マウスがクリックしたお！");

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
