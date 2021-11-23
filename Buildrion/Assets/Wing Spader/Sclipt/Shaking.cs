using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{

    [SerializeField] private CameraShake shake;
    [SerializeField] private float duration, magnitude;

    private GameObject subCamera;


    // Start is called before the first frame update
    void Start()
    {
        subCamera = GameObject.Find("Sub Camera");

        shake = subCamera.GetComponent<CameraShake>();
        shake.Shake(duration, magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
