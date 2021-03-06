using UnityEngine;
using UnityEngine.UI;

//バーの中身を操作

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
        if (Singleton<GameManager>.Instance.isGameEnd)
        {
            return;
        }

        progressBar.fillAmount = value;
    }

    public void ResetPb()
    {
        value = 0;
    }
}
