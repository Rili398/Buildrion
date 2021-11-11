using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updownButton : MonoBehaviour
{

    private int number = 0;
    private int numberMin = 3;
    private int numberMax = 21;
    public Text numberText;

    const int differenceamount = 3;

    // Start is called before the first frame update
    void Start()
    {
        numberText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void add()
    {
        if (number >= numberMax)
            return;

        number += differenceamount;
        numberText.text = number.ToString();
    }

    public void disadd()
    {
        if (number <= numberMin)
            return;

        number -= differenceamount;
        numberText.text = number.ToString();
    }


}
