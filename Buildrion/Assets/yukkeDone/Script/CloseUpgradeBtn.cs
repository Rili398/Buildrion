using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseUpgradeBtn : MonoBehaviour
{
    public GameObject closeobject;
    public GameObject Ongameobject;


    public void OnClick()
    {
        closeobject.SetActive(false);

        Ongameobject.SetActive(true);

        if (Ongameobject.GetComponent<Button>() == null)
            return;
        Ongameobject.GetComponent<Button>().interactable = true;
    }
}
