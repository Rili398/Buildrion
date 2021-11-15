using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updownButton : MonoBehaviour
{

    private int number = 0;
    private int numberMin = 0;
    private int numberMax = 0;
    public Text numberText;

    const int differenceamount = 3;

    // Start is called before the first frame update
    void Start()
    {
        numberMin = 3;
        numberMax = 21;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void add()
    {
        number += differenceamount;
        numberText.text = number.ToString();

        if (number > numberMax)
        {
            number = numberMax;
            numberText.text = number.ToString();
        }
    }

    public void disadd()
    {
        number -= differenceamount;
        numberText.text = number.ToString();

        if (number < numberMin)
        {
            number = numberMin;
            numberText.text = number.ToString();
        }
    }


}
