using UnityEngine;

public class CanvasCamera : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    private void Awake()
    {
        canvas = transform.GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
    }

    void Update()
    {
        if (canvas.worldCamera.gameObject.activeSelf)
        {
            canvas.transform.rotation = Camera.main.transform.rotation;
        }
    }
}
