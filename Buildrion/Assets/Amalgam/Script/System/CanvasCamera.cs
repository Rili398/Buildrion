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
        if (Camera.main.gameObject)
        {
            canvas.transform.rotation = Camera.main.transform.rotation;
        }
    }
}
