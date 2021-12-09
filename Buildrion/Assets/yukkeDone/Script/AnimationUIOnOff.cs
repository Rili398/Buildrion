using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationUIOnOff : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            animator.SetBool("Open", !animator.GetBool("Open"));
        }
    }
}
