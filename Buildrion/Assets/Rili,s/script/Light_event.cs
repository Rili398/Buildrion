using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_event : MonoBehaviour
{

    public GameObject pointlight;
    private void Start()
    {
        pointlight.SetActive(false);

    }


    public void OnMouse() //ポインターがオブジェクトに乗ったとき
    {
        pointlight.SetActive(true);
    }

    public void OutMouse() //ポインターがオブジェクトに乗ったとき
    {
        pointlight.SetActive(false);
    }

}
