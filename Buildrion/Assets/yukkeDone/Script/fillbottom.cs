using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fillbottom : MonoBehaviour
{
    public Image UIimg;
    public Button UIbtn;
    private bool roop;
    //private float fillamountMax = 1.0f;
    public float countTime = 5.0f;

    private void Start()
    {
        roop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(roop)
        {
            if (UIimg.fillAmount < 1.0f)
            {
                UIimg.fillAmount += 1.0f / countTime * Time.deltaTime;
            }
            else
            {
                UIimg.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                UIbtn.interactable = true;
                roop = false;
            }
        }
    }

}
