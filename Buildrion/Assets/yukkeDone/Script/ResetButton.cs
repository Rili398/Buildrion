using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public GameObject unionbutton;

    // Start is called before the first frame update
    void Start()
    {
        unionbutton = GameObject.Find("buttton");

        unionbutton.GetComponent<ResetButton>();
    }

    
}
