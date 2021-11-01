using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OrderboardDisplay : MonoBehaviour
{
    [SerializeField] GameObject g_orderNameText;
    [SerializeField] GameObject g_rewardText;
    [SerializeField] GameObject g_orderNumberText;
    [SerializeField] GameObject g_rareNumberText;
    [SerializeField] GameObject g_needbuildrionText;

    private GameObject orderboardImage;
    private GameObject acceptImage;
    private GameObject destrcutionImage;

    // Start is called before the first frame update
    void Start()
    {
        //Text g_orderName = g_orderName.GetComponent<Text>();
        //g_orderName.text = "}‘ŠÙ‚ğŒš‚Ä‚Ä‚­‚¾‚³‚¢!!";
        //g_orderName.GetComponent<Text>().text = "}‘ŠÙ‚ğŒš‚Ä‚Ä‚­‚¾‚³‚¢!!";


        GameObject orderboardImage = GameObject.Find("orderboardImage");
        GameObject acceptImage = GameObject.Find("acceptImage");
        GameObject destrcutionImage = GameObject.Find("destrcutionImage");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
