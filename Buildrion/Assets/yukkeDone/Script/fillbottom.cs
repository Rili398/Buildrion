using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fillbottom : MonoBehaviour
{
    public Image UIimg;
    public GameObject UIbackimg;
    public Button UIbtn;
    
    //private float fillamountMax = 1.0f;
    public float countTime = 5.0f;

    private Marge marge;
    private gattai gSystem;

    private void Start()
    {
        gSystem = GetComponent<gattai>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UIimg.fillAmount < 1.0f)
        {
            UIimg.fillAmount += 1.0f / countTime * Time.deltaTime;
        }
        else
        {
            Debug.Log(marge);

            if (marge == null)
                return;

            Debug.Log(marge.GetRobotCnt());

            if (marge.isWarking)
            {
                if (marge.GetRobotCnt() >= 6)
                {
                    UIimg.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    UIbtn.interactable = true;
                    UIbackimg.SetActive(false);
                }
            }
            else
            {
                UIbtn.interactable = false;
            }
        }
    }

    public void SetMarge(Marge inmarge)
    {
        marge = inmarge;
    }

    public void Fusion()
    {
        // ここでタイムライン再生
        gSystem.Fusion();
        // カメラ切り替え?
        Camera_Actve(false, true);
        // fillamount初期状態戻す関数
        Resetfillamount();
    }

    private void Resetfillamount()
    {
        UIbackimg.SetActive(true);
        UIbtn.interactable = false;
        UIimg.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        UIimg.fillAmount = 0.0f;
    }

    public void Camera_Actve(bool MainActive,bool SubAutive)
    {
        MainActive = false;
        SubAutive = false;
    }
}
