using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Event : MonoBehaviour
{

    public ParticleSystem particle;


    public void OnMouse() //ポインターがオブジェクトに乗ったとき
    {
        Debug.Log("マウスがInしたお！");
        particle.Play();

    }
    public void OutMouse() //ポインターがオブジェクトから離れたとき
    {
        Debug.Log("マウスがOutしたお！");
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
