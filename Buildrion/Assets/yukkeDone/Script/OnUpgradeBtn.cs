using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnUpgradeBtn : MonoBehaviour
{
    public GameObject infoBtnCvs;
    public GameObject infoBtn;
    public GameObject CloseBtn;

    public Animator InfoAnimator;
    public Animator UpgradAnimator;


    public void Onclick()
    {
        //infoBtn.GetComponent<Button>().interactable = false;
        //infoBtnCvs.SetActive(false);
        //CloseBtn.SetActive(true);
        InfoAnimator.GetComponent<Animator>().SetBool("Open", !InfoAnimator.GetBool("Open"));
        UpgradAnimator.GetComponent<Animator>().SetBool("Open", !UpgradAnimator.GetBool("Open"));
    }
    
}
