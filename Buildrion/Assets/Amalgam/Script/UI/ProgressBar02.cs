using UnityEngine;
using UnityEngine.UI;

public class ProgressBar02 : MonoBehaviour
{
    [SerializeField] private Slider progressBar;

    // Start is called before the first frame update
    void Start()
    {
        progressBar = transform.GetChild(0).GetComponent<Slider>();

        progressBar.value = 0;
    }

    //=========================================================================

    public void AddValue(float add)
    {
        if (!GetIsMax())
        {
            progressBar.value += add;
        }
    }

    public void ResetProgress()
    {
        progressBar.value = 0;
    }

    public void SetMaxValue(float inMaxValue)
    {
       progressBar.maxValue = inMaxValue;
    }

    public bool GetIsMax()
    {
        return progressBar.maxValue <= progressBar.value;
    }
}
