using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fillbottom : MonoBehaviour
{
    public Image UIimg;
    public GameObject UIbackimg;
    public Button UIbtn;
    public Button upgradUI;
    
    //private float fillamountMax = 1.0f;
    public float countTime = 5.0f;

    private Marge marge;
    private gattai gSystem;

    private GameObject mainCamera;      //メインカメラ格納用
    private GameObject subCamera;       //サブカメラ格納用 

    private bool margeExistFlg;

    private void Start()
    {
        gSystem = GetComponent<gattai>();

        mainCamera = GameObject.Find("Main Camera");
        subCamera = GameObject.Find("Sub Camera");

        subCamera.SetActive(false);
        margeExistFlg = false;
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
            if (marge == null || !margeExistFlg)
                return;

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
        margeExistFlg = true;
    }

    public void Fusion()
    {
        // ここでタイムライン再生
        gSystem.Fusion();
        // カメラ切り替え
        //Camera_Actve(false,true);
        marge.ChangeBuildrion();
        Singleton<GameManager>.Instance.isTimeStop = true;
        margeExistFlg = false;

        UIbtn.interactable = false;
        upgradUI.interactable = false;

        Singleton<SoundManager>.Instance.PlaySeByName("gattai_button");
    }

    public void Resetfillamount()
    {
        UIbackimg.SetActive(true);
        UIbtn.interactable = false;
        UIimg.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        UIimg.fillAmount = 0.0f;

        upgradUI.interactable = true;

        marge.timeStop = false;
        Singleton<GameManager>.Instance.isTimeStop = false;
        marge = null;
        margeExistFlg = false;
    }

    public void Camera_Actve(bool MainActive,bool SubActive)
    {
        if(MainActive == true && SubActive == false)
        {
            mainCamera.SetActive(true);
            subCamera.SetActive(false);
        }

        if (MainActive == false && SubActive == true)
        {
            mainCamera.SetActive(false);
            subCamera.SetActive(true);
        }

    }
}
