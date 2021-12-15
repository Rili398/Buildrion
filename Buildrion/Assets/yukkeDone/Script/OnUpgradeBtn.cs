using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnUpgradeBtn : MonoBehaviour
{
    public GameObject infoBtnCvs;
    public GameObject infoBtn;
    public GameObject upgradeBtn;

    public Animator InfoAnimator;
    public Animator UpgradAnimator;


    public void Onclick()
    {
        infoBtn.GetComponent<Button>().interactable = false;
        //infoBtnCvs.SetActive(false);
        //upgradeBtn.SetActive(true);
        InfoAnimator.GetComponent<Animator>().SetBool("Open", true);
        UpgradAnimator.GetComponent<Animator>().SetBool("Open", true);
    }
    
}
