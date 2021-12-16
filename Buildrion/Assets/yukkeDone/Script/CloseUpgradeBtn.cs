using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseUpgradeBtn : MonoBehaviour
{
    public GameObject closeobject;
    public GameObject Ongameobject;
    public Button infoBtn;

    public Animator InfoAnim;
    public Animator UpgradAnim;

    public void OnClick()
    {
        InfoAnim.GetComponent<Animator>().SetBool("Open", false);
        UpgradAnim.GetComponent<Animator>().SetBool("Open", false);
        //closeobject.SetActive(false);
        //Ongameobject.SetActive(true);

        infoBtn.GetComponent<Button>().interactable = true;
    }
}
