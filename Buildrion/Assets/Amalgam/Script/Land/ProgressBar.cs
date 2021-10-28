using UnityEngine;
using UnityEngine.UI;

//ƒo[‚Ì’†g‚ð‘€ì

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    public float value { get; set; } = 0;

    private void Awake()
    {
        //Canvas => Bar
        progressBar = transform.GetChild(1).GetComponent<Image>();
    }

    void Update()
    {
        progressBar.fillAmount = value;
    }
}
