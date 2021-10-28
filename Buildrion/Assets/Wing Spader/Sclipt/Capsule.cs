using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    //‡‘ÌŒ³Ši”[—p‚Ì•Ï”
    string sozai1; 
    string sozai2;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSozai(string name1, string name2)
    {
        //‘fŞ“ü‚ê
        sozai1 = name1;
        sozai2 = name2;
    }

    public string GetSozai1()
    {
        return sozai1;
    }

    public string GetSozai2()
    {
        return sozai2;
    }
}
