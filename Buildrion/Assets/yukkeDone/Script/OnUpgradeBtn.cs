using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnUpgradeBtn : MonoBehaviour
{
    public GameObject infoBtnCvs;
    public GameObject infoBtn;
    public GameObject upgradeBtn;
    
    public void Onclick()
    {
        infoBtn.GetComponent<Button>().interactable = false;
        infoBtnCvs.SetActive(false);
        upgradeBtn.SetActive(true);
    }
    
}
