using UnityEngine;

public class CanvasCamera : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    void Start()
    {
        canvas = transform.GetChild(0).GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
    }

    void Update()
    {
        canvas.transform.rotation = Camera.main.transform.rotation;
    }
}
