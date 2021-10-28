using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OrderboardDisplay : MonoBehaviour
{
    [SerializeField] GameObject g_orderName;
    [SerializeField] int g_reward;
    [SerializeField] GameObject g_orderNumber;
    [SerializeField] int g_rareNumber;
    GameObject[] g_buttons = new GameObject[2];

    GameObject g_unableBoard;

    // Start is called before the first frame update
    void Start()
    {
        //Text g_orderName = g_orderName.GetComponent<Text>();
        //g_orderName.text = "}‘ŠÙ‚ğŒš‚Ä‚Ä‚­‚¾‚³‚¢!!";
        g_orderName.GetComponent<Text>().text = "}‘ŠÙ‚ğŒš‚Ä‚Ä‚­‚¾‚³‚¢!!";

        GameObject RewardText = GameObject.Find("rewardText");
        RewardText.GetComponent<Text>().text = "g_reward + ‰~";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
