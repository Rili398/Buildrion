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

        closeobject.SetActive(false);
        Ongameobject.SetActive(true);

        InfoAnim.GetComponent<Animator>().SetBool("Open", !InfoAnim.GetBool("Open"));
        UpgradAnim.GetComponent<Animator>().SetBool("Open", !InfoAnim.GetBool("Open"));
        //infoBtn.GetComponent<Button>().interactable = true;
    }
}
