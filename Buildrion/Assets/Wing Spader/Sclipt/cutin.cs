using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cutin : MonoBehaviour
{

    public Sprite ga;
    public Sprite tai;

    double time = 0.0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1.5)
        {
            changeSprite();
        }

        if (time > 3.0)
        {
            Destroy(gameObject);
        }



    }

    public void changeSprite()
    {
        this.gameObject.GetComponent<Image>().sprite = tai;
    }
}
