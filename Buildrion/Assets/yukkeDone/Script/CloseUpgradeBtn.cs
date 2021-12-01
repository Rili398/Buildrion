using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseUpgradeBtn : MonoBehaviour
{
    public GameObject closeobject;
    public GameObject Ongameobject;
    public Button infoBtn;


    public void OnClick()
    {
        closeobject.SetActive(false);

        Ongameobject.SetActive(true);

        infoBtn.GetComponent<Button>().interactable = true;
    }
}
